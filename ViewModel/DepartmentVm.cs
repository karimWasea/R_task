namespace ViewModel
{
    public class DepartmentVm
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<DepartmentVm> SubDepartments { get; set; }
    }
}
