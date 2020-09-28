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
            // 테이블 데이터 삭제 
            //_context.Goods.RemoveRange(_context.Goods);
            //_context.Instruments.RemoveRange(_context.Instruments);
            //await _context.SaveChangesAsync();

            // DB 초기 더미 데이터 설정.
            if (!_context.Goods.Any())
            {
                List<Goods> goods = new List<Goods>
                {
                    #region 입력할 데이터
                    new Goods() {
                        GoodsName = "bacoon Beta-Bb", Brand = "bacoon", Kinds = Goods.EKinds.악기,
                        Price = 1000000, Stock = 3, ImgSrc ="~/img/Instrument/clarinet/bacoon Beta-Bb.jpg" },
                    new Goods() {
                        GoodsName = "bacoon Protege-Bb", Brand = "bacoon", Kinds = Goods.EKinds.악기,
                        Price = 5000000, Stock = 5, ImgSrc ="~/img/Instrument/clarinet/bacoon Protege-Bb" },
                    new Goods() {
                        GoodsName = "bacoon Q Serize-Bb", Brand = "bacoon", Kinds = Goods.EKinds.악기,
                        Price = 3000000, Stock = 2, ImgSrc ="~/img/Instrument/clarinet/bacoon Q Serize-Bb.jpg" },
                    new Goods() {
                        GoodsName = "브란넨쿠퍼 14K 골드콤비 플루트_ 골드톤홀(GR) 전문가용 플룻", Brand = "브란넨쿠퍼", Kinds = Goods.EKinds.악기,
                        Price = 10000000, Stock = 5, ImgSrc ="~/img/Instrument/flute/브란넨쿠퍼 14K 골드콤비 플루트_ 골드톤홀(GR) 전문가용 플룻.jpg" },
                    new Goods() {
                        GoodsName = "브란넨쿠퍼 올실버 플루트 전문가용 Silver 플룻", Brand = "브란넨쿠퍼", Kinds = Goods.EKinds.악기,
                        Price = 1000000, Stock = 5, ImgSrc ="~/img/Instrument/flute/브란넨쿠퍼 올실버 플루트 전문가용 Silver 플룻.jpg" },
                    new Goods() {
                        GoodsName = "헤인즈 AF680SE-BO 플루트 미국제조 헤드실버 중금자용 플룻", Brand = "HAYNES", Kinds = Goods.EKinds.악기,
                        Price = 3000000, Stock = 5, ImgSrc ="~/img/Instrument/flute/헤인즈 AF680SE-BO 플루트 미국제조 헤드실버 중금자용 플룻.jpg" },
                    new Goods() {
                        GoodsName = "헤인즈 flute 9K FUsion D.N", Brand = "HAYNES", Kinds = Goods.EKinds.악기,
                        Price = 5500000, Stock = 5, ImgSrc ="~/img/Instrument/flute/헤인즈 flute 9K FUsion D.N.jpg" },
                    new Goods() {
                        GoodsName = "Gotz violin PA_GA", Brand = "HAYNES", Kinds = Goods.EKinds.악기,
                        Price = 2000000, Stock = 5, ImgSrc ="~/img/Instrument/violin/Gotz violin PA_GA.jpg" },
                };
                #endregion

                await _context.AddRangeAsync(goods);

                await _context.SaveChangesAsync();

            }

            if (!_context.Instruments.Any())
            {
                // DB 초기 더미 데이터 설정.
                List<Instrument> instruments = new List<Instrument>
                {
                    #region 입력할 데이터
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.클라리넷,
                        GoodsNumber = 1050
                    },
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.클라리넷,
                        GoodsNumber = 1051
                    },
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.클라리넷,
                        GoodsNumber = 1052
                    },
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.플루트,
                        GoodsNumber = 1053
                    },
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.플루트,
                        GoodsNumber = 1054
                    },
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.플루트,
                        GoodsNumber = 1055
                    },
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.플루트,
                        GoodsNumber = 1056
                    },
                    new Instrument() {
                        InstrumentKinds = Instrument.EInstrumentKinds.바이올린,
                        GoodsNumber = 1057
                    }
                    #endregion
                };
                await _context.AddRangeAsync(instruments);

                await _context.SaveChangesAsync();

            }

            // 계정에 운영자 권한 부여 : master@naver.com 에 manager 역할을 부여
            var adminAccount = await _userManager.FindByNameAsync("master");
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