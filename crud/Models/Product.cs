using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productName {  get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public double productPrice { get; set; }
    }
}
