using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShopService
    {
        List<Shop> GetAll();
        List<Shop> GetByActiveAll(bool status);
        Shop GetByShopId(int shopId);
        void Add(Shop shop);
        void Delete(Shop shop);
        void Update(Shop shop);
    }
}
