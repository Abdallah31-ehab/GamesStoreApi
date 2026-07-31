using Microsoft.AspNetCore.Mvc;
using GamesStoreApi.DTOs;
using GamesStoreApi.Services;

namespace GamesStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;

        public GamesController(IGameService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {

            var game = await _service.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _service.GetAllGamesAsync();
            return Ok(games);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddGame(CreateGameDto gameDto)
        {
            var game = await _service.CreateGameAsync(gameDto);
            
            return CreatedAtAction(
                nameof(GetGameById),
                new { id = game.Id },
                game);

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, UpdateGameDto gameDto)
        {
            var result = await _service.UpdateGameAsync(id, gameDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();   
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
           var result = await _service.DeleteGameAsync(id);

            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
