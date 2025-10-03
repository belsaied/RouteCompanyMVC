using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RouteCompany.BLL.DTOs.EmployeeDTOs;
using RouteCompany.BLL.Services.Classes;
using RouteCompany.BLL.Services.Interfaces;
using RouteCompany.DAL.Models.EmployeeModule;
using RouteCompany.DAL.Models.Shared;
using RouteCompany.PL.ViewModels;

namespace RouteCompany.PL.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeService, IHostEnvironment _env, ILogger<DepartmentController> _logger) : Controller
    {
        #region Index
        public IActionResult Index()
        {
            var employee = _employeeService.GetAllEmployees();
            return View(employee);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = _employeeService.CreateEmployee(new CreatedEmployeeDTO
                    {
                        Name = employeeVM.Name,
                        Age = employeeVM.Age,
                        Address = employeeVM.Address,
                        Salary = employeeVM.Salary,
                        IsActive = employeeVM.IsActive,
                        Email = employeeVM.Email,
                        PhoneNumber = employeeVM.PhoneNumber,
                        HiringDate = employeeVM.HiringDate,
                        Gender = employeeVM.Gender,
                        EmployeeType = employeeVM.EmployeeType,
                        DepartmentId = employeeVM.DepartmentId,

                    });

                    if (res > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError("", "Employee Can not be created");

                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Employee Can not be create {ex.Message}");


                    }
                    else
                    {
                        _logger.LogError($"Employee Can not be create {ex}");
                        return View("Error");
                    }
                }
            }

            return View(employeeVM);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            return View(employee);
        }
        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeedto = new EmployeeViewModel
            {

                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                DepartmentId = employee.DepartmentId,

            };
            return View(employeedto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employee)
        {
            if (!id.HasValue || id != employee.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var res = _employeeService.UpdateEmployee(new UpdatedEmployeeDTO
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Age = employee.Age,
                        Address = employee.Address,
                        Salary = employee.Salary,
                        IsActive = employee.IsActive,
                        Email = employee.Email,
                        PhoneNumber = employee.PhoneNumber,
                        HiringDate = employee.HiringDate,
                        Gender = employee.Gender,
                        EmployeeType = employee.EmployeeType,
                        DepartmentId = employee.DepartmentId,

                    });
                    if (res > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError("", "Employee Can not be updated");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Employee Can not be updated {ex.Message}");

                    }

                    else
                    {
                        _logger.LogError($"Employee Can not be updated {ex}");
                        return View("Error");
                    }
                }
            }
            return View(employee);
        }


        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool isDeleter = _employeeService.DeleteEmployee(id);
                if (isDeleter)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError("", "Employee Can not be deleted");

            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Employee Can not be deleted {ex.Message}");
                    ModelState.AddModelError("", "Employee Can not be deleted");

                }
                else
                {
                    _logger.LogError($"Employee Can not be deleted {ex}");
                    return View("Error");
                }
            }

            return RedirectToAction(nameof(Delete), new { id });

        }
        #endregion
    }
}