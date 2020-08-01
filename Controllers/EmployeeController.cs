using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Lib.Core.Domain;
using Lib.Service.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace WebAppCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        public IActionResult List()
        {
            var list = _employeeServices.GetEmployeeList();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDetail model)
        {
            if (ModelState.IsValid)
            {
                bool response = _employeeServices.AddEmployee(model);

                if (response)
                {
                    return RedirectToAction("List");
                }
            }

            return View();
        }

        public IActionResult Edit(int Id)
        {
            var model = _employeeServices.GetEmployeeById(Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeDetail model)
        {
            var response = _employeeServices.EditEmployee(model);

            if (response)
            {
                return RedirectToAction("List");
            }


            return View();
        }

        public IActionResult Delete(int Id)
        {
            var response = _employeeServices.DeleteEmployee(Id);

            return RedirectToAction("List");
        }

    }
}
