﻿using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccess.Models;

public partial class MstBookingCode
{
    public int Id { get; set; }

    public string BookingCode { get; set; } = null!;

    public bool? Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }
}
