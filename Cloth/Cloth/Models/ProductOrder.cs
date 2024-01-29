using Cloth.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloth.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public int BoughtAmount { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}