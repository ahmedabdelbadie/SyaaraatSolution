﻿namespace SyaaraatTask.DAL.Entities;

public class EmployeeTask
{
    public int TaskId { get; set; }
    public AssignTask Task { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
