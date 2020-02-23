using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApp_L4.Models
{
    [Table("ActorInfo")]
    public class Actor
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Actors last name must be entered.")]
        [StringLength(30, ErrorMessage = "The last name must be less than {1} characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Actors first name must be entered.")]
        [StringLength(20, ErrorMessage = "The first name must be less than {1} characters")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Actors active year has to be added.")]
        [Column("YearActive")]
        [Display(Name = "Year Active")]
        public DateTime YearActive { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}