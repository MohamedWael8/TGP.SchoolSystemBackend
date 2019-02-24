using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ITWORX.TGP.EGYPT.SchoolSystem.Models
{
    public class School
    {
        public readonly static List<School> Schools = new List<School>
        {
            new School
            {
                Id = 1,
                Name = "Future",
                City = "Cairo" ,
                System = "AM",
                AverageNumberOfStudentsInClass = 24,
                Website = "http://future.edu.eg" ,
                Contact = "contact@future.edu.eg"
            },
            new School
            {
                Id = 2,
                Name = "Saint Fatima",
                City = "Cairo" ,
                System =  "IG",
                AverageNumberOfStudentsInClass = 38,
                Website = "http://saintfatima.edu.eg" ,
                Contact = "contact@saintfatima.edu.eg"
            }
        };

        public int Id { get; set; }
        [RegularExpression("^[A-Za-z ]*$")]
        public string Name { get; set; }
        [RegularExpression("^[A-Za-z]*$")]
        [MinLength(3)]
        public string City { get; set; }
        [RegularExpression("^[A-Z]*$")]
        [StringLength(2, MinimumLength = 2)]
        public string System { get; set; }
        [Range(5,100)]
        public float AverageNumberOfStudentsInClass { get; set; }
        [Url]
        public string Website { get; set; }
        [EmailAddress]
        public string Contact { get; set; }

    }

}