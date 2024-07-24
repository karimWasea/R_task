using DataAccessLayer;

using DataACesslayer;

using IReprosastory;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

using System;
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
        public async Task<List<DepartmentVm>> GetDepartmentsAsync()
        {
            var departments = await _context.Departments
                .Include(d => d.SubDepartments)
                .ToListAsync();

            return departments.Select(d => new DepartmentVm
            {
                Id = d.Id,
                Name = d.Name,
                Logo = d.Logo,
                ParentDepartmentId = d.ParentDepartmentId,
                ParentDepartmentName = d.ParentDepartment?.Name,
                SubDepartments = d.SubDepartments.Select(sd => new DepartmentVm
                {
                    Id = sd.Id,
                    Name = sd.Name,
                    Logo = sd.Logo,
                    ParentDepartmentId = sd.ParentDepartmentId,
                    ParentDepartmentName = sd.ParentDepartment?.Name
                }).ToList()
            }).ToList();
        }

        public async Task<DepartmentVm> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments
                .Include(d => d.SubDepartments)
                .Include(d => d.ParentDepartment)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null) return null;

            return new DepartmentVm
            {
                Id = department.Id,
                Name = department.Name,
                Logo = department.Logo,
                ParentDepartmentId = department.ParentDepartmentId,
                ParentDepartmentName = department.ParentDepartment?.Name,
                SubDepartments = department.SubDepartments.Select(sd => new DepartmentVm
                {
                    Id = sd.Id,
                    Name = sd.Name,
                    Logo = sd.Logo,
                    ParentDepartmentId = sd.ParentDepartmentId,
                    ParentDepartmentName = sd.ParentDepartment?.Name
                }).ToList()
            };
        }

        public async Task CreateDepartmentAsync(DepartmentVm departmentVm)
        {
            var department = new Department
            {
                Name = departmentVm.Name,
                Logo = departmentVm.Logo,
                ParentDepartmentId = departmentVm.ParentDepartmentId
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(DepartmentVm departmentVm)
        {
            var department = await _context.Departments.FindAsync(departmentVm.Id);

            if (department == null) return;

            department.Name = departmentVm.Name;
            department.Logo = departmentVm.Logo;
            department.ParentDepartmentId = departmentVm.ParentDepartmentId;

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null) return;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }

}