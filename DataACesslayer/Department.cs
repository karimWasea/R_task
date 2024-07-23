


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace DataACesslayer
{
   

  
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Logo { get; set; }

        public virtual ICollection<SubDepartment> SubDepartments { get; set; }

        // Self-referencing navigation property for parent department
        public int? ParentDepartmentID { get; set; }
        public virtual Department ParentDepartment { get; set; }
        public virtual ICollection<Department> ChildDepartments { get; set; }
    }

}
