using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MVCWebProject.Utilities;
using MVCWebProject.ViewModels;
using MVCWebProject.ViewModels.Users;
using MVCWebProjectBLL.DTO;
using MVCWebProjectBLL.Services;

namespace MVCWebProject.Controllers
{

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

        public ActionResult Index(string searchString = "", int page = 1, string sortOption = null)
        {
            try
            {
                var source = this.usersService.GetPeople(searchString, sortOption);
                var people = this.mapper.Map<IEnumerable<PersonDTO>, IEnumerable<UsersListingViewModel>>(source);
                var list = pagingList.CreatePage(people, page, 3);
                UsersListingDataViewModel model = new UsersListingDataViewModel(searchString, page, sortOption, list);
                return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("Listing", model)
                    : View(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
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
                try
                {
                    SelectList cities = usersService.GetCities(selectCountry);
                    model.Cities = cities;
                    return PartialView("Cities", model);
                }
                catch (Exception)
                {
                    return HttpNotFound();
                }
            }
            if (ModelState.IsValid)
            {
                var person = this.mapper.Map<UsersCreatViewModel, PersonDTO>(model);
                this.usersService.SavePerson(person);
                return RedirectToAction("Index");
            }

            return Request.IsAjaxRequest()
                ? (ActionResult)View(model)
                : HttpNotFound();
        }

        [HttpGet]
        public ActionResult Edit(int? personId)
        {
            if (personId == null)
            {
                return HttpNotFound();
            }

            int id = personId.Value;
            try
            {
                var person = this.usersService.GetPerson(id);
                SelectList counties = this.usersService.GetCountries();
                SelectList cities = this.usersService.GetCities(person.Country);
                var model = this.mapper.Map<PersonDTO, UsersEditViewModel>(person);
                model.Countries = counties;
                model.Cities = cities;
                return View(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model, string selectCountry = null)
        {
            if (!string.IsNullOrEmpty(selectCountry))
            {
                try
                {
                    SelectList cities = this.usersService.GetCities(selectCountry);
                    model.Cities = cities;
                    return PartialView("Cities", model);
                }
                catch (Exception)
                {
                    return View(model);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var person = this.mapper.Map<UsersEditViewModel, PersonDTO>(model);
                    this.usersService.UpdatePerson(person);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? personId)
        {
            if (personId == null)
            {
                return HttpNotFound();
            }

            int id = personId.Value;
            try
            {
                var person = this.usersService.GetPerson(id);
                var model = this.mapper.Map<PersonDTO, UsersDeleteViewModel>(person);
                return PartialView(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmen(UsersDeleteViewModel model)
        {
            try
            {
                this.usersService.DeletePerson(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Comments(int? personId)
        {
            if (personId == null)
            {
                return HttpNotFound();
            }

            int id = personId.Value;
            try
            {
                var person = this.usersService.GetPerson(id);
                var model = this.mapper.Map<PersonDTO, UsersCommentsViewModel>(person);
                return PartialView(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}