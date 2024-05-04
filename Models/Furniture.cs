using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Furniture
{
    public int FurnitureId { get; set; }

    public int? StudentId { get; set; }

    public string FurnitureName { get; set; } = null!;

    public string Quality { get; set; } = null!;

    public DateOnly DateOfIssue { get; set; }

    public DateOnly DateOfBack { get; set; }

    public virtual Student? Student { get; set; }
}
