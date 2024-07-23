namespace ViewModel
{
    public class DepartmentDetailsViewModel
    {
        public DepartmentVm Department { get; set; }
        public List<DepartmentVm> SubDepartments { get; set; }
        public List<DepartmentVm> ParentDepartments { get; set; }
    }
}

