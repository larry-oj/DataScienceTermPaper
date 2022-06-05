namespace Etl.Services;

public class MoviesImdbManipulator : IStageManipulator<MoviesImdb>
{
    private readonly termpaperContext _ctx;

    public MoviesImdbManipulator(termpaperContext ctx)
    {
        _ctx = ctx;
    }
    public void UploadNew()
    {
        var moviesImdb = _ctx.MoviesImdbs;
        foreach (var row in moviesImdb)
        {
            using (var ctx = new termpaperContext())
            {
                #region add film

                var filmName = row.MovieName;
                var filmDim = ctx.FilmDims.FirstOrDefault(f => f.Name == filmName);
                if (filmDim != default(FilmDim)) continue;
                filmDim = new FilmDim
                {
                    Name = filmName
                };
                ctx.FilmDims.Add(filmDim);

                #endregion
                
                #region add / get year
                
                var year = row.Year;
                var timeDim = ctx.TimeDims.FirstOrDefault(t => t.Year == year);
                if (timeDim == default(TimeDim)) // add if not exists
                {
                    timeDim = new TimeDim
                    {
                        Year = Convert.ToInt32(year)
                    };
                    ctx.TimeDims.Add(timeDim);
                }
                
                #endregion
                
                #region add / get genres
                
                // get a list of genres
                var genres = row.Genre.Split(',').ToList();

                // add genres if not exists
                var genreDimList = new List<GenreDim>();
                genres.ForEach(g =>
                {
                    var gName = g.Replace(" ", "");
                    var genreDim = ctx.GenreDims.FirstOrDefault(gd => gd.Name.ToLower() == gName.ToLower());
                    if (genreDim == default(GenreDim))
                    {
                        genreDim = new GenreDim
                        {
                            Name = gName
                        };
                        ctx.GenreDims.Add(genreDim);
                    }
                    genreDimList.Add(genreDim);
                });
                // create genre group
                var genreGroupDim = new GenreGroupDim();
                ctx.GenreGroupDims.Add(genreGroupDim);
                // link genres to genre group
                genreDimList.ForEach(gd =>
                {
                    var genreCombo = new GenreCombo
                    {
                        Genre = gd,
                        GenreGroup = genreGroupDim
                    };
                    ctx.GenreCombos.Add(genreCombo);
                });
                
                #endregion
                
                #region facts

                // create fact record
                var grossNum = 0;
                var runtimeNum = 0;
                var metascore = 0;
                try
                {
                    grossNum = Convert.ToInt32(decimal.Parse(row.UsGrossMillions) * 1000000);
                    runtimeNum = row.TimeMin;
                    metascore = Convert.ToInt32(decimal.Parse(row.Metascore));
                }
                catch { /* ignore */ }
                var fact = new Fact
                {
                    GenreGroup = genreGroupDim,
                    TimeDimNavigation = timeDim,
                    Film = filmDim,
                    Score = metascore,
                    Gross = grossNum,
                    Runtime = runtimeNum,
                    Votes = row.Votes
                };
                ctx.Facts.Add(fact);

                #endregion
                
                ctx.SaveChanges();
            }
        }
    }

    public void Update(MoviesImdb updatedItem)
    {
        throw new NotImplementedException();
    }
}