


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace DataACesslayer
{


    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public int? ParentDepartmentId { get; set; }
        public Department ParentDepartment { get; set; }

        public ICollection<Department> SubDepartments { get; set; } = new List<Department>();
    }

}
