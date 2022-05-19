using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VisitorEvent : IEntity
    {
        [Key]
        public int VisitorId { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string Pozition { get; set; }
        public bool Status { get; set; }
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
