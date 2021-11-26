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
    public class CourseRep : ICourseRep
    {
        private readonly FcaiContext db;

        public CourseRep(FcaiContext db)
        {
            this.db = db;
        }
        public Course Create(Course course)
        {
            db.Course.Add(course);
            db.SaveChanges();
            return course;
        }

        public Course Delete(Course course)
        {
            db.Course.Remove(course);
            db.SaveChanges();
            return course;
        }

        public Course Edit(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return course;
        }

        public IEnumerable<Course> Get()
        {
            var data = db.Course.Select(a => a);
            return data;
        }

        public Course GetById(int id)
        {
            var data = db.Course.Include(a=>a.Topics).Where(a => a.ID == id).FirstOrDefault();
            return data;
        }
    }
}
