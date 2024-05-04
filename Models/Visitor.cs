using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Visitor
{
    public int VisitorId { get; set; }

    public int? StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Purpose { get; set; } = null!;

    public DateOnly DateOfVisit { get; set; }

    public TimeOnly TimeIn { get; set; }

    public TimeOnly TimeOut { get; set; }

    public virtual Student? Student { get; set; }
}
