using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Complaint
{
    public int ComplaintId { get; set; }

    public int? StudentId { get; set; }

    public int? StaffId { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly DateOfSubmission { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual Student? Student { get; set; }
}
