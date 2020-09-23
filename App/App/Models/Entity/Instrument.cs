using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public class Instrument
    {
        public enum EInstrumentKinds
        {
            피아노,
            바이올린,
            비올라,
            첼로,
            플루트,
            클라리넷,
            기타
        }

        [Key]
        public int InsNumber { get; set; }

        [Required]
        public EInstrumentKinds InstrumentKinds { get; set; }

    }
}
