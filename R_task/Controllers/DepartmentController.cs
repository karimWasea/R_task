//using DataACesslayer;

//using IReprosastory;

//using Microsoft.AspNetCore.Mvc;

//using R_task.Models;

//using ReprestoryServess;

//using System.Diagnostics;

//using ViewModel;

//namespace R_task.Controllers
//{
//    public class DepartmentController : Controller
//    {
//        private readonly UnitOfWork _UnitOfWork;

//        public DepartmentController(UnitOfWork UnitOfWork)
//        {
//            _UnitOfWork = UnitOfWork;
//        }


//        [HttpGet]
//        // Action to display details of a department
//        public async Task<IActionResult> Index()
//        {
//            var departments = await _UnitOfWork._departmentService.GetAllDepartmentsAsync();
//            return View(departments);

//        }

//        [HttpGet]
//        // Action to display details of a department
//        public async Task<IActionResult> Details(int id)
//        {
//            var department = await _UnitOfWork._departmentService.GetDepartmentByIdAsync(id);

//            if (department == null)
//            {
//                return NotFound();
//            }

//            // Fetch the parent departments and sub-departments
//            var parents = await _UnitOfWork._departmentService.GetParentDepartmentsAsync(id);
//            var subDepartments = await _UnitOfWork._departmentService.GetSubDepartmentsAsync(id);

//            var model = new DepartmentDetailsViewModel
//            {
//                Department = department,
//                SubDepartments = subDepartments,
//                ParentDepartments = parents
//            };

//            return View(model);
//        }

//}

//    }


using Microsoft.AspNetCore.Mvc;
using ReprestoryServess;
using ViewModel;

public class DepartmentController : Controller
{
    private readonly UnitOfWork _UnitOfWork;

    public DepartmentController(UnitOfWork UnitOfWork)
    {
        _UnitOfWork = UnitOfWork;
    }

    [HttpGet]
    // Action to display all departments
    public async Task<IActionResult> Index()
    {
        var departments = await _UnitOfWork._departmentService.GetAllDepartmentsAsync();
        return View(departments);
    }

    [HttpGet]
    // Action to display details of a department
    public async Task<IActionResult> Details(int id)
    {
        var department = await _UnitOfWork._departmentService.GetDepartmentByIdAsync(id);

        if (department == null)
        {
            return NotFound();
        }

        // Fetch the parent departments and sub-departments
        var parents = await _UnitOfWork._departmentService.GetParentDepartmentsAsync(id);
        var subDepartments = await _UnitOfWork._departmentService.GetSubDepartmentsAsync(id);

        var model = new DepartmentDetailsViewModel
        {
            Department = department,
            SubDepartments = subDepartments,
            ParentDepartments = parents
        };

        return View(model);
    }

    [HttpGet]
    // Action to display parent departments of a department
    public async Task<IActionResult> ParentDepartments(int id)
    {
        var parentDepartments = await _UnitOfWork._departmentService.GetParentDepartmentsAsync(id);
        return View(parentDepartments);
    }

    [HttpGet]
    // Action to display sub-departments of a department
    public async Task<IActionResult> SubDepartments(int id)
    {
        var subDepartments = await _UnitOfWork._departmentService.GetSubDepartmentsAsync(id);
        return View(subDepartments);
    }
}