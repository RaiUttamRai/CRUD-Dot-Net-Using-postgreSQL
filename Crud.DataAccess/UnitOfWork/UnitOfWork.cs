using Crud.DataAccess.Data;
using Crud.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICrudRepository Info { get;private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Info = new CrudRepository(db);
            
        }
        //ICrudRepository IUnitOfWork.CrudRepository => throw new NotImplementedException();

        void IUnitOfWork.Save()
        {
            _db.SaveChanges();
        }
    }
}
