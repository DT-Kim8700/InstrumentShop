using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public partial class Goods
    {
        public enum EKinds
        {
            악기,
            부속품,
            기타상품
        }

        public enum EManufacturer
        {
            야마하,
            삼익,
            영창,
            파가니니,
            무라마츠,
            파우웰
        }

        [Key]
        public int GoodsNumber { get; set; }

        [Required]
        public EKinds Kinds { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public EManufacturer Manufacturer { get; set; }

        
    }

    public partial class Goods
    {
        [ForeignKey("GoodsNumber")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [ForeignKey("GoodsNumber")]
        public virtual ICollection<Instrument> Instruments { get; set; }

        [ForeignKey("GoodsNumber")]
        public virtual ICollection<Part> Parts { get; set; }

        [ForeignKey("GoodsNumber")]
        public virtual ICollection<Ect> Ects { get; set; }
    }
}

