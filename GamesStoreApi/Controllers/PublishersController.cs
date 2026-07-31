using GamesStoreApi.Data;
using GamesStoreApi.DTOs;
using GamesStoreApi.Models;
using GamesStoreApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace GamesStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _service;
        public PublishersController (IPublisherService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _service.GetAllPublishersAsync();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var publisher = await _service.GetPublisherById(id);

            if (publisher == null) 
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher(CreatePublisherDto publisherDto)
        {
           var publisher = await _service.CreatePublisherAsync(publisherDto);
            return CreatedAtAction(
                nameof(GetPublisherById),
                new { id = publisher.Id },
                publisher
                );
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisherAsync(int id, UpdatePublisherDto publisherDto)
        {
            var publisher = await _service.UpdatePublisherAsync(id, publisherDto);
            if (!publisher)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id) 
        {
            var publisher = await _service.DeletePublisherAsync(id);

            if (!publisher)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
