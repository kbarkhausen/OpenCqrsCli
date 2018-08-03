using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCqrsCli.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetQuery();

        IEnumerable<T> GetAll();

        T Get(int id);

        T Add(T item);

        void Update(T item);

        void Delete(int id);
    }
}
