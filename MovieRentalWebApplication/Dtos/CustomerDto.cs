using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieRentalWebApplication.Models;

namespace MovieRentalWebApplication.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        [Required]
        [MinLength(255)]
        public string Name { get; set; }
       
        public int MembershipTypeId { get; set; }

        [Min18YearsIfaMemeber]
        public DateTime DateOfBirth { get; set; }
    }
}