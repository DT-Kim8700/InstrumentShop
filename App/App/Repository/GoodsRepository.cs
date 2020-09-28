using App.Data;
using App.Models.Entity;
using App.Models.Entity.Interface;
using App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository.Interface
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly ApplicationDbContext _context;

        public GoodsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        // 상품 등록
        // 상품 전체 현황 확인
        // 상품 재고 확인


        // 관악기 전체 조회
        public IEnumerable<InstrumentViewModel> WindAllSelect()
        {
            var query = from goods in _context.Goods
                        join instrument in _context.Instruments
                        on goods.GoodsNumber equals instrument.GoodsNumber
                        where instrument.InstrumentKinds == Instrument.EInstrumentKinds.클라리넷 || instrument.InstrumentKinds == Instrument.EInstrumentKinds.플루트
                        select new { goods, instrument };

            List<InstrumentViewModel> viewModels = new List<InstrumentViewModel>();

            if (query.Any())
            {
                foreach (var i in query)
                {
                    viewModels.Add(new InstrumentViewModel
                    {
                        GoodsNumber = i.goods.GoodsNumber,
                        GoodsName = i.goods.GoodsName,
                        ImgSrc = i.goods.ImgSrc,
                        Brand = i.goods.Brand,
                        Price = i.goods.Price
                    });

                }
            }

            return viewModels;
        }

        public IEnumerable<InstrumentViewModel> FluteAllSelect()
        {
            var query = from goods in _context.Goods
                        join instrument in _context.Instruments
                        on goods.GoodsNumber equals instrument.GoodsNumber
                        where instrument.InstrumentKinds == Instrument.EInstrumentKinds.플루트
                        select new { goods, instrument };

            List<InstrumentViewModel> viewModels = new List<InstrumentViewModel>();

            if (query.Any())
            {
                foreach (var i in query)
                {
                    viewModels.Add(new InstrumentViewModel
                    {
                        GoodsNumber = i.goods.GoodsNumber,
                        GoodsName = i.goods.GoodsName,
                        ImgSrc = i.goods.ImgSrc,
                        Brand = i.goods.Brand,
                        Price = i.goods.Price
                    });

                }
            }

            return viewModels;

        }

        public IEnumerable<InstrumentViewModel> ClarinetAllSelect()
        {
            var query = from goods in _context.Goods
                        join instrument in _context.Instruments
                        on goods.GoodsNumber equals instrument.GoodsNumber
                        where instrument.InstrumentKinds == Instrument.EInstrumentKinds.클라리넷
                        select new { goods, instrument };

            List<InstrumentViewModel> viewModels = new List<InstrumentViewModel>();

            if (query.Any())
            {
                foreach (var i in query)
                {
                    viewModels.Add(new InstrumentViewModel
                    {
                        GoodsNumber = i.goods.GoodsNumber,
                        GoodsName = i.goods.GoodsName,
                        ImgSrc = i.goods.ImgSrc,
                        Brand = i.goods.Brand,
                        Price = i.goods.Price
                    });

                }
            }

            return viewModels;
        }




        // 현악기 전체 조회
        public IEnumerable<InstrumentViewModel> StringAllSelect()
        {
            var query = from goods in _context.Goods
                        join instrument in _context.Instruments
                        on goods.GoodsNumber equals instrument.GoodsNumber
                        where instrument.InstrumentKinds == Instrument.EInstrumentKinds.기타
                            || instrument.InstrumentKinds == Instrument.EInstrumentKinds.바이올린
                            || instrument.InstrumentKinds == Instrument.EInstrumentKinds.비올라
                            || instrument.InstrumentKinds == Instrument.EInstrumentKinds.첼로
                        select new { goods, instrument };

            List<InstrumentViewModel> viewModels = new List<InstrumentViewModel>();

            if (query.Any())
            {
                foreach (var i in query)
                {
                    viewModels.Add(new InstrumentViewModel
                    {
                        GoodsNumber = i.goods.GoodsNumber,
                        GoodsName = i.goods.GoodsName,
                        ImgSrc = i.goods.ImgSrc,
                        Brand = i.goods.Brand,
                        Price = i.goods.Price
                    });

                }
            }

            return viewModels;
        }

        // 피아노 전체 조회
        public IEnumerable<InstrumentViewModel> PianoAllSelect()
        {
            var query = from goods in _context.Goods
                        join instrument in _context.Instruments
                        on goods.GoodsNumber equals instrument.GoodsNumber
                        where instrument.InstrumentKinds == Instrument.EInstrumentKinds.피아노
                        select new { goods, instrument };

            List<InstrumentViewModel> viewModels = new List<InstrumentViewModel>();

            if (query.Any())
            {
                foreach (var i in query)
                {
                    viewModels.Add(new InstrumentViewModel
                    {
                        GoodsNumber = i.goods.GoodsNumber,
                        GoodsName = i.goods.GoodsName,
                        ImgSrc = i.goods.ImgSrc,
                        Brand = i.goods.Brand,
                        Price = i.goods.Price
                    });

                }
            }

            return viewModels;
        }

        // 악기 상세 정보
        public InstrumentViewModel selectOneInstrument(int id)
        {
            Goods goods = _context.Goods.Where(i => i.GoodsNumber == id).FirstOrDefault();

            InstrumentViewModel viewModel = new InstrumentViewModel
            {
                GoodsNumber = goods.GoodsNumber,
                ImgSrc = goods.ImgSrc,
                GoodsName = goods.GoodsName,
                Price = goods.Price,
                Brand = goods.Brand,
                Stock = goods.Stock
            };

            return viewModel;
        }

        // 악기 수량 갱신
        public void UpdateGoods(InstrumentViewModel model)
        {
            Goods goods = _context.Goods.Where(i => i.GoodsNumber == model.GoodsNumber).FirstOrDefault();

            if(goods.Stock > 0)
            {
                goods.Stock--;
                _context.SaveChanges();
            }
        }











        // 부속품 전체 조회
        public IEnumerable<Part> PartAllSelect()
        {
            return _context.Parts.ToList();
        }

        // 기타상품 전체 조회
        public IEnumerable<Ect> EctAllSelect()
        {
            return _context.Ects.ToList();
        }

        




        // 상품 검색

    }
}
