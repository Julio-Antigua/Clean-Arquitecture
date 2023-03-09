using CleanArquitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IStreamerRepository : IAsyncRepository<Streamer>
    {
    }
}
