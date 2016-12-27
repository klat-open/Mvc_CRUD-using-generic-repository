using FluentValidation;
using FluentValidation.Results;
using mvc_CRUD.Models;
using mvc_CRUD.Repository;
using mvc_CRUD.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public readonly IEmployeeRepository _employeeRepository;
        
        public HomeController(IEmployeeRepository _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }

        public ActionResult Index()
        {
            var emp = _employeeRepository.GetAll();
            return View(emp);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            EmployeeValidation val = new EmployeeValidation();
            ValidationResult model = val.Validate(obj);
            if (model.IsValid)
            {
                _employeeRepository.Add(obj);
                _employeeRepository.Save();
            }
            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }
            return View(obj);

        }
        // GET: Visitors/Edit/5
        public ActionResult Update(int id)
        {
            var emp = _employeeRepository.FindBy(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(emp);
                _employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Visitors/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = _employeeRepository.FindBy(id);
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
            return RedirectToAction("Index");
        }
    }
}