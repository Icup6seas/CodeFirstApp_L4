using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApp_L4.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreID { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Movie> Movies{ get; set; }
    }
}