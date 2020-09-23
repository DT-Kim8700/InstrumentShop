using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public class Ect
    {
        public enum EEctKinds
        {
            악기케이스,
            송진,
            침수건,
            소지봉
        }
        [Key]
        public int EctNumber { get; set; }

        [Required]
        public EEctKinds EctKinds { get; set; }
    }
}
