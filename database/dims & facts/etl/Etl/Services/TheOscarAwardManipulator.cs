using Microsoft.EntityFrameworkCore;

namespace Etl.Services;

public class TheOscarAwardManipulator : IStageManipulator<TheOscarAward>
{
    private readonly termpaperContext _ctx;

    public TheOscarAwardManipulator(termpaperContext ctx)
    {
        _ctx = ctx;
    }

    public void UploadNew()
    {
        var theOscarAward = _ctx.TheOscarAwards.Reverse();
        foreach (var row in theOscarAward)
        {
            using (var ctx = new termpaperContext())
            {
                #region find fact

                var hasOthers = false;
                var factDim = ctx.Facts.Include(fd => fd.Film).Include(fd => fd.OscarGroup)
                    .FirstOrDefault(fd => fd.Film.Name.ToLower() == row.Film.ToLower());
                if (factDim == default(Fact)) continue;
                if (factDim.OscarGroup != default(OscarGroupDim)) hasOthers = true;
                
                #endregion
                
                #region category

                var categoryDim = ctx.CategoryDims.FirstOrDefault(cd => cd.Name.ToLower() == row.Category);
                if (categoryDim == default(CategoryDim))
                {
                    categoryDim = new CategoryDim
                    {
                        Name = row.Category
                    };
                    ctx.CategoryDims.Add(categoryDim);
                }

                #endregion
                
                #region oscar dim
                
                // create group
                var oscarDim = new OsacarDim
                {
                    Category = categoryDim,
                    Winner = bool.Parse(row.Winner),
                    CeremonyNum = row.Ceremony,
                    CeremonyYear = row.YearCeremony
                };
                ctx.OsacarDims.Add(oscarDim);
                var oscarGroupDim = new OscarGroupDim();
                if (hasOthers) oscarGroupDim = factDim.OscarGroup;
                var oscarCombo = new OscarCombo
                {
                    OscarDim = oscarDim,
                    OsacrGroup = oscarGroupDim
                };
                ctx.OscarCombos.Add(oscarCombo);

                factDim.OscarGroup = oscarGroupDim;

                #endregion

                ctx.SaveChanges();
            }
        }
    }

    public void Update(TheOscarAward updatedItem)
    {
        throw new NotImplementedException();
    }
}