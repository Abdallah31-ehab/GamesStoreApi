namespace GamesStoreApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price {  get; set; }
       
        public int GenreId { get; set; }
        public int PublisherId { get; set; }

        public Genre Genre { get; set; } = null!;
        public Publisher Publisher { get; set; } = null!;

    }
}
