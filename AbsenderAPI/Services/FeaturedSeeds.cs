using AbsenderAPI.Data;
using AbsenderAPI.Models.UniversityModels;
using System.Linq;

namespace AbsenderAPI.Services
{
    public class FeaturedSeeds : IFeaturedSeeds
    {
        private ApplicationDbContext _dbContext { get; set; }
        public FeaturedSeeds(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        readonly string[] Seances = {
            "0900",
            "1030",
            "1045",
            "1215",
            "1315",
            "1445",
            "1500",
            "1630",
            "1345",
            "1515",
            "1530",
            "1700"

        };

        public void SeedData()
        {
            foreach (var item in Seances)
            {
                _dbContext.TempsSeance.Add(new TempsSeance()
                {
                    RepresentationHHMM = item
                });
            }
            _dbContext.SaveChanges();
        }
    }
}
