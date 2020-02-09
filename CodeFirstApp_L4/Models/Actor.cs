﻿using System;
using System.Collections.Generic;

namespace CodeFirstApp_L4.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime YearActive { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}