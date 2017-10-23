using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Piasp3WebApiEf.DAL.Common
{
    public class EntityContext<TEntity> : DbContext where TEntity : class
    {
        public EntityContext()
            : base("DbConnection")
        { }

        public DbSet<TEntity> Entities { get; set; }
    }
}