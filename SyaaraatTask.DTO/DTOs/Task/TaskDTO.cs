namespace SyaaraatTask.DTO.DTOs;

public class TaskDTO
{
    public int TaskId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public List<EmployeeDTO> EmployeeDTOs { get; set; }
}
