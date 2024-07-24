using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModel
{
    public class DepartmentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string ParentDepartmentName { get; set; } = string.Empty;    
        public List<DepartmentVm> SubDepartments { get; set; } = new List<DepartmentVm>();
        public IEnumerable<SelectListItem>? ALLParentDepartment { get; set; } = Enumerable.Empty<SelectListItem>();
    }

}
