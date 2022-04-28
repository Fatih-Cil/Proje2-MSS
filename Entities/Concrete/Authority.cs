using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Authority: IEntity
    {
        [Key]
        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }
        public string Comment { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
