using System;

namespace DogGo.Models.ViewModels
{
    public class Walk
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int WalkerId { get; set; }

        public int DogId { get; set; }

        public int Duration { get; set; }
    }
}
