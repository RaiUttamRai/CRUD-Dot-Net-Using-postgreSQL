using Crud.DataAccess.Data;
using Crud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Repository
{
    public class CrudRepository : Repository<Info>, ICrudRepository
//By inheriting from repository<Model_Name> it gains the implementation of the generic repository patterns for the Model_name entities
//by inheriting from ICrudRepository it also includes the specilized methods declare in that interface(Update and save)
    {
        private ApplicationDbContext _db;
        public CrudRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
            
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Info info)
        {
            _db.infos.Update(info);
        }

    }
}
