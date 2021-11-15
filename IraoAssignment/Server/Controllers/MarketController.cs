using System.Threading.Tasks;
using IraoAssignment.Server.Data;
using IraoAssignment.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IraoAssignment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public MarketController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Markets.ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var market = await _context.Markets.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(market);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Market developer)
        {
            _context.Add(developer);
            await _context.SaveChangesAsync();
            return Ok(developer.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Market developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var market = new Market() { Id = id };
            _context.Remove(market);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}