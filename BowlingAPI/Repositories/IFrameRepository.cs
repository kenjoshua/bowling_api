using BowlingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Repositories
{
    public interface IFrameRepository
    {
        Task<IEnumerable<Frame>> Get();
        Task<Frame> Get(int id);

        Task<Frame> Create(Frame frame);
        Task Update(Frame frame);
        Task Delete(int id);
    }
}
