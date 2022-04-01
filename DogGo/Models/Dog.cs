using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "plz enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "plz enter owner id")]
        public int OwnerId { get; set; }

        public string Breed { get; set; }

        public string Notes { get; set; }

        public string ImageUrl { get; set; }


    }
}
