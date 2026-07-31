using GamesStoreApi.DTOs;

namespace GamesStoreApi.Services
{
    public interface IPublisherService
    {
        Task<List<PublisherDto>> GetAllPublishersAsync();
        Task<PublisherDto?> GetPublisherById(int id);
        Task<PublisherDto> CreatePublisherAsync(CreatePublisherDto publisherDto);
        Task<bool> UpdatePublisherAsync(int id, UpdatePublisherDto publisherDto);
        Task<bool> DeletePublisherAsync(int id);
    }
}
