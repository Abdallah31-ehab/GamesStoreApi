using GamesStoreApi.Data;
using GamesStoreApi.Models;
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
        private readonly AppDbContext _context;
        public PublishersController (AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return Ok(publishers);
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return Ok(publisher);
        }
    }
}
