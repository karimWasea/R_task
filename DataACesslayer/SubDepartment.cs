using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataACesslayer
{
    public class SubDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubDepartmentID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Logo { get; set; }

        public int? ParentID { get; set; }
        public virtual SubDepartment Parent { get; set; }
        public virtual ICollection<SubDepartment> SubDepartments { get; set; } = new List<SubDepartment>();

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }

}
