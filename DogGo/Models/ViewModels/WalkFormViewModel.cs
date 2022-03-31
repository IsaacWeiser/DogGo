using System.Collections.Generic;
using System.Linq;

namespace DogGo.Models.ViewModels
{
    public class WalkFormViewModel
    {

        public Walker Walker { get; set; }
        public List<Walk> Walks { get; set; }
        public List<Owner> Clients { get; set; }

        public string TotalWalkTime
        {
            get
            {
                int totMins = Walks.Select(w => w.Duration).Sum() / 60;
                int hrs = totMins / 60;
                int mins = totMins % 60;
                return $"{hrs} hours : {mins} minutes"; 
            }
        }

     

    }
}
