using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Interface
{
    public interface ICourseInstRep
    {
        CourseInst addCourse(CourseInst courseInst);

        IEnumerable<CourseInst> Get();
        CourseInst GetById(int idInst, int idCrs);
        CourseInst Edit(CourseInst course);
        CourseInst Delete(CourseInst course);
    }
}
