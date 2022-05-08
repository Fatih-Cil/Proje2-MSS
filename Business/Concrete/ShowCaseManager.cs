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
    public class ShowCaseManager : IShowCaseService
    {
        IShowCaseDal _showCaseDal;

        public ShowCaseManager(IShowCaseDal showCaseDal)
        {
            _showCaseDal = showCaseDal;
        }

        public void Add(ShowCase showCase)
        {
            _showCaseDal.Add(showCase);
        }

        public void Delete(ShowCase showCase)
        {
            _showCaseDal.Delete(showCase);
        }

        public List<ShowCase> GetAll()
        {
            return _showCaseDal.GetAll();
        }

        public List<ShowCaseDetailDTO> GetShowCaseDetails()
        {
            return _showCaseDal.GetShowCaseDatails();
        }

        public void Update(ShowCase showCase)
        {
            _showCaseDal.Update(showCase);
        }
    }
}
