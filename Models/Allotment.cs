using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Allotment
{
    public int AllotmentId { get; set; }

    public int? StudentId { get; set; }

    public int? RoomNumber { get; set; }

    public DateOnly AllotmentDate { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public virtual Room? RoomNumberNavigation { get; set; }

    public virtual Student? Student { get; set; }
}
