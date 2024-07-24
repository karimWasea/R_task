using ViewModel;

namespace IReprosastory
{
    public interface IDepartmentService
    {
        Task<List<DepartmentVm>> GetDepartmentsAsync();
        Task<DepartmentVm> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(DepartmentVm departmentVm);
        Task UpdateDepartmentAsync(DepartmentVm departmentVm);
     }
}


