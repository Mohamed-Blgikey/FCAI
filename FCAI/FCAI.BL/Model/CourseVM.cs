using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class CourseVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [MinLength(3, ErrorMessage = "min Len 3")]

        public string Name { get; set; }
        [Required(ErrorMessage ="Duration Is Required")]
        [Range(12, 18,ErrorMessage ="Range BTW (12:18H)")]
        public double Duration { set; get; }
        [Required(ErrorMessage = "Descation Is Required")]

        [MaxLength(1000,ErrorMessage = "Max Len 1000")]
        [MinLength(10,ErrorMessage = "min Len 10")]
        public string Descation { get; set; }

        public virtual ICollection<CourseInst> CourseInsts { set; get; }
        public virtual ICollection<CourseStd> CourseStds { set; get; }
        public virtual ICollection<Topic> Topics { set; get; }
    }
}
