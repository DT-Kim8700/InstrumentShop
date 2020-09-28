using App.Data;
using App.Models.Entity;
using App.Models.ViewModels;
using App.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // 거래 현황 확인
        // 상품 구매
        // 구매 목록 확인
        // 구매 취소



        // 주문 추가
        public int UpdateOrder(InstrumentViewModel model)
        {
            string id = _context.AccountUsers.Where(a => a.UserName == model.UserName).FirstOrDefault().Id;

            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                Status = Order.EStatus.배송준비,
                AccountId = id
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return _context.Orders.Where(o => o.AccountId == id).ToList().LastOrDefault().OrderNumber;
        }

        // 주문 목록 추가
        public void UpdateOrderItem(InstrumentViewModel model, int orderNumber)
        {
            OrderItem orderItem = new OrderItem()
            {
                OrderNumber = orderNumber,
                GoodsNumber = model.GoodsNumber
            };

            _context.OrderItems.Add(orderItem);
        }
    }
}
