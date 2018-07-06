namespace MVCWebProject.Controllers
{
    using System;
    using System.Web.Mvc;
    using MVCWebProject.Models;
    using MVCWebProject.ViewModels;
    using MVCWebProject.ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult Index(string searchString = "", int page = 1, string sortOption = null)
        {
            try
            {
                var pagedList = this.usersService.GetPagedList(searchString, page, sortOption);
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
            var model = this.usersService.GetCreateModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UsersCreatViewModel model, string selectCountry = null)
        {
            if (!string.IsNullOrEmpty(selectCountry))
            {
                try
                {
                    var viewModel = this.usersService.GetCities(model, selectCountry);
                    return PartialView("Cities", viewModel);
                }
                catch (Exception)
                {
                    return HttpNotFound();
                }
            }

            if (ModelState.IsValid)
            {
                this.usersService.SaveData(model);
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
                var model = this.usersService.GetEditModel(id);
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
                    model = this.usersService.GetCities(model, selectCountry);
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
                    this.usersService.SaveData(model, model.Id);
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
                var model = this.usersService.GetDeleteModel(id);
                return PartialView(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmen(int id)
        {
            try
            {
                this.usersService.DeleteData(id);
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
                var model = this.usersService.GetCommentsModel(id);
                return PartialView(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}