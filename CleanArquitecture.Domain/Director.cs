using CleanArquitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Domain
{
    public class Director : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int VideoId { get; set; }
        public virtual Video? Video { get; set; }
    }
}
