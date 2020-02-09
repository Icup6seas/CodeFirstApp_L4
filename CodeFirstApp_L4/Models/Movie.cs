using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApp_L4.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Summary> Summaries { get; set; }
    }
}
