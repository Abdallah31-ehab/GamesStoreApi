using GamesStoreApi.DTOs;
using GamesStoreApi.Models;

namespace GamesStoreApi.Services
{
    public interface IGameService
    {
        Task<List<GameDto>> GetALLGamesAsync();
        Task<GameDto?> GetGameByIdAsync(int id);
        Task<Game> CreateGameAsync(CreateGameDto gameDto);
        Task<bool> UpdateGameAsync(int id, UpdateGameDto gameDto);
        Task<bool> DeleteGameAsync(int id);
       
    }
}
