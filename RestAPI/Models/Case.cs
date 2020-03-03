using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class Case
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
 
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public string Postal { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required ]
        [RegularExpression(@"^[0-9]+$")]
        public string Phone { get; set; }

        public int UnionID { get; set; }

    }
}
