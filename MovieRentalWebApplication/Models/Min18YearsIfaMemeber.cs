using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalWebApplication.Models
{
    public class Min18YearsIfaMemeber:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var cust = (Customer)validationContext.ObjectInstance;

            if (cust.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if(cust.DateOfBirth==null)
            {
                return new ValidationResult("Birth Date is required ");
            }
            var age = DateTime.Today.Year - cust.DateOfBirth.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Must be age og 18");
        }
    }
}