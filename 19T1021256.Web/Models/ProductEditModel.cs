using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021256.DomainModels;

namespace _19T1021256.Web.Models
{
    public class ProductEditModel :Product
    {
        public Product Data { get; set; }
        public List<ProductAttribute> Attributes { get; set; }
        public List<ProductAttribute> Phots { get; set; }
    }
}