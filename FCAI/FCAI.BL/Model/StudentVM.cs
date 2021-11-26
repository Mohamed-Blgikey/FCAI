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
    public class StudentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [MaxLength(50, ErrorMessage = "Max len 50")]
        [MinLength(3, ErrorMessage = "Min len 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code Is Required")]
        [MaxLength(50, ErrorMessage = "Max len 50")]
        [MinLength(3, ErrorMessage = "Min len 3")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Mail Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Department Is Required")]
        public int? DeptId { get; set; }
        public Department department { get; set; }
    }
}
