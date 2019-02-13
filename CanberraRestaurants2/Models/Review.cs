using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanberraRestaurants2.Models
{
    public class Review
    {
        // Primary key, I think...
        public int Id { get; set; }

        // string version of date, used on display
        public string Date { get; set; }

        // Automatically extracted from user information
        public string Name { get; set; }

        // Review title
        public string Heading { get; set; }

        // To be chosen from hardcoded list on create page
        public string Restaurant { get; set; }

        // Body text of review
        public string Comment { get; set; }

        // Later, make sure it's between 0 and 5
        public int Rating { get; set; }  

        // Proper date, used for sorting (not totally sure if necessary)
        public DateTime SubmissionDate { get; set; }

        // The number of people who agree with a review
        public int Agrees { get; set; }

        // The number of people who disagree with a review
        public int Disagrees { get; set; }

        // Whether the review has been agreed or disagreed with this login
        // TEST
        public bool ChangedThisSession { get; set; }

    }
}
