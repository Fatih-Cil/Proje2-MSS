using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShiftService
    {
        List<Shift> GetAll();
        List<Shift> GetByActiveAll(bool status);
        Shift GetByShiftId(int shiftId);
        void Add(Shift shift);
        void Delete(Shift shift);
        void Update(Shift shift);
    }
}
