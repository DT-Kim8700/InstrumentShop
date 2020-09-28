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
    public class OrderController : Controller
    {
        private readonly UserManager<AccountUser> _userManager;
        private readonly SignInManager<AccountUser> _signInManager;
        private readonly IOrderService _orderService;

        public OrderController(UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager, IOrderService orderService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderService = orderService;
        }

        
    }
}
