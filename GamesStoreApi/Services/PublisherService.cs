using GamesStoreApi.Data;
using GamesStoreApi.DTOs;
using GamesStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesStoreApi.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly AppDbContext _context;
        
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<bool> DeletePublisherAsync(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                return false;
            }
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<PublisherDto>> GetAllPublishersAsync()
        {
            return await _context.Publishers.Select(g => new PublisherDto
            {
                Id = g.Id,
                Name = g.Name
            })
                .ToListAsync();
        }

        public async Task<PublisherDto?> GetPublisherById(int id)
        {
             return await _context.Publishers
                .Where(p => p.Id == id)
                .Select(p => new PublisherDto
                {
                    Id = p.Id,
                    Name = p.Name

                }).FirstOrDefaultAsync();
            
        }

        public async Task<PublisherDto> CreatePublisherAsync(CreatePublisherDto publisherDto)
        {
            var publisher = new Publisher
            {
                Name = publisherDto.Name
            };
            await _context.Publishers.AddAsync(publisher);

            await _context.SaveChangesAsync();

            return new PublisherDto
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }

        public async Task<bool> UpdatePublisherAsync(int id, UpdatePublisherDto publisherDto)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null) 
            {
                return false;
            }

            publisher.Name = publisherDto.Name;
           
            await _context.SaveChangesAsync();
            
            return true;
        }

    }
}
