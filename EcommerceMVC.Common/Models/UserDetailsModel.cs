using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Models
{
    public class UserDetailsModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public string CompanyName { get; set; }
    }
}
