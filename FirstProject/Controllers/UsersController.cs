using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MVCWebProject.Infrastructure;
using MVCWebProject.Resources.Controllers;
using MVCWebProject.Utilities;
using MVCWebProject.ViewModels;
using MVCWebProject.ViewModels.Users;
using MVCWebProjectBLL.DTO;
using MVCWebProjectBLL.Services;

namespace MVCWebProject.Controllers
{

    [ControllerExceptions]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IPagingList<UsersListingViewModel> pagingList;
        private readonly IMapper mapper;

        public UsersController(
            IUsersService usersService,
            IPagingList<UsersListingViewModel> pagingList,
            IMapper mapper)
        {
            this.usersService = usersService;
            this.pagingList = pagingList;
            this.mapper = mapper;
        }
        public ActionResult Index(string searchString = "", int page = UsersControllerConst.StartPage, string sortOption = null)
        {
            var source = this.usersService.GetPeople(searchString, sortOption);
            var people = this.mapper.Map<IEnumerable<PersonDTO>, IEnumerable<UsersListingViewModel>>(source);
            var list = pagingList.CreatePage(people, page, UsersControllerConst.PageSize);
            UsersListingDataViewModel model = new UsersListingDataViewModel(searchString, page, sortOption, list);
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("Listing", model)
                : View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList countries = usersService.GetCountries();
            UsersCreatViewModel model = new UsersCreatViewModel
            {
                Countries = countries
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UsersCreatViewModel model, string selectCountry = null)
        {
            if (!string.IsNullOrEmpty(selectCountry))
            {
                SelectList cities = usersService.GetCities(selectCountry);
                model.Cities = cities;
                return PartialView("Cities", model);
            }
            if (ModelState.IsValid)
            {
                var person = this.mapper.Map<UsersCreatViewModel, PersonDTO>(model);
                this.usersService.SavePerson(person);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Edit(int? personId)
        {
            int id = personId.Value;
            var person = this.usersService.GetPerson(id);
            SelectList counties = this.usersService.GetCountries();
            SelectList cities = this.usersService.GetCities(person.Country);
            var model = this.mapper.Map<PersonDTO, UsersEditViewModel>(person);
            model.Countries = counties;
            model.Cities = cities;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model, string selectCountry = null)
        {
            if (!string.IsNullOrEmpty(selectCountry))
            {
                SelectList cities = this.usersService.GetCities(selectCountry);
                model.Cities = cities;
                return PartialView("Cities", model);
            }

            if (ModelState.IsValid)
            {
                var person = this.mapper.Map<UsersEditViewModel, PersonDTO>(model);
                this.usersService.UpdatePerson(person);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        /// TODO: Fix without int fall
        [HttpGet]
        public ActionResult Delete(int? personId)
        {
            int id = personId.Value;
            var person = this.usersService.GetPerson(id);
            var model = this.mapper.Map<PersonDTO, UsersDeleteViewModel>(person);
            return PartialView(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmen(UsersDeleteViewModel model)
        {
            this.usersService.DeletePerson(model.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Comments(int? personId)
        {
            if (personId == null)
            {
                return HttpNotFound();
            }

            int id = personId.Value;
            var person = this.usersService.GetPerson(id);
            var model = this.mapper.Map<PersonDTO, UsersCommentsViewModel>(person);
            return PartialView(model);
        }
    }
}