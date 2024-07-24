using DataACesslayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public static class StaticData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "HR", Logo = "hr-logo.png" },
                new Department { Id = 2, Name = "IT", Logo = "it-logo.png" },
                new Department { Id = 3, Name = "Finance", Logo = "finance-logo.png" },
                new Department { Id = 4, Name = "Recruitment", Logo = "recruitment-logo.png", ParentDepartmentId = 1 },
                new Department { Id = 5, Name = "Employee Relations", Logo = "employee-relations-logo.png", ParentDepartmentId = 1 },
                new Department { Id = 6, Name = "Software Development", Logo = "software-development-logo.png", ParentDepartmentId = 2 },
                new Department { Id = 7, Name = "IT Support", Logo = "it-support-logo.png", ParentDepartmentId = 2 },
                new Department { Id = 8, Name = "Accounting", Logo = "accounting-logo.png", ParentDepartmentId = 3 },
                new Department { Id = 9, Name = "Budgeting", Logo = "budgeting-logo.png", ParentDepartmentId = 3 },
                new Department { Id = 10, Name = "Campus Recruitment", Logo = "campus-recruitment-logo.png", ParentDepartmentId = 4 },
                new Department { Id = 11, Name = "Corporate Relations", Logo = "corporate-relations-logo.png", ParentDepartmentId = 5 }
            );
        }
    }
}
