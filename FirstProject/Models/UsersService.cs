using AutoMapper;
using MVCWebProject.DAL;
using MVCWebProject.DAL.Entities;
using MVCWebProject.DAL.Interfaces;
using MVCWebProject.Utilities;
using MVCWebProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebProject.Models
{
    public interface IUsersService
    {
        PagedList<UsersListingViewModel> GetPagedList(string searchString, int page, string sortOption);
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
    }
}