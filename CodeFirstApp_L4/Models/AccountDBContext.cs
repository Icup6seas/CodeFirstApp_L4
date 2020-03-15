using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstApp_L4.Models
{
    public class AccountDBContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}