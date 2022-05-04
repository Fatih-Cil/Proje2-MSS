using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FinanceManager : IFinanceService
    {
        IFinanceDal _financeDal;

        public FinanceManager(IFinanceDal financeDal)
        {
            _financeDal = financeDal;
        }

        public void Add(Finance finance)
        {
            _financeDal.Add(finance);
        }

        public void Delete(Finance finance)
        {
            _financeDal.Delete(finance);
        }

        public List<Finance> GetAll()
        {
            return _financeDal.GetAll();
        }

        public List<FinanceDetailDTO> GetFinanceDetails()
        {
            return _financeDal.GetFinanceDatails();
        }

        public void Update(Finance finance)
        {
            _financeDal.Update(finance);
        }
    }
}
