using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static App.Models.Entity.Instrument;

namespace App.Models.ViewModels
{
    public class InstrumentViewModel
    {
        public int GoodsNumber { get; set; }

        public string GoodsName { get; set; }

        public string Brand { get; set; }

        public string ImgSrc { get; set; }

        public int Price { get; set; }

        public int InsNumber { get; set; }

        public int Stock { get; set; }

        public EInstrumentKinds InstrumentKinds { get; set; }

        public string UserName { get; set; }
    }
}
