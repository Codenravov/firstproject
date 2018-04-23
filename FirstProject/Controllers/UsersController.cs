using System.Linq;
using System.Web.Mvc;
using X.PagedList;
using MVCWebProject.DAL.Interfaces;
using MVCWebProject.DAL;
using MVCWebProject.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace MVCWebProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<Person> _repository;

        public UsersController(IRepository<Person> _repository)
        {
            this._repository = _repository;
        }

        public ActionResult Index(string searchString = "", int page = 1, string sortOption = "")
        {
            var people = _repository.GetWithPaging(p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString), s => s.OrderBy(f => f.Id), page: page);
            IEnumerable<UsersListingViewModel> source = Mapper.Map<IEnumerable<Person>, IEnumerable<UsersListingViewModel>>(people);
            switch (sortOption)
            {
                case "name_acs":
                    source = source.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    source = source.OrderByDescending(p => p.Name);
                    break;
                case "phone_acs":
                    source = source.OrderBy(p => p.Phone);
                    break;
                case "phone_desc":
                    source = source.OrderByDescending(p => p.Phone);
                    break;
                case "email_acs":
                    source = source.OrderBy(p => p.Email);
                    break;
                case "email_desc":
                    source = source.OrderByDescending(p => p.Email);
                    break;
                case "title_acs":
                    source = source.OrderBy(p => p.Title);
                    break;
                case "title_desc":
                    source = source.OrderByDescending(p => p.Title);
                    break;
                case "country_acs":
                    source = source.OrderBy(p => p.Country);
                    break;
                case "country_desc":
                    source = source.OrderByDescending(p => p.Country);
                    break;
                case "city_acs":
                    source = source.OrderBy(p => p.City);
                    break;
                case "city_desc":
                    source = source.OrderByDescending(p => p.City);
                    break;
                default:
                    source = source.OrderBy(p => p.Id);
                    break;
            }
            IPagedList<UsersListingViewModel> model = new StaticPagedList<UsersListingViewModel>(source, people.GetMetaData());
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