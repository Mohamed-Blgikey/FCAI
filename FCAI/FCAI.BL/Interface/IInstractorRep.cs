using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Interface
{
    public interface IInstractorRep
    {
        IEnumerable<Instractor> Get();
        Instractor GetById(int id);
        Instractor Create(Instractor instractor);
        Instractor Edit(Instractor instractor);
        Instractor Delete(Instractor instractor);
    }
}
