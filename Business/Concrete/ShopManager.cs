using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShopManager : IShopService
    {
        IShopDal _shopDal;

        public ShopManager(IShopDal shopDal)
        {
            _shopDal = shopDal;
        }

        public void Add(Shop shop)
        {
            _shopDal.Add(shop);
        }

        public void Delete(Shop shop)
        {
            _shopDal.Delete(shop);
        }

        public List<Shop> GetAll()
        {
            return _shopDal.GetAll();
        }

        public List<Shop> GetByActiveAll(bool status)
        {
            return _shopDal.GetAll(p=>p.Status==status);
        }

        public Shop GetByShopId(int shopId)
        {
            return _shopDal.Get(p => p.ShopId == shopId);
        }

        public void Update(Shop shop)
        {
            _shopDal.Update(shop);
        }
    }
}
