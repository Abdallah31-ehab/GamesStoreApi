using GamesStoreApi.DTOs;
namespace GamesStoreApi.Services
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllGenresAsync();
        Task<GenreDto?> GetGenreByIdAsync(int id);
        Task<GenreDto> CreatGenreAsync(CreateGenreDto genreDto);
        Task<bool> UpdateGenreAsync(int id, UpdateGenreDto genreDto);
        Task<bool> DeleteGenreAsync(int id);
    }
}
