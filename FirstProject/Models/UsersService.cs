using AutoMapper;
using MVCWebProject.DAL;
using MVCWebProject.DAL.Entities;
using MVCWebProject.DAL.Interfaces;
using MVCWebProject.Utilities;
using MVCWebProject.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCWebProject.Models
{
    public interface IUsersService
    {
        PagedList<UsersListingViewModel> GetPagedList(string searchString, int page, string sortOption);
        UsersCreatViewModel GetCreateModel();
        UsersEditViewModel GetEditModel(int Id);
        UsersDeleteViewModel GetDeleteModel(int Id);
        UsersCommentsViewModel GetCommentsModel(int Id);
        UsersCreatViewModel GetCities(UsersCreatViewModel model, string SelectCountry);
        UsersEditViewModel GetCities(UsersEditViewModel model, string SelectCountry);
        void SaveData(UsersCreatViewModel model);
        void SaveData(UsersEditViewModel model, int Id);
        void DeleteData(int Id);
    }
    public class UsersService : IUsersService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IPagingList<UsersListingViewModel> _pagingList;
        private readonly IMapper _mapper;

        public UsersService(IRepository<Person> _personRepository, IRepository<Country> _countryRepository,
            IRepository<City> _cityRepository, IPagingList<UsersListingViewModel> _pagingList, IMapper _mapper)
        {
            this._personRepository = _personRepository;
            this._countryRepository = _countryRepository;
            this._cityRepository = _cityRepository;
            this._pagingList = _pagingList;
            this._mapper = _mapper;
        }
        
        public virtual PagedList<UsersListingViewModel> GetPagedList(string searchString, int page, string sortOption)
        {
            string property = _personRepository.GetProperties().First();
            if (!string.IsNullOrEmpty(sortOption) && _personRepository.GetProperties().Any(x => x == sortOption)) { property = sortOption; }
            var people = _personRepository.Get(p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString),
                orderBy: s => s.GetType().GetProperty(property).GetValue(s, null));
            var source = _mapper.Map<IEnumerable<Person>, IEnumerable<UsersListingViewModel>>(people);
            return _pagingList.CreatePage(source, page, 3);
        }
        public virtual UsersCreatViewModel GetCreateModel()
        {
            UsersCreatViewModel model = new UsersCreatViewModel
            {
                Countries = new SelectList(_countryRepository.Get(orderBy: x => x.CountryName), "CountryName", "CountryName"),
            };
            return model;
        }
        public virtual UsersEditViewModel GetEditModel(int Id)
        {
            Person person = _personRepository.GetById(Id);
            var model = _mapper.Map<Person, UsersEditViewModel>(person);
            model.Countries = new SelectList(_countryRepository.Get(orderBy: x => x.CountryName), "CountryName", "CountryName");
            model.Cities = new SelectList(_cityRepository.Get(x => x.CountryName.Contains(model.Country), orderBy: x => x.CityName), "CityName", "CityName");
            return model;
        }
        public virtual UsersDeleteViewModel GetDeleteModel(int Id)
        {
            var person = _personRepository.GetById(Id);
            var model = _mapper.Map<Person, UsersDeleteViewModel>(person);
            return model;
        }
        public virtual UsersCommentsViewModel GetCommentsModel(int Id)
        {
            var person = _personRepository.GetById(Id);
            var model = _mapper.Map<Person, UsersCommentsViewModel>(person);
            return model;
        }
        public virtual UsersCreatViewModel GetCities(UsersCreatViewModel model, string SelectCountry)
        {
            model.Cities = new SelectList(_cityRepository.Get(x => x.CountryName.Contains(SelectCountry), orderBy: x => x.CityName), "CityName", "CityName");
            return model;
        }
        public virtual UsersEditViewModel GetCities(UsersEditViewModel model, string SelectCountry)
        {
            model.Cities = new SelectList(_cityRepository.Get(x => x.CountryName.Contains(SelectCountry), orderBy: x => x.CityName), "CityName", "CityName");
            return model;
        }
        public void SaveData(UsersCreatViewModel model)
        {
            var person = _mapper.Map<UsersCreatViewModel, Person>(model);
            _personRepository.Add(person);
            _personRepository.Save();
        }
        public void SaveData(UsersEditViewModel model, int Id)
        {
            var person = _mapper.Map<UsersEditViewModel, Person>(model, _personRepository.GetById(Id));
            _personRepository.Update(person);
            _personRepository.Save();
        }
        public void DeleteData(int Id)
        {
            _personRepository.Delete(p => p.Id == Id);
            _personRepository.Save();
        }
    }
}