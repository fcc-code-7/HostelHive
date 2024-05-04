using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementSystem.Models;

public partial class HmsContext : DbContext
{
    public HmsContext()
    {
    }

    public HmsContext(DbContextOptions<HmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allotment> Allotments { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Furniture> Furnitures { get; set; }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

 

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Medical> Medicals { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allotment>(entity =>
        {
            entity.HasKey(e => e.AllotmentId).HasName("PK__Allotmen__9D7FF0197881FF27");

            entity.ToTable("Allotment");

            entity.Property(e => e.AllotmentId)
                .ValueGeneratedNever()
                .HasColumnName("Allotment_ID");
            entity.Property(e => e.AllotmentDate).HasColumnName("Allotment_Date");
            entity.Property(e => e.ReleaseDate).HasColumnName("Release_Date");
            entity.Property(e => e.RoomNumber).HasColumnName("Room_Number");
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Allotments)
                .HasForeignKey(d => d.RoomNumber)
                .HasConstraintName("FK__Allotment__Room___4E88ABD4");

            entity.HasOne(d => d.Student).WithMany(p => p.Allotments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Allotment__Stude__4D94879B");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__57FA4934EE9A5749");

            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceId)
                .ValueGeneratedNever()
                .HasColumnName("Attendance_ID");
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.TimeIn).HasColumnName("Time_In");
            entity.Property(e => e.TimeOut).HasColumnName("Time_Out");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Attendanc__Stude__5EBF139D");
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__Complain__0C536DA6417248E0");

            entity.ToTable("Complaint");

            entity.Property(e => e.ComplaintId)
                .ValueGeneratedNever()
                .HasColumnName("Complaint_ID");
            entity.Property(e => e.DateOfSubmission).HasColumnName("Date_of_Submission");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.Staff).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Complaint__Staff__5629CD9C");

            entity.HasOne(d => d.Student).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Complaint__Stude__5535A963");
        });

        modelBuilder.Entity<Furniture>(entity =>
        {
            entity.HasKey(e => e.FurnitureId).HasName("PK__Furnitur__BDCCF3E542099671");

            entity.ToTable("Furniture");

            entity.Property(e => e.FurnitureId)
                .ValueGeneratedNever()
                .HasColumnName("Furniture_ID");
            entity.Property(e => e.DateOfBack).HasColumnName("Date_of_Back");
            entity.Property(e => e.DateOfIssue).HasColumnName("Date_of_Issue");
            entity.Property(e => e.FurnitureName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Furniture_Name");
            entity.Property(e => e.Quality)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.Student).WithMany(p => p.Furnitures)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Furniture__Stude__6477ECF3");
        });

        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId).HasName("PK__Hostel__6FB43682E17FF0AD");

            entity.ToTable("Hostel");

            entity.Property(e => e.HostelId)
                .ValueGeneratedNever()
                .HasColumnName("Hostel_ID");
            entity.Property(e => e.HostelLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Hostel_Location");
            entity.Property(e => e.HostelName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Hostel_Name");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__Leave__D54C3A606C39E0B5");

            entity.ToTable("Leave");

            entity.Property(e => e.LeaveId)
                .ValueGeneratedNever()
                .HasColumnName("Leave_ID");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.Student).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Leave__Student_I__619B8048");
        });


        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PK__Maintena__CCC49F9FC7C666E1");

            entity.ToTable("Maintenance");

            entity.Property(e => e.MaintenanceId)
                .ValueGeneratedNever()
                .HasColumnName("Maintenance_ID");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DateOfCompletion).HasColumnName("Date_of_Completion");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoomNumber).HasColumnName("Room_Number");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.RoomNumber)
                .HasConstraintName("FK__Maintenan__Room___59063A47");
        });

        modelBuilder.Entity<Medical>(entity =>
        {
            entity.HasKey(e => e.MedicalId).HasName("PK__Medical__F9E5648EDE3DEB9B");

            entity.ToTable("Medical");

            entity.Property(e => e.MedicalId)
                .ValueGeneratedNever()
                .HasColumnName("Medical_ID");
            entity.Property(e => e.Illness)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.Treatment)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Medicals)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Medical__Student__6754599E");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__DA6C7FE1C743192A");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("Payment_ID");
            entity.Property(e => e.Amount)
                .HasDefaultValue(15000m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DueDate).HasColumnName("Due_Date");
            entity.Property(e => e.PaymentDate).HasColumnName("Payment_Date");
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.Student).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Payment__Student__5165187F");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNumber).HasName("PK__Room__353A906EA2736FDA");

            entity.ToTable("Room");

            entity.Property(e => e.RoomNumber)
                .ValueGeneratedNever()
                .HasColumnName("Room_Number");
            entity.Property(e => e.Availability)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__32D1F3C378B2CBB0");

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D1053494E1CC2A").IsUnique();

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("Staff_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfJoining).HasColumnName("Date_of_Joining");
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HostelId).HasColumnName("Hostel_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Hostel).WithMany(p => p.Staff)
                .HasForeignKey(d => d.HostelId)
                .HasConstraintName("FK__Staff__Hostel_ID__4AB81AF0");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__A2F4E9AC7AF5847F");

            entity.ToTable("Student");

            entity.HasIndex(e => e.Email, "UQ__Student__A9D105346F3036E5").IsUnique();

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("Student_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfAdmission).HasColumnName("Date_of_Admission");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HostelId).HasColumnName("Hostel_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoomNumber).HasColumnName("Room_Number");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Students)
                .HasForeignKey(d => d.HostelId)
                .HasConstraintName("FK__Student__Hostel___3D5E1FD2");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.RoomNumber)
                .HasConstraintName("FK__Student__Room_Nu__3C69FB99");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.VisitorId).HasName("PK__Visitor__E16AB2AD886879A7");

            entity.ToTable("Visitor");

            entity.Property(e => e.VisitorId)
                .ValueGeneratedNever()
                .HasColumnName("Visitor_ID");
            entity.Property(e => e.DateOfVisit).HasColumnName("Date_of_Visit");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Purpose)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.TimeIn).HasColumnName("Time_In");
            entity.Property(e => e.TimeOut).HasColumnName("Time_Out");

            entity.HasOne(d => d.Student).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Visitor__Student__5BE2A6F2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
