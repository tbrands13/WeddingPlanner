using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]

        public int UserId {get; set;}
        [Required]
        [MinLength(3, ErrorMessage ="First Name must be at least 3 characters long")]
        public string FirstName {get; set;}
        [Required]
        [MinLength(3, ErrorMessage ="Last Name must be at least 3 characters long")]
        public string LastName {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Must have 6 characters for the password")]
        public string Password {get; set;}
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords must match")]
        public string Confirm {get; set;}
        public List<RSVP> Attending {get;set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }
}