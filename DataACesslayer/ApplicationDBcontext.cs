using DataACesslayer;

using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the parent-child relationship for Departments
            modelBuilder.Entity<Department>()
                .HasOne(d => d.ParentDepartment)
                .WithMany(d => d.SubDepartments)
                .HasForeignKey(d => d.ParentDepartmentId);

            // Seed data for Department
            StaticData.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
