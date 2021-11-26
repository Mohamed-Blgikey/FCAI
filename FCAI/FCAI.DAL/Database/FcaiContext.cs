using FCAI.DAL.Entity;
using FCAI.DAL.Extend;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.DAL.Database
{
    public class FcaiContext :IdentityDbContext<ApplicationUser>
    {
        public FcaiContext(DbContextOptions<FcaiContext> opt):base(opt)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasMany(a => a.Instractors)
                .WithOne(a => a.department)
                .HasForeignKey(a => a.DeptId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Department>()
                .HasOne(a => a.Manger)
                .WithOne(a => a.deptMan)
                .HasForeignKey<Department>(a => a.MangerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Instractor>(a =>
            {
                a.HasIndex(a => a.Email).IsUnique();
                a.HasIndex(a => a.Phone).IsUnique();
                a.Property(a => a.HireDate).HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<Department>(a =>
            {
                a.HasIndex(a => a.Code).IsUnique();
            }
            );

            modelBuilder.Entity<Department>()
                .HasMany(a => a.Students)
                .WithOne(a=>a.department)
                .HasForeignKey(a => a.DeptId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Student>(a => {
                a.HasIndex(a => a.Email).IsUnique();
                a.HasIndex(a => a.Code).IsUnique();
            });

            modelBuilder.Entity<CourseInst>()
                .HasKey(a => new { a.c_Id, a.Inst_Id });

            modelBuilder.Entity<CourseInst>()
                .HasOne(a => a.Instractor)
                .WithMany(a => a.CourseInsts)
                .HasForeignKey(a => a.Inst_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseInst>()
                .HasOne(a => a.Course)
                .WithMany(a => a.CourseInsts)
                .HasForeignKey(a => a.c_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseStd>()
                .HasKey(a => new { a.std_Id, a.c_Id });

            modelBuilder.Entity<CourseStd>()
                .HasOne(a => a.Student)
                .WithMany(a => a.CourseStd)
                .HasForeignKey(a => a.std_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseStd>()
                .HasOne(a => a.Course)
                .WithMany(a => a.CourseStds)
                .HasForeignKey(a => a.c_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Topic>()
                .HasOne(a => a.Course)
                .WithMany(a => a.Topics)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public virtual DbSet<Department> Department { set; get; }
        public virtual DbSet<Instractor> Instractor { set; get; }
        public virtual DbSet<Student> Student { set; get; }
        public virtual DbSet<Course> Course { set; get; }
        public virtual DbSet<CourseInst> CourseInst { set; get; }
        public virtual DbSet<CourseStd> CourseStd { set; get; }
        public virtual DbSet<Topic> Topic { set; get; }

    }
}
