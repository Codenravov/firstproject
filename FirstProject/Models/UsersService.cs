namespace MVCWebProject.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using MVCWebProject.Utilities;
    using MVCWebProject.ViewModels;
    using MVCWebProjectDAL.Entities;
    using MVCWebProjectDAL.Interfaces;

    public interface IUsersService
    {
        PagedList<UsersListingViewModel> GetPagedList(string searchString, int page, string sortOption);

        UsersCreatViewModel GetCreateModel();

        UsersEditViewModel GetEditModel(int id);

        UsersDeleteViewModel GetDeleteModel(int id);

        UsersCommentsViewModel GetCommentsModel(int id);

        UsersCreatViewModel GetCities(UsersCreatViewModel model, string selectCountry);

        UsersEditViewModel GetCities(UsersEditViewModel model, string selectCountry);

        void SaveData(UsersCreatViewModel model);

        void SaveData(UsersEditViewModel model, int id);

        void DeleteData(int id);
    }

    public class UsersService : IUsersService
    {
        private readonly IRepository<Person> personRepository;
        private readonly IRepository<Country> countryRepository;
        private readonly IRepository<City> cityRepository;
        private readonly IPagingList<UsersListingViewModel> pagingList;
        private readonly IMapper mapper;

        public UsersService(
            IRepository<Person> personRepository,
            IRepository<Country> countryRepository,
            IRepository<City> cityRepository,
            IPagingList<UsersListingViewModel> pagingList,
            IMapper mapper)
        {
            this.personRepository = personRepository;
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
            this.pagingList = pagingList;
            this.mapper = mapper;
        }
        
        public virtual PagedList<UsersListingViewModel> GetPagedList(string searchString, int page, string sortOption)
        {
            string property = this.personRepository.GetProperties().First();
            if (!string.IsNullOrEmpty(sortOption) && this.personRepository.GetProperties().Any(x => x == sortOption))
            {
                property = sortOption;
            }

            var people = this.personRepository.Get(
                p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString),
                orderBy: s => s.GetType().GetProperty(property).GetValue(s, null));
            var source = this.mapper.Map<IEnumerable<Person>, IEnumerable<UsersListingViewModel>>(people);
            return this.pagingList.CreatePage(source, page, 3);
        }

        public virtual UsersCreatViewModel GetCreateModel()
        {
            UsersCreatViewModel model = new UsersCreatViewModel
            {
                Countries = new SelectList(this.countryRepository.Get(orderBy: x => x.CountryName), "CountryName", "CountryName"),
            };
            return model;
        }

        public virtual UsersEditViewModel GetEditModel(int id)
        {
            Person person = this.personRepository.GetById(id);
            var model = this.mapper.Map<Person, UsersEditViewModel>(person);
            model.Countries = new SelectList(this.countryRepository.Get(orderBy: x => x.CountryName), "CountryName", "CountryName");
            model.Cities = new SelectList(this.cityRepository.Get(x => x.CountryName.Contains(model.Country), orderBy: x => x.CityName), "CityName", "CityName");
            return model;
        }

        public virtual UsersDeleteViewModel GetDeleteModel(int id)
        {
            var person = this.personRepository.GetById(id);
            var model = this.mapper.Map<Person, UsersDeleteViewModel>(person);
            return model;
        }

        public virtual UsersCommentsViewModel GetCommentsModel(int id)
        {
            var person = this.personRepository.GetById(id);
            var model = this.mapper.Map<Person, UsersCommentsViewModel>(person);
            return model;
        }

        public virtual UsersCreatViewModel GetCities(UsersCreatViewModel model, string selectCountry)
        {
            model.Cities = new SelectList(this.cityRepository.Get(x => x.CountryName.Contains(selectCountry), orderBy: x => x.CityName), "CityName", "CityName");
            return model;
        }

        public virtual UsersEditViewModel GetCities(UsersEditViewModel model, string selectCountry)
        {
            model.Cities = new SelectList(this.cityRepository.Get(x => x.CountryName.Contains(selectCountry), orderBy: x => x.CityName), "CityName", "CityName");
            return model;
        }

        public void SaveData(UsersCreatViewModel model)
        {
            var person = this.mapper.Map<UsersCreatViewModel, Person>(model);
            this.personRepository.Add(person);
            this.personRepository.Save();
        }

        public void SaveData(UsersEditViewModel model, int id)
        {
            var person = this.mapper.Map<UsersEditViewModel, Person>(model, this.personRepository.GetById(id));
            this.personRepository.Update(person);
            this.personRepository.Save();
        }

        public void DeleteData(int id)
        {
            this.personRepository.Delete(p => p.Id == id);
            this.personRepository.Save();
        }
    }
}