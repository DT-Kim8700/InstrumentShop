using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using App.Models.Entity;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AccountUser> _userManager;
        private readonly SignInManager<AccountUser> _signInManager;

        public HomeController(UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }



        // 계정 가입 페이지
        public IActionResult Join()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Join(JoinViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AccountUser
                {
                    AccountId = model.AccountId,
                    UserName = model.AccountId,
                    Name = model.Name,
                    Gender = model.Gender,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");       // 회원 가입 성공시 메인 페이지로 이동
                }

            }

            ModelState.AddModelError("", "회원가입 실패");

            return View(model);     // 회원 가입 실패시
        }


        // 로그인
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "로그인 실패");
            }

            return View(model);
        }


        // 로그아웃
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();     // 로그인 관련 쿠기 정보를 삭제한다.

            return RedirectToAction("Index", "Home");
        }











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

/*
[고객]
메인페이지 - 로그인, 모든 상품 리스트 노출, 검색 기능. 페이징 처리
검색 후 페이지 - 메인페이지와 동일하지만 검색한 내용만 나오는 페이지
물건 상세 정보 페이지 - 물건 사진 및 상세 설명. 악기의 경우 부속품 및 기타 상품을 추가로 주문 할 수 있는 목록이 추가된다. 발송지 등 정보를 입력하고 주문 기능

회원가입 페이지

주문한 목록 확인 페이지
주문 정보 상세 보기 페이지

[관리자]
물건 등록 페이지
물건 전체 현황 페이지
물건 상세 정보 페이지

주문 목록 페이지
주문 상세 페이지 - 물건 및 구매자의 정보 확인. 배송 상태 변경 기능.
 
 */