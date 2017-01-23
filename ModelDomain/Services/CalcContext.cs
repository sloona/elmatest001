using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Services
{
    public class CalcContext : DbContext
    {
        public CalcContext()
            :base("DefaultConnection")
        {
        }

        public DbSet<Models.OperationResult> OperationResults {
            get; set;
        }
        public DbSet<Models.Operation> Operations
        {
            get; set;
        }

        public DbSet<Models.User> Users
        {
            get; set;
        }

    }
}