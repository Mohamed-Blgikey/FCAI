using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.DAL.Entity
{
    public class Instractor
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        [MinLength(11)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(2000,10000)]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int? DeptId { get; set; }
        public virtual Department department { get; set; }

        public virtual Department deptMan { set; get; }

        public virtual List<CourseInst> CourseInsts { set; get; }



    }
}
