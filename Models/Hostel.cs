using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Hostel
{
    public int HostelId { get; set; }

    public string HostelName { get; set; } = null!;

    public string HostelLocation { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
