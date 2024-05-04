using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? RoomNumber { get; set; }

    public int? HostelId { get; set; }

    public DateOnly DateOfAdmission { get; set; }

    public virtual ICollection<Allotment> Allotments { get; set; } = new List<Allotment>();

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();

    public virtual Hostel? Hostel { get; set; }

    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();

    public virtual ICollection<Medical> Medicals { get; set; } = new List<Medical>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room? RoomNumberNavigation { get; set; }

    public virtual ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}
