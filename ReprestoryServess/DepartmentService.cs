using DataACesslayer;

using IReprosastory;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ViewModel;

namespace ReprestoryServess
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDBcontext _context;

        public DepartmentService(ApplicationDBcontext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentVm>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            var departmentVms = departments.Select(d => new DepartmentVm
            {
                DepartmentID = d.DepartmentID,
                Name = d.Name,
                Logo = d.Logo

            }).ToList();

            return departmentVms;
        }

        public async Task<DepartmentVm> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments
                .Include(d => d.SubDepartments)
                .ThenInclude(sd => sd.SubDepartments)
                .Include(d => d.ChildDepartments) // Include child departments if needed
                .SingleOrDefaultAsync(d => d.DepartmentID == id);

            return department == null ? null : ToDepartmentVm(department);
        }

        public async Task<List<DepartmentVm>> GetParentDepartmentsAsync(int departmentId)
        {
            var department = await _context.Departments
                .Include(d => d.ParentDepartment) // Ensure ParentDepartment is included
                .SingleOrDefaultAsync(d => d.DepartmentID == departmentId);

            var parents = new List<DepartmentVm>();
            while (department != null)
            {
                parents.Add(ToDepartmentVm(department));
                department = await _context.Departments
                    .SingleOrDefaultAsync(d => d.DepartmentID == department.ParentDepartmentID); // Access ParentDepartmentID
            }
            parents.Reverse();
            return parents;
        }

        public async Task<List<DepartmentVm>> GetSubDepartmentsAsync(int departmentId)
        {
            var department = await _context.Departments
                .Include(d => d.SubDepartments)
                .SingleOrDefaultAsync(d => d.DepartmentID == departmentId);

            return department?.SubDepartments
                .Select(sd => ToSubDepartmentVm(sd))
                .ToList() ?? new List<DepartmentVm>();
        }

        private DepartmentVm ToDepartmentVm(Department department)
        {
            return new DepartmentVm
            {
                DepartmentID = department.DepartmentID,
                Name = department.Name,
                Logo = department.Logo,
                SubDepartments = department.SubDepartments?.Select(sd => ToSubDepartmentVm(sd)).ToList()
            };
        }

        private DepartmentVm ToSubDepartmentVm(SubDepartment subDepartment)
        {
            return new DepartmentVm
            {
                DepartmentID = subDepartment.SubDepartmentID,
                Name = subDepartment.Name,
                Logo = subDepartment.Logo
            };
        }
    }
}




























