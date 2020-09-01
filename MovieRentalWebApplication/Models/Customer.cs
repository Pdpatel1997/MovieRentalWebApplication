using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalWebApplication.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        [Required]
        [MinLength(255)]
        public string Name { get; set; }
        public virtual MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }

        [Min18YearsIfaMemeber]
        public DateTime DateOfBirth { get; set; }
    }
}