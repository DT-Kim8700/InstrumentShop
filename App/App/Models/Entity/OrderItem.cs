using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public class OrderItem
    {
        [Key]
        public int ItemNumber { get; set; }

        [Required]
        public int OrderNumber { get; set; }

        [Required]
        public int GoodsNumber { get; set; }
    }
}
