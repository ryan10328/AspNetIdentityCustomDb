using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspIdentityCustomDb.Models
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext()
            : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}