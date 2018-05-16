using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
   public class Database_Context:DbContext
    {
        public Database_Context()
            :base("DbConnection")
        { }

        public DbSet<DB_User> Users { get; set; }
        public DbSet<DB_Product> Products { get; set; }
        public DbSet<DB_Category> Categories { get; set; }
    }
}
