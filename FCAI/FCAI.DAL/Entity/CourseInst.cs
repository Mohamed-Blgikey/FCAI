using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.DAL.Entity
{
    public class CourseInst
    {
        public int c_Id { get; set; }
        public int Inst_Id { get; set; }
        public virtual Course Course { get; set; }
        public virtual Instractor Instractor { get; set; }
        
    }
}
