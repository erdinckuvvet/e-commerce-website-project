using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloth.Models
{
    public class Order
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        //public int AddressId { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual Address Address { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}