using System.ComponentModel.DataAnnotations;

namespace GamesStoreApi.DTOs
{
    public class UpdatePublisherDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

    }
}
