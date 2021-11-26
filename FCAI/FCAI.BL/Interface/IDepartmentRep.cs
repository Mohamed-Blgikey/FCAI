using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Interface
{
    public interface IDepartmentRep
    {
        IEnumerable<Department> Get();
        Department GetById(int id);
        Department Create(Department department);
        Department Edit(Department department);
        Department Delete(Department department);
    }
}
