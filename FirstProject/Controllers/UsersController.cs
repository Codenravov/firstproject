using System.Web.Mvc;
using MVCWebProject.Constants;
using MVCWebProject.Infrastructure;
using MVCWebProject.Services;
using MVCWebProject.ViewModels;

namespace MVCWebProject.Controllers
{
    [ControllerExceptions]
    public class UsersController : Controller
    {
        private readonly IUsersServicePL usersService;

        public UsersController(IUsersServicePL usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult Index(string searchString = "", int page = UsersControllerConst.StartPage, string sortOption = null, bool descending = false)
        {
            var model = this.usersService.GetListingViewData(searchString, page, UsersControllerConst.PageSize, sortOption, descending);
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("Listing", model)
                : View(model);
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
                var modelWithCities = this.usersService.GetCitiesToModel(model, selectCountry);
                return PartialView("Cities", modelWithCities);
            }

            if (ModelState.IsValid)
            {
                this.usersService.AddPerson(model);
                return RedirectToAction("Index");
            }
            else
            {
                var newModel = this.usersService.GetCreateModel();
                return View(newModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this.usersService.GetEditModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model, string selectCountry = null)
        {
            if (!string.IsNullOrEmpty(selectCountry))
            {
                var modelWithCities = this.usersService.GetCitiesToModel(model, selectCountry);
                return PartialView("Cities", modelWithCities);
            }

            if (ModelState.IsValid)
            {
                this.usersService.UpdatePerson(model);
                return RedirectToAction("Index");
            }
            else
            {
                var newModel = this.usersService.GetEditModel(model.Id);
                return View(newModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = this.usersService.GetDeleteModel(id);
            return PartialView(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmen(UsersDeleteViewModel model)
        {
            this.usersService.DeletePerson(model.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Comments(int id)
        {
            var model = this.usersService.GetCommentsModel(id);
            return PartialView(model);
        }
    }
}