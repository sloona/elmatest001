using System.Collections.Generic;
using System.Linq;
using Models;
using DomainModel.Helpers;
using NHibernate.Criterion;

namespace Services
{
    public class NHUserRepository : IUserRepository
    {


        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using (var session = NHibernateHelper.OpenSession() )
            {
                var criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Ge("Id",3));
                users = criteria.List<User>().ToList();
            }
            return users;
        }

        public void Update(User user)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(user);
                        
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

        public User Create()
        {
            return new User() { Id=0};
        }

        public User Load(int Id)
        {
            using (var db = new CalcContext())
            {
                return db.Users.FirstOrDefault(o => o.Id == Id);
            }
        }

        public bool Delete(int Id)
        {
            var item = Load(Id);
            if (item == null)
                return false;
            using (var db = new CalcContext())
            {
                db.Users.Remove(item);
                db.SaveChanges();
            }
            return true;
        }
    }
}