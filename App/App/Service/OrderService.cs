using App.Models.ViewModels;
using App.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGoodsRepository _goodsRepository;


        public OrderService(IOrderRepository orderRepository, IGoodsRepository goodsRepository)
        {
            _orderRepository = orderRepository;
            _goodsRepository = goodsRepository;
        }

        public void AddOrder(InstrumentViewModel model)
        {
            // 주문테이블, 주문목록 테이블에 데이터를 추가한다. 해당 각각 단계에서 bool 값을 받아서 성공여부를 체크 해야한다. 
            int orderNumber = _orderRepository.UpdateOrder(model);
            _orderRepository.UpdateOrderItem(model, orderNumber);

            // 해당 상품의 수량을 -1 시켜야 한다.
            _goodsRepository.UpdateGoods(model);

        }
    }
}
