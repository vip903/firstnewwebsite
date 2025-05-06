using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using corevipul1.Models;

namespace corevipul1.Data;

public partial class Corevipul1Context : DbContext
{
    public Corevipul1Context()
    {
    }

    public Corevipul1Context(DbContextOptions<Corevipul1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblcity> Tblcities { get; set; }

    public virtual DbSet<Tblcountry> Tblcountries { get; set; }

    public virtual DbSet<Tblemployee> Tblemployees { get; set; }

    public virtual DbSet<Tblgender> Tblgenders { get; set; }

    public virtual DbSet<Tblhobby> Tblhobbies { get; set; }

    public virtual DbSet<Tblstate> Tblstates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=VIPULPRAJAPATI\\SQLEXPRESS; database=corevipul1; trusted_connection=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblcity>(entity =>
        {
            entity.HasKey(e => e.Zid).HasName("PK__tblcity__30B369300AD2A005");

            entity.ToTable("tblcity");

            entity.Property(e => e.Zid).HasColumnName("zid");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Zname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("zname");
        });

        modelBuilder.Entity<Tblcountry>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__tblcount__D837D05F03317E3D");

            entity.ToTable("tblcountry");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cname");
        });

        modelBuilder.Entity<Tblemployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblemplo__3213E83F7F60ED59");

            entity.ToTable("tblemployee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Datetime)
                .HasMaxLength(50)
                .HasColumnName("datetime");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Hobbies)
                .HasMaxLength(50)
                .HasColumnName("hobbies");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.State).HasColumnName("state");
        });

        modelBuilder.Entity<Tblgender>(entity =>
        {
            entity.HasKey(e => e.Gid).HasName("PK__tblgende__DCD80EF80EA330E9");

            entity.ToTable("tblgender");

            entity.Property(e => e.Gid).HasColumnName("gid");
            entity.Property(e => e.Gname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gname");
        });

        modelBuilder.Entity<Tblhobby>(entity =>
        {
            entity.HasKey(e => e.Hid).HasName("PK__tblhobbi__DF101B011273C1CD");

            entity.ToTable("tblhobbies");

            entity.Property(e => e.Hid).HasColumnName("hid");
            entity.Property(e => e.Hname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hname");
        });

        modelBuilder.Entity<Tblstate>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__tblstate__DDDFDD3607020F21");

            entity.ToTable("tblstate");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<corevipul1.Models.Tblemployee> tblemployees { get; set; } = default!;

public DbSet<corevipul1.Models.loginmodel> loginmodel { get; set; } = default!;

public DbSet<corevipul1.Models.Ulogin> Ulogin { get; set; } = default!;

public DbSet<corevipul1.Models.Touristplace> Touristplace { get; set; } = default!;

}
