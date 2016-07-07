namespace ASPLesson8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

        public int StudentID { get; set; }

        public int Grade { get; set; }

        public virtual Cours Cours { get; set; }

        public virtual Cours Cours1 { get; set; }

        public virtual Student Student { get; set; }
    }
}
