using System;
using System.Collections.Generic;

namespace HostelManagementSystem.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? StudentId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly PaymentDate { get; set; }

    public virtual Student? Student { get; set; }
}
