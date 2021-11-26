using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.DAL.Entity
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Code { get; set; }
        public int MangerId { get; set; }
        public virtual Instractor Manger { get; set; }
        public virtual ICollection<Instractor> Instractors { set; get; }
        public ICollection<Student> Students { set; get; }

    }
}
