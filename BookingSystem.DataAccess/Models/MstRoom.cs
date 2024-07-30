using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccess.Models;

public partial class MstRoom
{
    public int RoomId { get; set; }

    public int LocationId { get; set; }

    public string RoomName { get; set; } = null!;

    public int Floor { get; set; }

    public string? Description { get; set; }

    public int Capacity { get; set; }

    public string RoomColor { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual MstLocation Location { get; set; } = null!;
}
