using System.ComponentModel.DataAnnotations;

namespace GamesStoreApi.DTOs
{
    public class UpdateGameDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        [Range(1, int.MaxValue)]
        public int PublisherId { get; set; } 
    }
}
