namespace Etl.Services;

public class ImdbTop1000Manipulator : IStageManipulator<ImdbTop1000>
{
    private readonly termpaperContext _ctx;

    public ImdbTop1000Manipulator(termpaperContext context)
    {
        _ctx = context;
    }

    public void UploadNew()
    {
        using var ctx = new termpaperContext();
        var imdbTop1000 = ctx.ImdbTop1000s;
        foreach(var row in imdbTop1000)
        {
            var filmName = row.SeriesTitle;
            
            #region dimentions
            
            #region add film
            
            var filmDim = _ctx.FilmDims.FirstOrDefault(f => f.Name.ToLower() == filmName.ToLower());
            if (filmDim != default(FilmDim)) continue; // if film exists, skip
            filmDim = new FilmDim
            {
                Name = filmName
            };
            _ctx.FilmDims.Add(filmDim);
            
            #endregion
            
            #region add / get year
            
            var year = row.ReleasedYear;
            var timeDim = _ctx.TimeDims.FirstOrDefault(t => t.Year.ToString() == year);
            if (timeDim == default(TimeDim)) // add if not exists
            {
                timeDim = new TimeDim
                {
                    Year = Convert.ToInt32(year)
                };
                _ctx.TimeDims.Add(timeDim);
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
                var genreDim = _ctx.GenreDims.FirstOrDefault(gd => gd.Name.ToLower() == gName.ToLower());
                if (genreDim == default(GenreDim))
                {
                    genreDim = new GenreDim
                    {
                        Name = gName
                    };
                    _ctx.GenreDims.Add(genreDim);
                }
                genreDimList.Add(genreDim);
            });
            // create genre group
            var genreGroupDim = new GenreGroupDim();
            _ctx.GenreGroupDims.Add(genreGroupDim);
            // link genres to genre group
            genreDimList.ForEach(gd =>
            {
                var genreCombo = new GenreCombo
                {
                    Genre = gd,
                    GenreGroup = genreGroupDim
                };
                _ctx.GenreCombos.Add(genreCombo);
            });
            
            #endregion
            
            #region add / get director
            
            var directorName = row.Director;
            var directorDim = _ctx.PersonDims.FirstOrDefault(d => d.Name.ToLower() == directorName.ToLower());
            if (directorDim == default(PersonDim))
            {
                directorDim = new PersonDim
                {
                    Name = directorName
                };
                _ctx.PersonDims.Add(directorDim);
            }
            
            #endregion
            
            #region add / get actors
            
            // get a list of actors
            var actorNameList = new List<string>
            {
                row.Star1,
                row.Star2,
                row.Star3,
                row.Star4
            };
            // add actors if not exists
            var actorDimList = new List<PersonDim>();
            actorNameList.ForEach(a =>
            {
                var actorDim = _ctx.PersonDims.FirstOrDefault(pd => pd.Name.ToLower() == a.ToLower());
                if (actorDim == default(PersonDim))
                {
                    actorDim = new PersonDim
                    {
                        Name = a
                    };
                    _ctx.PersonDims.Add(actorDim);
                }
                actorDimList.Add(actorDim);
            });
            // create actor group
            var actorGroupDim = new ActorGroupDim();
            _ctx.ActorGroupDims.Add(actorGroupDim);
            // link actors to actor group
            actorDimList.ForEach(ad =>
            {
                var actorCombo = new ActorCombo
                {
                    Person = ad,
                    ActorGroup = actorGroupDim
                };
                _ctx.ActorCombos.Add(actorCombo);
            });
            
            #endregion
            
            #endregion

            #region facts

            // create fact record
            var grossNum = 0;
            var runtimeNum = 0;
            try
            {
                grossNum = int.Parse(row.Gross.Replace(",", "").Split('\"').FirstOrDefault()!);
                runtimeNum = int.Parse(row.Runtime.Replace("min", "").Replace(" ", ""));
            }
            catch { /* ignore */ }
            var fact = new Fact
            {
                GenreGroup = genreGroupDim,
                TimeDimNavigation = timeDim,
                Director = directorDim,
                ActorGroup = actorGroupDim,
                Film = filmDim,
                Rating = (double?)row.ImdbRating,
                Score = row.MetaScore,
                Gross = grossNum,
                Runtime = runtimeNum,
                Votes = row.NoOfVotes
            };
            _ctx.Facts.Add(fact);

            #endregion
            
            _ctx.SaveChanges();
        }
    }

    public void Update(ImdbTop1000 updatedItem)
    {
        throw new NotImplementedException();
    }
}