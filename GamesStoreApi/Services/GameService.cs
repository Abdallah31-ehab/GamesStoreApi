using GamesStoreApi.Models;
using Microsoft.EntityFrameworkCore;
using GamesStoreApi.Data;
using GamesStoreApi.DTOs;


namespace GamesStoreApi.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Game> CreateGameAsync(CreateGameDto gameDto)
        {
            
            var game = new Game
            {
                Name = gameDto.Name,
                Price = gameDto.Price,
                GenreId = gameDto.GenreId,
                PublisherId = gameDto.PublisherId
            };
            
            await _context.Games.AddAsync(game);

            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<List<GameDto>> GetAllGamesAsync()
        {
            return await _context.Games
                 .Include(g => g.Genre)
                 .Include(g => g.Publisher)
                 .Select(g => new GameDto
                 {
                     Id = g.Id,
                     Name = g.Name,
                     Price = g.Price,
                     GenreName = g.Genre.Name,
                     PublisherName = g.Publisher.Name
                 })
                  .ToListAsync();
        }

        public async Task<GameDto?> GetGameByIdAsync(int id)
        {
            return await _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Publisher)
                .Select(g => new GameDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Price = g.Price,
                    GenreName = g.Genre.Name,
                    PublisherName = g.Publisher.Name

                })
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<bool> UpdateGameAsync(int id, UpdateGameDto gameDto)
        {
            var existing = await _context.Games.FindAsync(id);
            
            if (existing is null)
            {
                return false;
            }

            existing.Name = gameDto.Name;
            existing.Price = gameDto.Price;
            existing.GenreId = gameDto.GenreId;
            existing.PublisherId = gameDto.PublisherId;
           
            await _context.SaveChangesAsync();
           
            return true;
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var existing = await _context.Games.FindAsync(id);

            if (existing is null)
            {
                return false;
            }

            _context.Games.Remove(existing);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
