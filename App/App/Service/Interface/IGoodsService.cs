using App.Models.Entity;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Service
{
    public interface IGoodsService
    {
        IEnumerable<Ect> GetEctList();
        IEnumerable<InstrumentViewModel> GetWindList(string id);
        IEnumerable<Part> GetPartList();
        IEnumerable<InstrumentViewModel> GetStringList();
        IEnumerable<InstrumentViewModel> GetPianoList();
        InstrumentViewModel GetInstrumentInfo(int id);
    }
}