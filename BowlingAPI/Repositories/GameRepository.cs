using BowlingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContxt _context;

        public GameRepository(GameContxt context)
        {
            this._context = context;
        }
        public async Task<Game> Create(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task Delete(int id)
        {
            var gameToDelete = await _context.Games.FindAsync(id);
            _context.Games.Remove(gameToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> Get()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> Get(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task Update(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
