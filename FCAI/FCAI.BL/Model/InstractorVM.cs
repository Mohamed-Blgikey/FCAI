using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class InstractorVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Max len 50")]
        [MinLength(3, ErrorMessage = "Min len 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(11, ErrorMessage = "Max len 11")]
        [MinLength(11, ErrorMessage = "Min len 11")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Mail Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Salary Is Required")]
        [Range(2000, 10000,ErrorMessage ="Range Btw 2000 : 10000")]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int? DeptId { get; set; }
        public virtual Department department { get; set; }

        public virtual Department deptMan { set; get; }
        public virtual ICollection<CourseInst> CourseInsts { set; get; }


    }
}
