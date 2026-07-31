using GamesStoreApi.Data;
using GamesStoreApi.DTOs;
using GamesStoreApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GamesStoreApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly AppDbContext _context;

        public GenreService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GenreDto> CreatGenreAsync(CreateGenreDto genreDto)
        {
            var genre = new Genre
            {
                Name = genreDto.Name
            };
            await _context.Genres.AddAsync(genre);
           
            await _context.SaveChangesAsync();
            
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };

        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if(genre == null)
            {
                return false;
            }
            
            _context.Genres.Remove(genre);

            await _context.SaveChangesAsync();
           
            return true;

        }

        public async Task<List<GenreDto>> GetAllGenresAsync()
        {
            return await _context.Genres.Select(g => new GenreDto
            {
                Id = g.Id,
                Name = g.Name
            })
                .ToListAsync();
        }

        public async Task<GenreDto?> GetGenreByIdAsync(int id)
        {
            return await _context.Genres
                .Where(g => g.Id == id)
                .Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateGenreAsync(int id, UpdateGenreDto genreDto)
        {
            var genre = await _context.Genres.FindAsync(id);

            if(genre == null)
            {
                return false;
            }
            
            genre.Name = genreDto.Name;

            await _context.SaveChangesAsync();

            return true;

        }
    }
}
