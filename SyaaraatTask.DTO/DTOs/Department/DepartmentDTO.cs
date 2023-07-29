namespace SyaaraatTask.DTO.DTOs;

public class DepartmentDTO
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public List<EmployeeDTO> EmployeeDTOs { get; set; }
}
