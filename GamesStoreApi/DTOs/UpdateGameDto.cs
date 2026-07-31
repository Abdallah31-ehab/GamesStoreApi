namespace GamesStoreApi.DTOs
{
    public class UpdateGameDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; } 
    }
}
