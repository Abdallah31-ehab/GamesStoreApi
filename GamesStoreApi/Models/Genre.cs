namespace GamesStoreApi.Models
{
    public class Genre
    {
        public int id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
