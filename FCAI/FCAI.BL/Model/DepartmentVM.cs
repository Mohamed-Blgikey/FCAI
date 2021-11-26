using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50,ErrorMessage ="Max len 50")]
        [MinLength(2,ErrorMessage ="Min len 2")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code Is Required")]
        [MaxLength(50,ErrorMessage ="Max len 50")]
        [MinLength(4,ErrorMessage ="Min len 4")]
        public string Code { get; set; }
        public int MangerId { get; set; }
        public virtual Instractor Manger { get; set; }
        public virtual ICollection<Instractor> Instractors { set; get; }
        public ICollection<Student> Students { set; get; }
    }
}
