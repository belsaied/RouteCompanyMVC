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
    public class EmployeeController(IEmployeeServices _employeeService,IHostEnvironment _env,ILogger<DepartmentController> _logger) : Controller
    {
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello to Department Index ";
            var employee = _employeeService.GetAllEmployees();
            return View(employee);
        }
        #endregion
        #region Create (Get/Post)
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // last modification to allow partial view to attach the department after enabling the relationship.
                    var employee = _employeeService.CreateEmployee(new CreatedEmployeeDTO()
                    {
                        Name= employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Salary=employeeViewModel.Salary,
                        Address=employeeViewModel.Address,
                        IsActive=employeeViewModel.IsActive,
                        DepartmentId=employeeViewModel.DepartmentId,
                        Email=employeeViewModel.Email,
                        EmployeeType=employeeViewModel.EmployeeType,
                        Gender=employeeViewModel.Gender,
                        PhoneNumber=employeeViewModel.PhoneNumber,

                    });
                    if (employee > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee can't be created");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Employee can't be created {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Employee can't be created because :{ex}");
                        return View("ErrorView", ex);
                    }
                }
            }

            return View(employeeViewModel);
        }
        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            return (employee is null) ? NotFound() : View(employee);
        }
        #endregion
        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeeVM = new EmployeeViewModel()
            {
                
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Email = employee.Email,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),  // Here i don't use ToString because i cast from Enum to string.
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
            };
            return View(employeeVM);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeViewModel)
        {
            if (!id.HasValue ) return BadRequest();
            if (!ModelState.IsValid)
            {
              return View(employeeViewModel);
            }
           
            try
            {
                int result = _employeeService.UpdateEmployee(new UpdatedEmployeeDTO()
                {
                    Id = id.Value,
                    Address=employeeViewModel.Address,
                    Age=employeeViewModel.Age,
                    IsActive=employeeViewModel.IsActive,
                    Gender=employeeViewModel.Gender,
                    Email=employeeViewModel.Email,
                    EmployeeType=employeeViewModel.EmployeeType,
                    Name=employeeViewModel.Name,
                    HiringDate=employeeViewModel.HiringDate,
                    Salary=employeeViewModel.Salary,
                    PhoneNumber=employeeViewModel.PhoneNumber,
                    DepartmentId=employeeViewModel.DepartmentId,
                });
                if (result > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't be updated");
                    return View(employeeViewModel);
                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Employee can't be Updated {ex.Message}");
                }
                else
                {
                    _logger.LogError($"Employee can't be updated because {ex}");
                    return View("ErrorView", ex);
                }
            }
            return View(employeeViewModel);
        }
        #endregion
        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id==0) return BadRequest();
            try
            {
                bool isDeleted = _employeeService.DeleteEmployee(id);
                if(isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't be Deleted");
                }
            }
            catch(Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Employee can't be Deleted {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Employee Can't be Deleted");
                }
                else
                {
                    _logger.LogError($"Employee Can't be Deleted because {ex}");
                    return View("ErrorView", ex);
                }
               
            }
            return RedirectToAction(nameof(Delete), new { id });
        }
        #endregion
    }
}
