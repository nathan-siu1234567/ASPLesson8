namespace ASPLesson8.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContosoModel : DbContext
    {
        public ContosoModel()
            : base("name=ContosoConnection")
        {
        }

        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.CourseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Enrollments1)
                .WithRequired(e => e.Cours1)
                .HasForeignKey(e => e.CourseID);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses1)
                .WithRequired(e => e.Department1)
                .HasForeignKey(e => e.DepartmentID);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstMidName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
