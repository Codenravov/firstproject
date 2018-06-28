using System.Web.Mvc;
using MVCWebProject.ViewModels;
using MVCWebProject.ViewModels.Users;
using MVCWebProject.Models;
using System;

namespace MVCWebProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService _usersService)
        {
            this._usersService = _usersService;
        }

        public ActionResult Index(string searchString = "", int page = 1, string sortOption = null)
        {
            try
            {
                var pagedList = _usersService.GetPagedList(searchString, page, sortOption);
                UsersListingDataViewModel model = new UsersListingDataViewModel(searchString, page, sortOption, pagedList);
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
            var model = _usersService.GetCreateModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UsersCreatViewModel model, string SelectCountry = null)
        {
            if (!string.IsNullOrEmpty(SelectCountry))
            {
                try
                {
                    var ViewModel = _usersService.GetCities(model, SelectCountry);
                    return PartialView("CreatCities", ViewModel);
                }
                catch (Exception)
                {
                    return HttpNotFound();
                }
            }
            if (ModelState.IsValid)
            {
                _usersService.SaveData(model);
                return RedirectToAction("Index");
            }
            return Request.IsAjaxRequest()
                ? (ActionResult)View(model)
                : HttpNotFound();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int Id = id.Value;
            try
            {
                var model = _usersService.GetEditModel(Id);
                return View(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model, string SelectCountry = null)
        {
            if (!string.IsNullOrEmpty(SelectCountry))
            {
                try
                {
                    model = _usersService.GetCities(model, SelectCountry);
                    return PartialView("EditCities", model);
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
                    _usersService.SaveData(model, model.Id);
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int Id = id.Value;
            try
            {
                var model = _usersService.GetDeleteModel(Id);
                return PartialView(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmend(int id)
        {
            try
            {
                _usersService.DeleteData(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Comments(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int Id = id.Value;
            try
            {
                var model = _usersService.GetCommentsModel(Id);
                return PartialView(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}