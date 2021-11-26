using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Interface
{
    public interface ITopicRep
    {
        IEnumerable<Topic> Get();
        Topic GetById(int id);
        Topic Create(Topic topic);
        Topic Edit(Topic topic);
        Topic Delete(Topic topic);
    }
}
