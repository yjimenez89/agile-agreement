using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amsystem.Data;
using Amsystem.Data.Entities;

namespace Amsystem.Data.SqlServer.Context
{
    public class AmsystemDbContext : DbContext
    {
        public AmsystemDbContext() : base("AmsystemDbConnection")
        {
            Database.SetInitializer(new AmsystemDbInitializer());
        }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
