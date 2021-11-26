using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Interface
{
    public interface IStudentRep
    {
        IEnumerable<Student> Get();
        Student GetById(int id);
        Student Create(Student student);
        Student Edit(Student student);
        Student Delete(Student student);
    }
}
