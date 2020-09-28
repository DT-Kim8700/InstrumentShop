using App.Models.Entity.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public class Part : IGoodsItem
    {
        public enum EPartKinds 
        {
            현,
            활,
            헤드코르크
        }

        [Key]
        public int PartNumber { get; set; }

        [Required]
        public EPartKinds PartKinds { get; set; }

        [Required]
        public int GoodsNumber { get; set; }
    }
}
