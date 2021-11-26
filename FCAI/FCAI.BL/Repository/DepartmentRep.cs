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
    public class DepartmentRep : IDepartmentRep
    {
        #region Variable
        private readonly FcaiContext db;
        #endregion

        #region Ctor
        public DepartmentRep(FcaiContext db)
        {
            this.db = db;
        } 
        #endregion
       
        #region Methods
        public Department Create(Department department)
        {
            db.Department.Add(department);
            db.SaveChanges();
            return department;
        }

        public Department Delete(Department department)
        {
            db.Department.Remove(department);
            db.SaveChanges();
            return department;
        }

        public Department Edit(Department department)
        {
            db.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return department;
        }

        public IEnumerable<Department> Get()
        {
            var data = db.Department.Include(a=>a.Manger).Include("Students").Select(a=>a);
            return data;
        }

        public Department GetById(int id)
        {
            var data = db.Department.Include(a=>a.Manger).Include("Students").Where(a => a.Id == id).FirstOrDefault();
            return data;
        } 
        #endregion
    }
}
