using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Services
{
    public class OperationRepository : IOperationRepository
    {
        public Operation Create()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Operation oper)
        {
            throw new NotImplementedException();
        }

        public Operation Load(int Id)
        {
            using (var db = new CalcContext())
            {
                return db.Operations.FirstOrDefault(o => o.Id == Id);
            }
        }

        public bool Delete(int Id)
        {
            var item = Load(Id);
            if (item == null)
                return false;
            using (var db = new CalcContext())
            {
                db.Operations.Remove(item);
                db.SaveChanges();
            }
            return true;
        }
    }
}