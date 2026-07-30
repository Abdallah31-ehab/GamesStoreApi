using GamesStoreApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using GamesStoreApi.Models;
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
       
        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _service.GetALLGamesAsync ();
            return Ok(games);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
          
            var game = await _service.GetGameByIdAsync(id);
            if(game == null)
            {
                return NotFound();
            }
            return Ok(game); 
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(CreateGameDto gameDto)
        {
            var game = await _service.CreateGameAsync(gameDto);
            return Ok(game);
           
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, UpdateGameDto gameDto)
        {
            var result = await _service.UpdateGameAsync(id, gameDto);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
            
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
