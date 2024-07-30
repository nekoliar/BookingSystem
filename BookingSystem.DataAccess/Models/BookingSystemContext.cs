using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.DataAccess.Models;

public partial class BookingSystemContext : DbContext
{
    public BookingSystemContext()
    {
    }

    public BookingSystemContext(DbContextOptions<BookingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MstBookingCode> MstBookingCodes { get; set; }

    public virtual DbSet<MstLocation> MstLocations { get; set; }

    public virtual DbSet<MstMenu> MstMenus { get; set; }

    public virtual DbSet<MstRole> MstRoles { get; set; }

    public virtual DbSet<MstRoleMenu> MstRoleMenus { get; set; }

    public virtual DbSet<MstRoom> MstRooms { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BookingSystem;Username=postgres;Password=indocyber");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MstBookingCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstBookingCode_pkey");

            entity.ToTable("MstBookingCode");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.BookingCode).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp(6) without time zone");
        });

        modelBuilder.Entity<MstLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstLocation_pkey");

            entity.ToTable("MstLocation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.LocationName).HasMaxLength(150);
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp(6) without time zone");
        });

        modelBuilder.Entity<MstMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstMenu_pkey");

            entity.ToTable("MstMenu");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MstMenus)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreatedBy_MstMenu");
        });

        modelBuilder.Entity<MstRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("MstRole");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp(6) without time zone");
        });

        modelBuilder.Entity<MstRoleMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstRoleMenu_pkey");

            entity.ToTable("MstRoleMenu");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Menu).WithMany(p => p.MstRoleMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuID_MstRoleMenu");

            entity.HasOne(d => d.Role).WithMany(p => p.MstRoleMenus)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleID_MstRoleMenu");
        });

        modelBuilder.Entity<MstRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("MstRoom_pkey");

            entity.ToTable("MstRoom");

            entity.Property(e => e.RoomId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("RoomID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasPrecision(6);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RoomColor).HasMaxLength(150);
            entity.Property(e => e.RoomName).HasMaxLength(150);
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Location).WithMany(p => p.MstRooms)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationID_MstRoom");
        });

        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("MstUser");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LoginName).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(8000);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Role).WithMany(p => p.MstUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("UserRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
