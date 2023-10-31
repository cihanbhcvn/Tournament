using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;
        private readonly ICountryDal _countryDal;

        public TeamManager(ICountryDal countryDal, ITeamDal teamDal)
        {
            _countryDal = countryDal;
            _teamDal = teamDal;
        }

        public void SeedData()
        {
            var countries = _countryDal.GetList();
            var turkiye = countries.Data.Where(x => x.Name == "Türkiye").FirstOrDefault().Id;
            var almanya = countries.Data.Where(x => x.Name == "Almanya").FirstOrDefault().Id;
            var fransa = countries.Data.Where(x => x.Name == "Fransa").FirstOrDefault().Id;
            var hollanda = countries.Data.Where(x => x.Name == "Hollanda").FirstOrDefault().Id;
            var portekiz = countries.Data.Where(x => x.Name == "Portekiz").FirstOrDefault().Id;
            var italya = countries.Data.Where(x => x.Name == "İtalya").FirstOrDefault().Id;
            var ispanya = countries.Data.Where(x => x.Name == "İspanya").FirstOrDefault().Id;
            var belçika = countries.Data.Where(x => x.Name == "Belçika").FirstOrDefault().Id;


            var teams = new List<Team>
            {
                new Team { Id = 1,Name="Adesso İstanbul",CountryId=turkiye},
                new Team { Id = 2,Name="Adesso Ankara",CountryId=turkiye},
                new Team { Id = 3,Name="Adesso İzmir",CountryId=turkiye},
                new Team { Id = 4,Name="Adesso Antalya",CountryId=turkiye},

                new Team { Id = 5,Name="Adesso Berlin",CountryId=almanya},
                new Team { Id = 6,Name="Adesso Frankfurt",CountryId=almanya},
                new Team { Id = 7,Name="Adesso Münih", CountryId = almanya },
                new Team { Id = 8,Name="Adesso Dortmund",CountryId=almanya},

                new Team { Id = 9,Name="Adesso Paris",CountryId=fransa},
                new Team { Id = 10,Name="Adesso Marsilya",CountryId=fransa},
                new Team { Id = 11,Name="Adesso Nice",CountryId=fransa},
                new Team { Id = 12,Name="Adesso Lyon",CountryId=fransa},

                new Team { Id = 13,Name="Adesso Amsterdam",CountryId=hollanda},
                new Team { Id = 14,Name="Adesso Rotterdam",CountryId=hollanda},
                new Team { Id = 15,Name="Adesso Lahey",CountryId=hollanda},
                new Team { Id= 16,Name="Adesso Eindhoven",CountryId=hollanda},

                new Team { Id= 17,Name="Adesso Lizbon",CountryId=portekiz},
                new Team { Id= 18,Name="Adesso Porto",CountryId=portekiz},
                new Team { Id= 19,Name="Adesso Braga",CountryId=portekiz},
                new Team { Id= 20,Name="Adesso Coimbra",CountryId=portekiz},

                new Team { Id= 21,Name="Adesso Roma",CountryId=italya},
                new Team { Id= 22,Name="Adesso Milano",CountryId=italya},
                new Team { Id= 23,Name="Adesso Venedik",CountryId=italya},
                new Team { Id= 24,Name="Adesso Napoli",CountryId=italya},

                new Team { Id= 25,Name="Adesso Sevilla",CountryId=ispanya},
                new Team { Id= 26,Name="Adesso Madrid",CountryId=ispanya},
                new Team { Id= 27,Name="Adesso Barselona",CountryId=ispanya},
                new Team { Id= 28,Name="Adesso Granada",CountryId=ispanya},

                new Team { Id= 29,Name="Adesso Brüksel",CountryId=belçika},
                new Team { Id= 30,Name="Adesso Brugge",CountryId=belçika},
                new Team { Id= 31,Name="Adesso Gent",CountryId=belçika},
                new Team { Id= 32,Name="Adesso Anvers",CountryId=belçika}
            };

            foreach (var team in teams)
            {
                _teamDal.Add(team);
            }
        }
    }
}
