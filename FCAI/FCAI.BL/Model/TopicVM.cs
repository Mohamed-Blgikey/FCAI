using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class TopicVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50,ErrorMessage ="Max Len 50")]
        [MinLength(3,ErrorMessage = "Min Len 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
