﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }

        [Required]
        [StringLength(55, MinimumLength = 5)]
        public string Address { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
    }
}
