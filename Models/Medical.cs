using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Medical
{
    public int MedicalId { get; set; }

    public int? StudentId { get; set; }

    public string Illness { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Treatment { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
