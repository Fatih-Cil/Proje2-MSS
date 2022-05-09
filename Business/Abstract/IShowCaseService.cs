using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShowCaseService
    {
        List<ShowCase> GetAll();
        void Add(ShowCase showCase);
        void Update(ShowCase showCase);
        void Delete(ShowCase showCase);
        ShowCase GetByShowCaseURL(string url);

        List<ShowCaseDetailDTO> GetShowCaseDetails();
    }
}
