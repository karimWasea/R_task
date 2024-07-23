using Microsoft.EntityFrameworkCore;

namespace DataACesslayer
{
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
            // Seed data for Department
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, Name = "HR", Logo = "hr-logo.png" },
                new Department { DepartmentID = 2, Name = "IT", Logo = "it-logo.png" },
                new Department { DepartmentID = 3, Name = "Finance", Logo = "finance-logo.png" }
            );

            // Seed data for SubDepartment
            modelBuilder.Entity<SubDepartment>().HasData(
                new SubDepartment { SubDepartmentID = 1, Name = "Recruitment", Logo = "recruitment-logo.png", DepartmentID = 1 },
                new SubDepartment { SubDepartmentID = 2, Name = "Employee Relations", Logo = "employee-relations-logo.png", DepartmentID = 1 },
                new SubDepartment { SubDepartmentID = 3, Name = "Software Development", Logo = "software-development-logo.png", DepartmentID = 2 },
                new SubDepartment { SubDepartmentID = 4, Name = "IT Support", Logo = "it-support-logo.png", DepartmentID = 2 },
                new SubDepartment { SubDepartmentID = 5, Name = "Accounting", Logo = "accounting-logo.png", DepartmentID = 3 },
                new SubDepartment { SubDepartmentID = 6, Name = "Budgeting", Logo = "budgeting-logo.png", DepartmentID = 3 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

