using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Leave
{
    public int LeaveId { get; set; }

    public int? StudentId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Reason { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
