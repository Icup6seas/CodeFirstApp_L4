﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstApp_L4.Models
{
    public class MemberDBContext : DbContext
    {
        public DbSet<Membership> Members { get; set; }
    }
}