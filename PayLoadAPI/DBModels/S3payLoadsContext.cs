using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PayLoadAPI.DBModels;

public partial class S3payLoadsContext : DbContext
{
    public S3payLoadsContext()
    {
    }

    public S3payLoadsContext(DbContextOptions<S3payLoadsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeviceInfo> DeviceInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M3571U2\\SQLEXPRESS2019;Database=S3PayLoads;user=sa;password=saSQL2019;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceInfo>(entity =>
        {
            entity.HasKey(e => e.DeviceId);

            entity.ToTable("device_info");

            entity.Property(e => e.DeviceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("device_id");
            entity.Property(e => e.ActivePowerControl).HasColumnName("active_power_control");
            entity.Property(e => e.DataType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("data_type");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("device_name");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("device_type");
            entity.Property(e => e.FirmwareVersion).HasColumnName("firmware_version");
            entity.Property(e => e.FullPowerMode).HasColumnName("full_power_mode");
            entity.Property(e => e.GroupId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("group_id");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.MessageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("message_type");
            entity.Property(e => e.Occupancy).HasColumnName("occupancy");
            entity.Property(e => e.StateChanged).HasColumnName("state_changed");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
