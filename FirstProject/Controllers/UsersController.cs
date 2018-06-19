using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using MVCWebProject.DAL.Interfaces;
using MVCWebProject.DAL;
using MVCWebProject.ViewModels;
using System.Collections.Generic;
using MVCWebProject.Utilities;
using MVCWebProject.ViewModels.Users;
using AutoMapper;
using MVCWebProject.DAL.Entities;

namespace MVCWebProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IPagingList<UsersListingViewModel> _pagingList;
        private readonly IMapper _mapper;

        public UsersController(IRepository<Person> _personRepository, IRepository<Country> _countryRepository,
            IRepository<City> _cityRepository, IPagingList<UsersListingViewModel> _pagingList, IMapper _mapper)
        {
            this._personRepository = _personRepository;
            this._countryRepository = _countryRepository;
            this._cityRepository = _cityRepository;
            this._pagingList = _pagingList;
            this._mapper = _mapper;

        }

        public ActionResult Index(string searchString = "", int page = 1, string sortOption = "")
        {
            var people = _personRepository.Get(p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString), orderBy: s => s.OrderBy(p => p.City));
            var source = _mapper.Map<IEnumerable<Person>, IEnumerable<UsersListingViewModel>>(people);
            _pagingList.CreatePage(source, page, 3);
            UsersListingDataViewModel model = new UsersListingDataViewModel(searchString, page, sortOption, _pagingList);
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("Listing", model)
                : View(model);
        }

        [HttpGet]
        public ActionResult Create(UsersCreatViewModel model, string SelectCountry = null)
        {
            var Countries = _countryRepository.Get(orderBy: x => x.OrderBy(s => s.CountryName));
            ViewBag.Countries = new SelectList(Countries, "CountryName", "CountryName");
            if (SelectCountry == null) { return View(); }
            if (Countries.Any(x => x.CountryName == SelectCountry))
            {
                var Cities = _cityRepository.Get(x => x.CountryName.Contains(SelectCountry), orderBy: x => x.OrderBy(s => s.CityName));
                ViewBag.Cities = new SelectList(Cities, "CityName", "CityName");
                return PartialView("Cities");
            }
            else { return HttpNotFound(); }
        }

        [HttpPost]
        public ActionResult Create(UsersCreatViewModel model)
        {

            if (ModelState.IsValid)
            {
                var person = _mapper.Map<UsersCreatViewModel, Person>(model);
                _personRepository.Add(person);
                _personRepository.Save();
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
            if (_personRepository.IsExist(p => p.Id == Id))
            {
                Person person = _personRepository.GetById(Id);
                var model = _mapper.Map<Person, UsersEditViewModel>(person);
                return View(model);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_personRepository.IsExist(p => p.Id == model.Id))
                {
                    var person = _mapper.Map<UsersEditViewModel, Person>(model, _personRepository.GetById(model.Id));
                    _personRepository.Update(person);
                    _personRepository.Save();
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
            if (_personRepository.IsExist(p => p.Id == Id))
            {
                var person = _personRepository.GetById(Id);
                var model = _mapper.Map<Person, UsersDeleteViewModel>(person);
                return PartialView(model);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmend(int id)
        {
            if (_personRepository.IsExist(p => p.Id == id))
            {
                _personRepository.Delete(p => p.Id == id);
                _personRepository.Save();
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
            if (_personRepository.IsExist(p => p.Id == id))
            {
                var person = _personRepository.GetById(Id);
                var model = _mapper.Map<Person, UsersCommentsViewModel>(person);
                return PartialView(model);
            }
            return HttpNotFound();
        }
    }
}