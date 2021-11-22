using System.Linq;
using System.Threading.Tasks;
using IraoAssignment.Server.Data;
using IraoAssignment.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IraoAssignment.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketWithCompanyAndPriceController : ControllerBase
    {
        readonly IraoAssignmentDbContext _context;

        public MarketWithCompanyAndPriceController(IraoAssignmentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var temp = _context.MarketWithCompanyAndPrices.ToList();

            var companies = await _context.Companies.ToListAsync();
            var markets = await _context.Markets.ToListAsync();
            
            var marketWithCompanyAndPrices = await _context.MarketWithCompanyAndPrices.ToListAsync();
            return Ok(marketWithCompanyAndPrices);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var marketWithCompanyAndPrice = await _context.MarketWithCompanyAndPrices.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(marketWithCompanyAndPrice);
        }
        [HttpPost]
        public async Task<IActionResult> Post(MarketWithCompanyAndPrice marketWithCompanyAndPrice)
        {
            _context.Add(marketWithCompanyAndPrice);
            await _context.SaveChangesAsync();
            return Ok(marketWithCompanyAndPrice.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MarketWithCompanyAndPrice marketWithCompanyAndPrice)
        {
            _context.Entry(marketWithCompanyAndPrice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var marketWithCompanyAndPrice = new MarketWithCompanyAndPrice { Id = id };
            _context.Remove(marketWithCompanyAndPrice);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}