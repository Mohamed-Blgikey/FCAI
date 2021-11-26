using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Interface
{
    public interface ICourseRep
    {
        IEnumerable<Course> Get();
        Course GetById(int id);
        Course Create(Course course);
        Course Edit(Course course);
        Course Delete(Course course);
    }
}
