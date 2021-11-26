using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class CourseInstVM
    {
        public int c_Id { get; set; }
        public int Inst_Id { get; set; }
        public virtual Course Course { get; set; }
        public virtual Instractor Instractor { get; set; }
    }
}
