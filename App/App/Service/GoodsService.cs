using App.Models.Entity;
using App.Models.Entity.Interface;
using App.Models.ViewModels;
using App.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service
{
    public class GoodsService : IGoodsService
    {
        private readonly IGoodsRepository _goodsRepository;

        public GoodsService(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }

        // 상품 등록
        // 상품 전체 현황 확인


        // 관악기 리스트
        public IEnumerable<InstrumentViewModel> GetWindList(string id)
        {
            if(id == "Wind")
            {
                return _goodsRepository.WindAllSelect();
            }
            else if (id == "Flute")
            {
                return _goodsRepository.FluteAllSelect();
            }
            else if (id == "Clarinet")
            {
                return _goodsRepository.ClarinetAllSelect();
            }

            return null;
        }

        // 현악기 리스트
        public IEnumerable<InstrumentViewModel> GetStringList()
        {
            return _goodsRepository.StringAllSelect();
        }
        // 피아노 리스트
        public IEnumerable<InstrumentViewModel> GetPianoList()
        {
            return _goodsRepository.PianoAllSelect();
        }

        // 상세 정보
        public InstrumentViewModel GetInstrumentInfo(int id)
        {
            return _goodsRepository.selectOneInstrument(id);
        }





        // 부속품 리스트
        public IEnumerable<Part> GetPartList()
        {
            return _goodsRepository.PartAllSelect();
        }

        // 기타상품 리스트
        public IEnumerable<Ect> GetEctList()
        {
            return _goodsRepository.EctAllSelect();
        }
    }
}
