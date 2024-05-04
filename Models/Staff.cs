using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? HostelId { get; set; }

    public string Designation { get; set; } = null!;

    public DateOnly DateOfJoining { get; set; }

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual Hostel? Hostel { get; set; }
}
