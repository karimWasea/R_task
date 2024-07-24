 

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ReprestoryServess;

using System.Data.Entity.Infrastructure;

using ViewModel;

public class DepartmentController : Controller
{
    private readonly UnitOfWork _UnitOfWork;

    public DepartmentController(UnitOfWork UnitOfWork)
    {
        _UnitOfWork = UnitOfWork;
    }

  

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var departments = await _UnitOfWork. _departmentService.GetDepartmentsAsync();
            return View(departments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _UnitOfWork._departmentService.GetDepartmentByIdAsync(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["ParentDepartmentId"] = new SelectList(_UnitOfWork._departmentService.GetDepartmentsAsync().Result, "Id", "Name");
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Logo,ParentDepartmentId")] DepartmentVm departmentVm)
        {
            if (ModelState.IsValid)
            {
                await _UnitOfWork._departmentService.CreateDepartmentAsync(departmentVm);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentDepartmentId"] = new SelectList(_UnitOfWork._departmentService.GetDepartmentsAsync().Result, "Id", "Name", departmentVm.ParentDepartmentId);
            return View(departmentVm);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _UnitOfWork._departmentService.GetDepartmentByIdAsync(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            ViewData["ParentDepartmentId"] = new SelectList(_UnitOfWork._departmentService.GetDepartmentsAsync().Result, "Id", "Name", department.ParentDepartmentId);
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,ParentDepartmentId")] DepartmentVm departmentVm)
        {
            if (id != departmentVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _UnitOfWork._departmentService.UpdateDepartmentAsync(departmentVm);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DepartmentExists(departmentVm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentDepartmentId"] = new SelectList(_UnitOfWork._departmentService.GetDepartmentsAsync().Result, "Id", "Name", departmentVm.ParentDepartmentId);
            return View(departmentVm);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _UnitOfWork._departmentService.GetDepartmentByIdAsync(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
 

        private async Task<bool> DepartmentExists(int id)
        {
            var department = await _UnitOfWork._departmentService.GetDepartmentByIdAsync(id);
            return department != null;
        }
    }
