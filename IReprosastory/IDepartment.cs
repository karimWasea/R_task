using ViewModel;

namespace IReprosastory
{
    public interface IDepartmentService
    {
        Task<DepartmentVm> GetDepartmentByIdAsync(int id);
        Task<List<DepartmentVm>> GetAllDepartmentsAsync();
            Task<List<DepartmentVm>> GetParentDepartmentsAsync(int departmentId);
        Task<List<DepartmentVm>> GetSubDepartmentsAsync(int departmentId);
    }
}


