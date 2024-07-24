namespace ViewModel
{
    public class DepartmentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string ParentDepartmentName { get; set; }
        public List<DepartmentVm> SubDepartments { get; set; } = new List<DepartmentVm>();
    }

}
