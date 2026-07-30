namespace GamesStoreApi.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
    }
}
