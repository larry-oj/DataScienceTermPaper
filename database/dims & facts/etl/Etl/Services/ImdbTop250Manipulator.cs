namespace Etl.Services;

public class ImdbTop250Manipulator : IStageManipulator<ImdbTop250>
{
    private readonly termpaperContext _ctx;
    
    public ImdbTop250Manipulator(termpaperContext ctx)
    {
        _ctx = ctx;
    }
    
    public void UploadNew()
    {
        var imdbTop250 = _ctx.ImdbTop250s;
        var xd = 0;
        foreach (var row in imdbTop250)
        {
            using (var ctx = new termpaperContext())
            {
                #region dimentions

                #region add film
                
                var filmName = row.Title;
                Console.WriteLine($"{xd++} - {filmName}");
                var filmDim = ctx.FilmDims.FirstOrDefault(f => f.Name.ToLower() == filmName.ToLower());
                if (filmDim != default(FilmDim)) continue;
                filmDim = new FilmDim
                {
                    Name = filmName
                };
                ctx.FilmDims.Add(filmDim);
                
                #endregion

                #region add / get year
                
                var year = row.Date;
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
                
                #region add / get director
                
                var directorName = row.Director;
                var directorDim = ctx.PersonDims.FirstOrDefault(d => d.Name.ToLower() == directorName.ToLower());
                if (directorDim == default(PersonDim))
                {
                    directorDim = new PersonDim
                    {
                        Name = directorName
                    };
                    ctx.PersonDims.Add(directorDim);
                }
                
                #endregion
                
                #region add / get actors
                
                // get a list of actors
                var actorNameList = new List<string>
                {
                    row.Cast1,
                    row.Cast2,
                    row.Cast3,
                    row.Cast4
                };
                // add actors if not exists
                var actorDimList = new List<PersonDim>();
                actorNameList.ForEach(a =>
                {
                    var actorDim = ctx.PersonDims.FirstOrDefault(pd => pd.Name.ToLower() == a.ToLower());
                    if (actorDim == default(PersonDim))
                    {
                        actorDim = new PersonDim
                        {
                            Name = a
                        };
                        ctx.PersonDims.Add(actorDim);
                    }
                    actorDimList.Add(actorDim);
                });
                // create actor group
                var actorGroupDim = new ActorGroupDim();
                ctx.ActorGroupDims.Add(actorGroupDim);
                // link actors to actor group
                actorDimList.ForEach(ad =>
                {
                    var actorCombo = new ActorCombo
                    {
                        Person = ad,
                        ActorGroup = actorGroupDim
                    };
                    ctx.ActorCombos.Add(actorCombo);
                });
                
                #endregion
                
                #endregion
                
                #region facts

                // create fact record
                var grossNum = 0;
                var runtimeNum = 0;
                try
                {
                    grossNum = Convert.ToInt32(row.Gross * 1000000);
                    runtimeNum = row.RunTime;
                }
                catch { /* ignore */ }
                var fact = new Fact
                {
                    GenreGroup = genreGroupDim,
                    TimeDimNavigation = timeDim,
                    Director = directorDim,
                    ActorGroup = actorGroupDim,
                    Film = filmDim,
                    Rating = (double?)row.Rating,
                    Score = Convert.ToInt32(row.Score),
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

    public void Update(ImdbTop250 updatedItem)
    {
        throw new NotImplementedException();
    }
}