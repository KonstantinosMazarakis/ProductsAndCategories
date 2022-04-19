using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class Collection
    {
        [Key]
        public int CollectionId {get;set;}
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public Category Category {get;set;}
        public Product Product {get;set;}

    }
}