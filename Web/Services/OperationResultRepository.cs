using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;
using Web.Services;

namespace Web.Services
{
    public class OperationResultRepository : IEntityRepository<OperationResult>
    {
        

        public IEnumerable<OperationResult> GetAll() {
            var operations = new List<OperationResult>();
            using (var db = new CalcContext()) {
                //operations = db.OperationResults.ToList();
                operations = db.OperationResults.Include("Operation").ToList();
                //operations = db.OperationResults.Include("Operation").AsNoTracking().ToList();
            }
            return operations;
        }

        public void Update(OperationResult operResult)
        {
            using (var db = new CalcContext())
            {
                db.Entry<OperationResult>(operResult).State =
                    operResult.Id == 0 ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }

        public OperationResult Create()
        {
            using (var db = new CalcContext())
            {
                return db.OperationResults.Create();
            }
        }

        public Operation FindOperByName(string name)
        {
            Operation operation;
            using (var db = new CalcContext())
            {
              operation = db.Operations.Where(o => o.Name == name).FirstOrDefault();
            }
            return operation;
        }
    }
}