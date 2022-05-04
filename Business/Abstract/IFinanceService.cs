using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFinanceService
    {
        List<Finance> GetAll();
        void Add(Finance finance);
        void Update(Finance finance);
        void Delete(Finance finance);

        List<FinanceDetailDTO> GetFinanceDetails();
    }
}
