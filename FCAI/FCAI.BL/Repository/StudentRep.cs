using FCAI.BL.Interface;
using FCAI.DAL.Database;
using FCAI.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Repository
{
    public class StudentRep : IStudentRep
    {
        #region Variable
        private readonly FcaiContext db;
        #endregion

        #region Ctor
        public StudentRep(FcaiContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        public Student Create(Student student)
        {
            db.Student.Add(student);
            db.SaveChanges();
            return student;
        }

        public Student Delete(Student student)
        {
            db.Student.Remove(student);
            db.SaveChanges();
            return student;

        }

        public Student Edit(Student student)
        {
            db.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return student;

        }

        public IEnumerable<Student> Get()
        {
            var data = db.Student.Include(a=>a.department).Select(a => a);
            return data;
        }

        public Student GetById(int id)
        {
            var data = db.Student.Include(a=>a.department).Where(a => a.ID == id).FirstOrDefault();
            return data;
        }
        #endregion
    }

}
