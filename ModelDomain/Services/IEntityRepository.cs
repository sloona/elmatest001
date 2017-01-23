using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IEntityRepository<T>
        where T : class
    {
        //OperationResult Create();
        //OperationResult Load(int Id);
        //bool Delete();

        void Update(T operResult);

        T Create();

        IEnumerable<T> GetAll();

        T Load(int d);

        bool Delete(int Id);
    }
}
