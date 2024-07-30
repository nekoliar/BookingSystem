﻿using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccess.Models;

public partial class MstMenu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual MstUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<MstRoleMenu> MstRoleMenus { get; set; } = new List<MstRoleMenu>();
}
