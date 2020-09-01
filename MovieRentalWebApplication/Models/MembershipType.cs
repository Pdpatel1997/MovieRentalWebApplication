using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalWebApplication.Models
{
    public class MembershipType
    {
        
        public int MembershipTypeId { get; set; }
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonth { get; set; }
        public int DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quaterly = 3;
        public static readonly byte Yearly = 4;

    }
}