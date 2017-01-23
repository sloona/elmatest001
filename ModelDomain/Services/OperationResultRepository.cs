using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;
using Services;

namespace Services
{
    public class OperationResultRepository : IEntityRepository<OperationResult>
    {


        public IEnumerable<OperationResult> GetAll()
        {
            var operations = new List<OperationResult>();
            using (var db = new CalcContext())
            {
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
            //Operation operation;
            using (var db = new CalcContext())
            {
               return   db.Operations.FirstOrDefault(o => o.Name == name);
            }
            //return operation;
        }

        public User FindUserById(int id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Load(int Id)
        {
            using (var db = new CalcContext())
            {
                return db.OperationResults.FirstOrDefault(o => o.Id == Id);
            }
        }

        public bool Delete(int Id)
        {
            var item = Load(Id);
            if (item == null)
                return false;
            using (var db = new CalcContext())
            {
                db.OperationResults.Remove(item);
                db.SaveChanges();
            }
            return true;
        }
    }
}