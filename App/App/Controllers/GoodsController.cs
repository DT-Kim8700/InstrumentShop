using App.Models.Entity;
using App.Models.ViewModels;
using App.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class GoodsController : Controller
    {
        private readonly UserManager<AccountUser> _userManager;
        private readonly SignInManager<AccountUser> _signInManager;
        private readonly IGoodsService _goodsService;
        private readonly IOrderService _orderService;


        public GoodsController(UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager, IGoodsService goodsService, IOrderService orderService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _goodsService = goodsService;
            _orderService = orderService;
        }

        // 관악기 리스트
        public IActionResult WindList(string id)
        {
            IEnumerable<InstrumentViewModel> viewModels =  _goodsService.GetWindList(id);

            return View(viewModels);
        }
        // 현악기 리스트
        public IActionResult StringList()
        {
            IEnumerable<InstrumentViewModel> viewModels = _goodsService.GetStringList();

            return View(viewModels);
        }
        // 피아노 리스트
        public IActionResult PianoList()
        {
            IEnumerable<InstrumentViewModel> viewModels = _goodsService.GetPianoList();

            return View(viewModels);
        }

        // 악기 상세 정보
        public IActionResult InstrumentInfo(int id)
        {
            InstrumentViewModel viewModels = _goodsService.GetInstrumentInfo(id);
            return View(viewModels);
        }

        // 주문 추가
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InstrumentInfo(InstrumentViewModel model)
        {
            // 주문테이블, 주문목록 테이블에 데이터를 추가한다.
            // 해당 상품의 수량을 -1 시켜야 한다.
            _orderService.AddOrder(model);

            return RedirectToAction("Index", "Home");
        }






        public IActionResult PartList()
        {
            return View();
        }

        public IActionResult EctList()
        {
            return View();
        }
    }
}
