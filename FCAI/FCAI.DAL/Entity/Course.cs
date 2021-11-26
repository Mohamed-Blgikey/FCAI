using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.DAL.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class Course
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(12, 18)]
        public double Duration { set; get; }
        [Required]
        [MaxLength(1000)]
        public string Descation { get; set; }

        public virtual List<CourseInst> CourseInsts { set; get; }
        public virtual List<CourseStd> CourseStds { set; get; }
        public virtual ICollection<Topic> Topics { set; get; }
    }
}
