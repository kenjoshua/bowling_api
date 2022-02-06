using BowlingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> Get();
        Task<Game> Get(int id);

        Task<Game> Create(Game game);
        Task Update(Game game);
        Task Delete(int id);
    }
}
