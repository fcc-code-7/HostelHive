using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int? StudentId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly TimeIn { get; set; }

    public TimeOnly TimeOut { get; set; }

    public virtual Student? Student { get; set; }
}
