using Crud.DataAccess.Repository.IRepository;
using Crud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Repository
{
    public interface ICrudRepository : IRepository<Info>
    {
        void Update(Info info);
       // void Save();
    }
}
