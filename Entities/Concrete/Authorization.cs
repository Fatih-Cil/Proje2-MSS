using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Authorization: IEntity
    {
        public int AuthId { get; set; }
        public string AuthName { get; set; }
        public string Comment { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
