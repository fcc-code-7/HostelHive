using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Room
{
    public int RoomNumber { get; set; }

    public string Type { get; set; } = null!;

    public int Capacity { get; set; }

    public string Availability { get; set; } = null!;

    public virtual ICollection<Allotment> Allotments { get; set; } = new List<Allotment>();

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
