//using Microsoft.EntityFrameworkCore;

//namespace DataACesslayer
//{
//    public class ApplicationDBcontext : DbContext
//    {
//        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
//            : base(options)
//        {
//        }

//        public DbSet<Department> Departments { get; set; }
//        public DbSet<SubDepartment> SubDepartments { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Seed data for Department
//            modelBuilder.Entity<Department>().HasData(
//                new Department { DepartmentID = 1, Name = "HR", Logo = "hr-logo.png" },
//                new Department { DepartmentID = 2, Name = "IT", Logo = "it-logo.png" },
//                new Department { DepartmentID = 3, Name = "Finance", Logo = "finance-logo.png" }
//            );

//            // Seed data for SubDepartment
//            modelBuilder.Entity<SubDepartment>().HasData(
//                new SubDepartment { SubDepartmentID = 1, Name = "Recruitment", Logo = "recruitment-logo.png", DepartmentID = 1 },


//                new SubDepartment { SubDepartmentID = 2, Name = "Employee Relations", Logo = "employee-relations-logo.png", DepartmentID = 1 },
//                new SubDepartment { SubDepartmentID = 3, Name = "Software Development", Logo = "software-development-logo.png", DepartmentID = 2 },
//                new SubDepartment { SubDepartmentID = 4, Name = "IT Support", Logo = "it-support-logo.png", DepartmentID = 2 },
//                new SubDepartment { SubDepartmentID = 5, Name = "Accounting", Logo = "accounting-logo.png", DepartmentID = 3 },
//                new SubDepartment { SubDepartmentID = 6, Name = "Budgeting", Logo = "budgeting-logo.png", DepartmentID = 3 }
//            );

//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}


















using Microsoft.EntityFrameworkCore;

namespace DataACesslayer
{
    public static class StaticData
    {
        public static readonly Department[] Departments = new[]
        {
            new Department { DepartmentID = 1, Name = "HR", Logo = "hr-logo.png" },
            new Department { DepartmentID = 2, Name = "IT", Logo = "it-logo.png" },
            new Department { DepartmentID = 3, Name = "Finance", Logo = "finance-logo.png" }
        };

        public static readonly SubDepartment[] SubDepartments = new[]
        {
            new SubDepartment { SubDepartmentID = 1, Name = "Recruitment", Logo = "recruitment-logo.png", DepartmentID = 1 },
            new SubDepartment { SubDepartmentID = 2, Name = "Employee Relations", Logo = "employee-relations-logo.png", DepartmentID = 1 },
            new SubDepartment { SubDepartmentID = 3, Name = "Software Development", Logo = "software-development-logo.png", DepartmentID = 2 },
            new SubDepartment { SubDepartmentID = 4, Name = "IT Support", Logo = "it-support-logo.png", DepartmentID = 2 },
            new SubDepartment { SubDepartmentID = 5, Name = "Accounting", Logo = "accounting-logo.png", DepartmentID = 3 },
            new SubDepartment { SubDepartmentID = 6, Name = "Budgeting", Logo = "budgeting-logo.png", DepartmentID = 3 },

            // Add sub-departments with parent-child relationships
            new SubDepartment { SubDepartmentID = 7, Name = "Campus Recruitment", Logo = "campus-recruitment-logo.png", DepartmentID = 1, ParentID = 1 },
            new SubDepartment { SubDepartmentID = 8, Name = "Corporate Relations", Logo = "corporate-relations-logo.png", DepartmentID = 1, ParentID = 2 }
        };
    }
 
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<SubDepartment> SubDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the parent-child relationship for SubDepartments
            modelBuilder.Entity<SubDepartment>()
                .HasOne(s => s.Parent)
                .WithMany(s => s.SubDepartments)
                .HasForeignKey(s => s.ParentID);

            // Seed data for Department
            modelBuilder.Entity<Department>().HasData(StaticData.Departments);

            // Seed data for SubDepartment
            modelBuilder.Entity<SubDepartment>().HasData(StaticData.SubDepartments);

            base.OnModelCreating(modelBuilder);
        }
    }
}

