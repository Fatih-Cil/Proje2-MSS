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
    public class AuthorityManager : IAuthorityService
    {
        IAuthorityDal _authorityDal;

        public AuthorityManager(IAuthorityDal authorityDal)
        {
            _authorityDal = authorityDal;
        }

        public List<Authority> GetAll()
        {
            return _authorityDal.GetAll();
        }

        public Authority GetByAuthortiyId(int authorityId)
        {
            return _authorityDal.Get(p => p.AuthorityId == authorityId);
        }
    }
}
