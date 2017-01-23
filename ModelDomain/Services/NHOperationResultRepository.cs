using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;
using Services;
using DomainModel.Helpers;
using NHibernate.Criterion;

namespace Services
{
    public class NHOperationResultRepository : IOperationResultRepository
    {


        public IEnumerable<OperationResult> GetAll()
        {
            var operations = new List<OperationResult>();
            using (var session = NHibernateHelper.OpenSession() )
            {
                var criteria = session.CreateCriteria(typeof(OperationResult));
                //criteria.Add(Restrictions.Ge("Id",3));
                operations = criteria.List<OperationResult>().ToList();
            }
            return operations;
        }

        public void Update(OperationResult operResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(operResult);
                        
                    }
                    catch
                    {
                        transaction.Rollback();
                        //return;
                        throw;
                    }

                    transaction.Commit();
                }
            }
        }

        public OperationResult Create()
        {
            return new OperationResult() { Id=0};
        }

        public Operation FindOperByName(string name)
        {
           
            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(Operation));
                criteria.Add(Restrictions.Eq("Name",name));
                criteria.SetMaxResults(1);
                return criteria.List<Operation>().FirstOrDefault();
            }
           
        }

        public User FindUserById(int id)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(User));
                criteria.Add(Restrictions.Eq("Id", id));
                criteria.SetMaxResults(1);
                return criteria.List<User>().FirstOrDefault();
            }

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