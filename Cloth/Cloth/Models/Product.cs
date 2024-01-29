using Cloth.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloth.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Gender Gender { get; set; }
        public Fit Fit { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }


        public virtual ICollection<ProductOrder> ProductOrders { get; set; }

    }


}