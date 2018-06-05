using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using MVCWebProject.DAL.Interfaces;
using MVCWebProject.DAL;
using MVCWebProject.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using MVCWebProject.Utilities;
using MVCWebProject.ViewModels.Users;

namespace MVCWebProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<Person> _repository;
        private readonly IPagingList<UsersListingViewModel> _pagingList;

        public UsersController(IRepository<Person> _repository, IPagingList<UsersListingViewModel> _pagingList)
        {
            this._repository = _repository;
            this._pagingList = _pagingList;

        }

        public ActionResult Index(string searchString = "", int page = 1, string sortOption = "")
        {
            var people = _repository.Get(p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString), orderBy: s => s.OrderBy(p => p.City));
            var source = Mapper.Map<IEnumerable<Person>, IEnumerable<UsersListingViewModel>>(people);
            _pagingList.CreatePage(source, page, 3);
            UsersListingDataViewModel model = new UsersListingDataViewModel(searchString, page, sortOption, _pagingList);
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("Listing", model)
                : View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsersCreatViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.Map<UsersCreatViewModel, Person>(model);
                _repository.Add(person);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int Id = id.Value;
            if (_repository.IsExist(p => p.Id == Id))
            {
                Person person = _repository.GetById(Id);
                var model = Mapper.Map<Person, UsersEditViewModel>(person);
                return View(model);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_repository.IsExist(p => p.Id == model.Id))
                {
                    var person = Mapper.Map<UsersEditViewModel, Person>(model, _repository.GetById(model.Id));
                    _repository.Update(person);
                    _repository.Save();
                    return RedirectToAction("Index");
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
            if (_repository.IsExist(p => p.Id == Id))
            {
                var person = _repository.GetById(Id);
                var model = Mapper.Map<Person, UsersDeleteViewModel>(person);
                return PartialView(model);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmend(int id)
        {
            if (_repository.IsExist(p => p.Id == id))
            {
                _repository.Delete(p => p.Id == id);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        public ActionResult Comments(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int Id = id.Value;
            if (_repository.IsExist(p => p.Id == id))
            {
                var person = _repository.GetById(Id);
                var model = Mapper.Map<Person, UsersCommentsViewModel>(person);
                return PartialView(model);
            }
            return HttpNotFound();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);

        //}
    }
}