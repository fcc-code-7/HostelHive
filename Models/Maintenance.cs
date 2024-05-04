using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Maintenance
{
    public int MaintenanceId { get; set; }

    public int? RoomNumber { get; set; }

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public DateOnly DateOfCompletion { get; set; }

    public virtual Room? RoomNumberNavigation { get; set; }
}
