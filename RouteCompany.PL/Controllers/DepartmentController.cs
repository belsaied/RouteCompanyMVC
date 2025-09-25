using Microsoft.AspNetCore.Mvc;
using RouteCompany.BLL.DTOs.DepartmentDTOs;
using RouteCompany.BLL.Services.Classes;
using RouteCompany.BLL.Services.Interfaces;
using RouteCompany.PL.ViewModels;

namespace RouteCompany.PL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService , 
        IWebHostEnvironment _env , ILogger<DepartmentController> _logger) : Controller
    {
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAllDepartments();
            return View(department);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartementDTO departementDTO)
        {
            // Check if the model is valid or not :
            if(ModelState.IsValid)
            {
                try
                {
                    int result = _departmentService.AddDepartment(departementDTO);
                    if(result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(string.Empty, "Department Can't be Created");
                    
                }
                catch (Exception ex)
                {
                    // Log Error of the Development Env => console.
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department Can't be created because {ex.Message}");
                         // stay in this view .
                    }
                    else
                    {
                        _logger.LogError($"Department Can't be created because {ex}");
                        return View("ErrorView",ex);   // I don't have it yet but the catch will not be logged because it's the happy scenario.
                    }

                }
            }
            return View(departementDTO);
        }

        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();  // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }
        #endregion
        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();  // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            var departmentVM = new DepartmentEditVM()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreatedOn.HasValue ? department.CreatedOn.Value : default,
            };
            return View(departmentVM);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id ,DepartmentEditVM departmentEditVM)
        {
            if (!ModelState.IsValid) return View(departmentEditVM);

            try
                {
                    if (!id.HasValue) return BadRequest();
                    var UpdatedDeptDto = new UpdateDepartmentDTO()
                    {
                        Id = id.Value,
                        Code = departmentEditVM.Code,
                        Name = departmentEditVM.Name,
                        Description = departmentEditVM.Description,
                        CreatedOn = departmentEditVM.CreatedOn,
                    };
                    int result = _departmentService.UpdateDepartment(UpdatedDeptDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't be Updated");
                        return View(departmentEditVM);
                    }
                }
                catch (Exception ex)
                {
                    // Log Error of the Development Env => console.
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department Can't be created because {ex.Message}");
                        return View(departmentEditVM);
                        // stay in this view .
                    }
                    else
                    {
                        _logger.LogError($"Department Can't be created because {ex}");
                        return View("ErrorView",ex);   // I don't have it yet but the catch will not be logged because it's the happy scenario.
                    }

                }
                
            
            

        }
        #endregion
        #region Delete
        // Get => Render View
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View (department);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool IsDeleted = _departmentService.DeleteDepartment(id);
                if(IsDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department can't be Deleted");
                    
                }
            }
            catch (Exception ex)
            {
                // Log Error of the Development Env => console.
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Department Can't be created because {ex.Message}");
                    // stay in this view .
                }
                else
                {
                    _logger.LogError($"Department Can't be created because {ex}");
                    return View("ErrorView", ex);   // I don't have it yet but the catch will not be logged because it's the happy scenario.
                }

            }
            return RedirectToAction(nameof(Index), new { id });
        }
        #endregion
    }
}
