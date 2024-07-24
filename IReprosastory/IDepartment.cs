using ViewModel;

namespace IReprosastory
{
    public interface IDepartmentService
    {
        Task<List<DepartmentVm>> GetDepartmentsAsync();
        Task<DepartmentVm> GetDepartmentByIdAsync(int id);
        public bool DepartmentExists(DepartmentVm departmentVm);
        Task CreateDepartmentAsync(DepartmentVm departmentVm);
        Task UpdateDepartmentAsync(DepartmentVm departmentVm);
     }
}


