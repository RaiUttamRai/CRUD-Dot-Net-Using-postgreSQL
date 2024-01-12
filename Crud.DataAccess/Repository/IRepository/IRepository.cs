using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); //which represent a collection fo entities
        T Get(Expression<Func<T, bool>> filter); //this method is used to retrieve a single entity based on a specific filter condition
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(T entity);

    }
}
