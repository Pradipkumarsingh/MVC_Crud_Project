using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Crud_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Crud_Project.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDbContext dbContext { get; }
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //List<Employee> employees = dbContext.Employees.ToList()


            List<EmployeeDataModel> model = (from emp in dbContext.Employees
                                             join countryData in dbContext.Countries on emp.CountryId equals countryData.CountryId
                                             join stateData in dbContext.States on emp.StateId equals stateData.StateId
                                             join cityData in dbContext.Cities on emp.CityId equals cityData.CityId
                                             select new EmployeeDataModel
                                             {
                                                 Id = emp.Id,
                                                 Name = emp.Name,
                                                 Mobile = emp.Mobile,
                                                 Email = emp.Email,
                                                 CountryName = countryData.CountryName,
                                                 StateName = stateData.StateName,
                                                 CityName = cityData.CityName,
                                                 DOB = Convert.ToDateTime(emp.DOB.ToString("yyyy-MM-dd"))
                                             }).ToList();

            return View(model);
        }
        

         public JsonResult GetCountries()
          {
              var countries = dbContext.Countries.ToList();

              return Json(countries);
          }
          public JsonResult GetStates(int id)
          {
              var states = dbContext.States.Where(e => e.Country.CountryId== id).ToList();
              return Json(states);
          }
          public JsonResult GetCities(int id)
          {
              var cities = dbContext.Cities.Where(e => e.State.StateId == id).ToList();
              return Json(cities);
          }
        //public JsonResult BindStates()
        //{
        //    var states = dbContext.States.ToList();
        //    return Json(states);
        //}
        //public JsonResult BindCities()
        //{
        //    var cities = dbContext.Cities.ToList();
        //    return Json(cities);
        //}
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee emp)
        {
           if (ModelState.IsValid)
            {
               /* string name = Request.Form["Name"];
                string mobile = Request.Form["Mobile"];
                string email = Request.Form["Email"];
                string stateId = Request.Form["StateId"];
                string cityId = Request.Form["CityId"];
                string dob = Request.Form["DOB"];

                var y = new Employee()
                {
                    Name = name,
                    Mobile = mobile,
                    Email = email,

                   DOB = Convert.ToDateTime(dob)
                };*/
                dbContext.Employees.Add(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Update(int id)
            {
           
                var DbCheckEmp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            List<Country> CountryList = dbContext.Countries.ToList();
            ViewBag.CountryList = CountryList;
            List<State> StateList = dbContext.States.ToList();
            ViewBag.StateList = StateList;
            List<City> CityList = dbContext.Cities.ToList();
            ViewBag.CityList = CityList;
            return View(DbCheckEmp);
        }
        [HttpPost]
        public IActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {


                dbContext.Employees.Update(emp);

                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var empCheck = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (empCheck != null)
            {
                dbContext.Employees.Remove(empCheck);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //public IActionResult CountryList(int id)
        //{
        //    List<Employee> CountryData = dbContext.Employees.Where(e => e.Country.Id == id).ToList();
        //    return View(CountryData);
        //}
        //public IActionResult StateList(int id)
        //{
        //    List<Employee> StateData = dbContext.Employees.Where(e => e.State.Id == id).ToList();
        //    return View(StateData);

        //}
        //public IActionResult CityList(int id)
        //{
        //    List<Employee> CityData = dbContext.Employees.Where(e => e.City.Id == id).ToList();
        //    return View(CityData);
        //}
    }
}
