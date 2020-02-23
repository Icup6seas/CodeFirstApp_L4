using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstApp_L4.Models
{
    public enum Rating
    {
        E, PG, M, R
    }

    public class Summary
    {
        [Display(Name = "Summary ID")]
        public int SummaryID { get; set; }
        [Index]
        [Display(Name = "Movie ID")]
        public int MovieID { get; set; }
        [Index]
        [Display(Name = "Actor")]
        public int ActorID { get; set; }
        public Rating? Rating { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}