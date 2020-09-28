using App.Models.ViewModels;

namespace App.Repository.Interface
{
    public interface IOrderRepository
    {
        int UpdateOrder(InstrumentViewModel model);
        void UpdateOrderItem(InstrumentViewModel model, int orderNumber);
    }
}