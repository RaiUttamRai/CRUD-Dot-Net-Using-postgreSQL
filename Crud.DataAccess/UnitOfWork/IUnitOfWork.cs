using Crud.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        // a property that returns an object implementing the 'ICrudRepository' interface.
        ICrudRepository Info { get; }

        void Save();
    }
}
