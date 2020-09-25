using App.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public class DBSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AccountUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DBSeeder(ApplicationDbContext context,
            UserManager<AccountUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDatabase()
        {
            //if (!_context.AccountUsers.Any())    // Teachers 테이블에 데이터가 없을 때 초기 값 설정. 테이블에 데이터가 있다면 반영되지 않는다.
            //{
            //    // DB 초기 더미 데이터 설정.
            //    List<AccountUser> accountUsers = new List<AccountUser>()
            //    {
            //        new AccountUser() {Name = "김해원", Birthday = "1111-11-11", Gender = "여", Email ="Violin@naver.com",
            //            PhoneNumber = "01011112222", Address = "일곡동", Ins = Teacher.Instrument.Violin}
            //    };

            //    await _context.AddRangeAsync(accountUsers);

            //    await _context.SaveChangesAsync();

            //}


            // 테이블 데이터 삭제 
            //context.Communitys.RemoveRange(context.Communitys);
            //await context.SaveChangesAsync();

            // 계정에 운영자 권한 부여 : master@naver.com 에 manager 역할을 부여
            var adminAccount = await _userManager.FindByNameAsync("master@naver.com");
            var adminRole = new IdentityRole("manager");
            await _roleManager.CreateAsync(adminRole);
            await _userManager.AddToRoleAsync(adminAccount, adminRole.Name);

        }
    }
}

/*
enable-migrations
EntityFrameworkCore\add-migration InstrumentShopV1
EntityFrameworkCore\update-database
 */