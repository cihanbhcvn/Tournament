using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public void SeedData()
        {
            var countries = new List<Country>()
            {
                new Country
                {
                    Id = 1,
                    Name = "Türkiye"
                },
                new Country
                {
                    Id = 2,
                    Name = "Almanya"
                },
                new Country
                {
                    Id = 3,
                    Name = "Fransa"
                },
                new Country
                {
                    Id = 4,
                    Name = "Hollanda"
                },
                new Country
                {
                    Id = 5,
                    Name = "Portekiz"
                },
                new Country
                {
                    Id = 6,
                    Name = "İtalya"
                },
                new Country
                {
                    Id = 7,
                    Name = "İspanya"
                },
                new Country
                {
                    Id = 8,
                    Name = "Belçika"
                },

            };

            foreach (var country in countries)
            {
                _countryDal.Add(country);
            }
        }
    }
}
