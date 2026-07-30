using GamesStoreApi.Data;
using GamesStoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace GamesStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GenresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(Genre genre) 
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return Ok(genre);
        }
    }
}
