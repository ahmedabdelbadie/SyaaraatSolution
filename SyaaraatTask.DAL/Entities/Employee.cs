namespace SyaaraatTask.DAL.Entities;

public class Employee
{

    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
    public string Manager_Name { get; set; }
    public int DepartmentId { get; set; }

    public Department Department { get; set; }

    public ICollection<EmployeeTask> EmployeeTasks { get; set; }
}
