using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApp_L4.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieID { get; set; }
        [Required]
        [ConcurrencyCheck]
        [MaxLength(24, ErrorMessage = "The maximum length is 24 characters")]
        [MinLength(5, ErrorMessage = "The minimum length is 5 characters")]
        [Index(IsUnique = true)]
        public string Title { get; set; }

        public virtual ICollection<Summary> Summaries { get; set; }
    }
}
