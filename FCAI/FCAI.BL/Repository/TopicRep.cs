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
    public class TopicRep : ITopicRep
    {
        private readonly FcaiContext db;

        public TopicRep(FcaiContext db)
        {
            this.db = db;
        }

        public Topic Create(Topic topic)
        {
            db.Topic.Add(topic);
            db.SaveChanges();
            return topic;
        }

        public Topic Delete(Topic topic)
        {
            db.Topic.Remove(topic);
            db.SaveChanges();
            return topic;
        }

        public Topic Edit(Topic topic)
        {
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            return topic;
        }

        public IEnumerable<Topic> Get()
        {
            var data = db.Topic.Include(a=>a.Course).Select(a => a);
            return data;
        }

        public Topic GetById(int id)
        {
            var data = db.Topic.Include(a => a.Course).Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
