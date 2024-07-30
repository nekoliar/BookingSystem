using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccess.Models;

public partial class MstUser
{
    public int Id { get; set; }

    public string LoginName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual ICollection<MstMenu> MstMenus { get; set; } = new List<MstMenu>();

    public virtual MstRole? Role { get; set; }
}
