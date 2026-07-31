using GamesStoreApi.Data;
using GamesStoreApi.DTOs;
using GamesStoreApi.Models;
using GamesStoreApi.Services;
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
        private readonly IGenreService _service;
         
        public GenresController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _service.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id) 
        {
            var genre = _service.GetGenreByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreDto genreDto) 
        {
           var genre =  await _service.CreatGenreAsync(genreDto);

            return CreatedAtAction(
                nameof(GetGenreById),
                new {id = genre.Id},
                genre);

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id,UpdateGenreDto updateGenreDto)
        {
            var genre = await _service.UpdateGenreAsync(id,updateGenreDto);

            if (!genre)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _service.DeleteGenreAsync(id);

            if (!genre)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
