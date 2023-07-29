using Microsoft.EntityFrameworkCore;
using SyaaraatTask.DAL.Entities;

namespace SyaaraatTask.DAL.DataContext;

public class AspNetCoreTasksDbContext : DbContext
{
    public AspNetCoreTasksDbContext(DbContextOptions<AspNetCoreTasksDbContext> options)
        : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<AssignTask> Task { get; set; }
    public DbSet<EmployeeTask> EmployeeTask { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
           .HasOne<Department>(s => s.Department)
           .WithMany(g => g.Employees)
           .HasForeignKey(s => s.DepartmentId)
           .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<EmployeeTask>().HasKey(sc => new { sc.EmployeeId, sc.TaskId });
        modelBuilder.Entity<EmployeeTask>()
            .HasOne<Employee>(sc => sc.Employee)
            .WithMany(s => s.EmployeeTasks)
            .HasForeignKey(sc => sc.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<EmployeeTask>()
            .HasOne<AssignTask>(sc => sc.Task)
            .WithMany(s => s.EmployeeTasks)
            .HasForeignKey(sc => sc.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    UserId = 1,
                    Email = "Badea@admin.org",
                    Password = "123",
                    Name = "Ahmed",

                }
            );

    }
}
