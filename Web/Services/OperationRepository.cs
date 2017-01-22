using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Services
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
    }
}