using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccess.Models;

public partial class MstLocation
{
    public int Id { get; set; }

    public string LocationName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual ICollection<MstRoom> MstRooms { get; set; } = new List<MstRoom>();
}
