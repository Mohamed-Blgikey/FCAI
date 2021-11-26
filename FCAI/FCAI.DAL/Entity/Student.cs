using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.DAL.Entity
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string Code { get; set; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }

        public int? DeptId { get; set; }
        public virtual Department department { get; set; }
        public virtual List<CourseStd> CourseStd { set; get; }
    }
}
