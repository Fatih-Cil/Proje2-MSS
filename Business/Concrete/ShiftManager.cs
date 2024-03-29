﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShiftManager : IShiftService
    {
        IShiftDal _shiftDal;

        public ShiftManager(IShiftDal shiftDal)
        {
            _shiftDal = shiftDal;
        }

        public void Add(Shift shift)
        {
            _shiftDal.Add(shift);
        }

        public void Delete(Shift shift)
        {
            _shiftDal.Delete(shift);
        }

        public List<Shift> GetAll()
        {
            return _shiftDal.GetAll();
        }

        public List<Shift> GetByActiveAll(bool status)
        {
            return _shiftDal.GetAll(p=>p.Status==status);
        }

        public Shift GetByShiftId(int shiftId)
        {
            return _shiftDal.Get(p => p.ShiftId == shiftId);
        }

        public void Update(Shift shift)
        {
            _shiftDal.Update(shift);
        }
    }
}
