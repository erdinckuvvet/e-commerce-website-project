using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloth.Models
{
    public class Address
    {
        public int Id { get; set; }

        //public int UserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Apartment { get; set; }
        public int PostCode { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}