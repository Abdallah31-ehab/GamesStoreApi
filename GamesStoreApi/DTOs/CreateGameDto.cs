using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace GamesStoreApi.DTOs
{
    public class CreateGameDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
    }
}
