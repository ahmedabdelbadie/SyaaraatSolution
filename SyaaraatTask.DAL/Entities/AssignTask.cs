namespace SyaaraatTask.DAL.Entities;

public class AssignTask
{
    public int AssignTaskId { get; set; }
    public int TaskId { get; set; }
    public string Name { get; set; }
    public TaskStatus Status { get; set; }

    public ICollection<EmployeeTask> EmployeeTasks { get; set; }
}
public enum TaskStatus
{
    New,
    Proccess,
    Completed

}
