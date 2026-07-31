namespace GamesStoreApi.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
    }
}
