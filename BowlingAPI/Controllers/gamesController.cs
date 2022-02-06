using BowlingAPI.Models;
using BowlingAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public gamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpPost(" (create game)")]
        public async Task<ActionResult<Game>> PostBooks([FromBody] Game game)
        {
            var newGame = await _gameRepository.Create(game);
            return CreatedAtAction(nameof(GetGames), new { id = newGame.Id }, newGame);
        }

        [HttpDelete("{:id} (delete game)")]
        public async Task<ActionResult> Delete(int id)
        {
            var gameToDelete = await _gameRepository.Get(id);
            if (gameToDelete == null)
                return NotFound();

            await _gameRepository.Delete(gameToDelete.Id);
            return NoContent();
        }

        [HttpGet("{:id} (read game)")]
        public async Task<ActionResult<Game>> GetGames(int id)
        {
            return await _gameRepository.Get(id);
        }

        [HttpPut("{:id} (update game)")]
        public async Task<ActionResult> PutGames(int id, [FromBody] Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            await _gameRepository.Update(game);

            return NoContent();
        }
    }
}
