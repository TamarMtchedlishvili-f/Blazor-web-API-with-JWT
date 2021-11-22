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
    public class CompanyController : ControllerBase
    {
        private readonly IraoAssignmentDbContext _context;

        public CompanyController(IraoAssignmentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Companies.ToListAsync();
            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Company developer)
        {
            _context.Add(developer);
            await _context.SaveChangesAsync();
            return Ok(developer.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Company developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var company = new Company { Id = id };
            _context.Remove(company);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}