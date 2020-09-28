using App.Models.ViewModels;

namespace App.Service
{
    public interface IOrderService
    {
        void AddOrder(InstrumentViewModel model);
    }
}