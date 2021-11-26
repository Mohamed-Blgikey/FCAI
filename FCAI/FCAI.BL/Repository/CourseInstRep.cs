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
    public class CourseInstRep : ICourseInstRep
    {
        private readonly FcaiContext db;

        public CourseInstRep(FcaiContext db)
        {
            this.db = db;
        }
        public CourseInst addCourse(CourseInst courseInst)
        {
            db.CourseInst.Add(courseInst);
            db.SaveChanges();
            return courseInst;
        }
        public CourseInst GetById(int idInst, int idCrs)
        {
            var data = db.CourseInst.Include(a => a.Course).Include(a => a.Instractor).Where(a => a.Inst_Id == idInst && a.c_Id == idCrs).FirstOrDefault();
            return data;
        }
        public IEnumerable<CourseInst> Get()
        {
            var data = db.CourseInst.Include(a=>a.Instractor).Include(a => a.Course).Select(a => a);
            return data;
        }
        public CourseInst Delete(CourseInst courseInst)
        {
            db.CourseInst.Remove(courseInst);
            db.SaveChanges();
            return courseInst;
        }

        public CourseInst Edit(CourseInst courseInst)
        {
            db.Entry(courseInst).State = EntityState.Modified;
            db.SaveChanges();
            return courseInst;
        }

        

        
    }
}
