using BowlingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Repositories
{
    public class FrameRepository : IFrameRepository
    {
        private readonly FrameContxt _context;

        public FrameRepository(FrameContxt context)
        {
            this._context = context;
        }
        public async Task<Frame> Create(Frame frame)
        {
            _context.Frames.Add(frame);
            await _context.SaveChangesAsync();

            return frame;
        }

        public async Task Delete(int id)
        {
            var frameToDelete = await _context.Frames.FindAsync(id);
            _context.Frames.Remove(frameToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Frame>> Get()
        {
            return await _context.Frames.ToListAsync();
        }

        public async Task<Frame> Get(int id)
        {
            return await _context.Frames.FindAsync(id);
        }

        public async Task Update(Frame frame)
        {
            _context.Entry(frame).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
