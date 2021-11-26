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

    public class InstractorRep : IInstractorRep
    {
        #region Variable
        private readonly FcaiContext db;
        #endregion

        #region Ctor
        public InstractorRep(FcaiContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        public Instractor  Create(Instractor instractor)
        {
            db.Instractor.Add(instractor);
            db.SaveChanges();
            return instractor;
        }

        public Instractor Delete(Instractor instractor)
        {
            db.Instractor.Remove(instractor);
            db.SaveChanges();
            return instractor;

        }

        public Instractor Edit(Instractor instractor)
        {
            db.Entry(instractor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return instractor;

        }

        public IEnumerable<Instractor> Get()
        {
            var data = db.Instractor.Include(a=>a.department).Select(a => a);
            return data;
        }

        public Instractor GetById(int id)
        {
            var data = db.Instractor.Include(a=>a.department).Include(a=>a.CourseInsts).Where(a => a.ID == id).FirstOrDefault();
            return data;
        }
        #endregion
    }
}

