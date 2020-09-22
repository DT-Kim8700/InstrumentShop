using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public class Ect
    {
        public enum EKinds
        {
            악기케이스,
            송진,
            침수건,
            소지봉
        }

        [Key]
        public int EctNumber { get; set; }

        [Required]
        public EKinds Kinds { get; set; }

        [Required]
        public int GoodsNumber { get; set; }
    }
}
