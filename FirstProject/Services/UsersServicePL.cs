using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MVCWebProject.Constants;
using MVCWebProject.Utilities;
using MVCWebProject.ViewModels;
using MVCWebProject.ViewModels.Users;
using MVCWebProjectBLL.DTO;
using MVCWebProjectBLL.Service;

namespace MVCWebProject.Services
{
    public class UsersServicePL : IUsersServicePL
    {
        private readonly IUsersServiceBLL usersServiceBLL;
        private readonly IPagingList<UsersListingViewModel> pagingList;
        private readonly IMapper mapper;

        public UsersServicePL(
            IUsersServiceBLL usersServiceBLL,
            IPagingList<UsersListingViewModel> pagingList,
            IMapper mapper)
        {
            this.usersServiceBLL = usersServiceBLL;
            this.pagingList = pagingList;
            this.mapper = mapper;
        }

        public UsersListingDataViewModel GetListingViewData(string searchString, int page, int pageSize, string sortOption, bool descending)
        {
            var source = this.usersServiceBLL.GetPeople(searchString, sortOption, descending);
            var people = this.mapper.Map<IEnumerable<PersonDTO>, IEnumerable<UsersListingViewModel>>(source);
            var list = pagingList.CreatePage(people, page, pageSize);
            return new UsersListingDataViewModel(searchString, page, sortOption, descending, list);
        }

        public UsersCreatViewModel GetCreateModel()
        {
            SelectList countries = usersServiceBLL.GetCountries();
            UsersCreatViewModel model = new UsersCreatViewModel
            {
                Countries = countries
            };
            return model;
        }

        public UsersCreatViewModel GetCitiesToModel(UsersCreatViewModel model, string selectCountry)
        {
            SelectList cities = usersServiceBLL.GetCities(selectCountry);
            model.Cities = cities;
            return model;
        }

        public UsersEditViewModel GetCitiesToModel(UsersEditViewModel model, string selectCountry)
        {
            SelectList cities = usersServiceBLL.GetCities(selectCountry);
            model.Cities = cities;
            return model;
        }

        public void AddPerson(UsersCreatViewModel model)
        {
            var person = this.mapper.Map<UsersCreatViewModel, PersonDTO>(model);
            this.usersServiceBLL.AddPerson(person);
        }

        public UsersEditViewModel GetEditModel(int id)
        {
            var person = this.usersServiceBLL.GetPerson(id);
            var model = this.mapper.Map<PersonDTO, UsersEditViewModel>(person);
            model.Countries = this.usersServiceBLL.GetCountries();
            var modelWithCities = this.GetCitiesToModel(model, model.Country);
            return modelWithCities;
        }

        public void UpdatePerson(UsersEditViewModel model)
        {
            var person = this.mapper.Map<UsersEditViewModel, PersonDTO>(model);
            this.usersServiceBLL.UpdatePerson(person);
        }

        public UsersDeleteViewModel GetDeleteModel(int id)
        {
            var person = this.usersServiceBLL.GetPerson(id);
            var model = this.mapper.Map<PersonDTO, UsersDeleteViewModel>(person);
            return model;
        }

        public void DeletePerson(int id)
        {
            this.usersServiceBLL.DeletePerson(id);
        }

        public UsersCommentsViewModel GetCommentsModel(int id)
        {
            var person = this.usersServiceBLL.GetPerson(id);
            var model = this.mapper.Map<PersonDTO, UsersCommentsViewModel>(person);
            return model;
        }
    }
}