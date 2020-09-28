using App.Models.Entity;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository.Interface
{
    public interface IGoodsRepository
    {
        IEnumerable<Ect> EctAllSelect();
        IEnumerable<InstrumentViewModel> WindAllSelect();
        IEnumerable<Part> PartAllSelect();
        IEnumerable<InstrumentViewModel> StringAllSelect();
        IEnumerable<InstrumentViewModel> PianoAllSelect();
        IEnumerable<InstrumentViewModel> FluteAllSelect();
        IEnumerable<InstrumentViewModel> ClarinetAllSelect();
        InstrumentViewModel selectOneInstrument(int id);
        void UpdateGoods(InstrumentViewModel model);
    }
}