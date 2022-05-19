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
    public class VisitorEventManager : IVisitorEventService
    {

        IVisitorEventDal _visitorEventDal;

        public VisitorEventManager(IVisitorEventDal visitorEventDal)
        {
            _visitorEventDal = visitorEventDal;
        }

        public List<VisitorEvent> GetAll()
        {
            return _visitorEventDal.GetAll();
        }

        public List<VisitorDetailDTO> GetVisitorDetails()
        {
            return _visitorEventDal.GetVisitorDetails();
        }
    }
}
