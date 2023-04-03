using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutomationBotAPI.DataContext;
using AutomationBotAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace AutomationBotAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class AutomationsController : ControllerBase
    {
        private readonly AutomationDBContext _context;

        public AutomationsController(AutomationDBContext context)
        {
            _context = context;
        }

        // GET: api/Automations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automation>>> GetAutomations()
        {
          if (_context.Automations == null)
          {
              return NotFound();
          }
            return await _context.Automations.ToListAsync();
        }

        // GET: api/Automations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Automation>> GetAutomation(int id)
        {
          if (_context.Automations == null)
          {
              return NotFound();
          }
            var automation = await _context.Automations.FindAsync(id);

            if (automation == null)
            {
                return NotFound();
            }

            return automation;
        }

        // POST: api/Automations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Automation>> PostAutomation(Automation automation)
        {
          if (_context.Automations == null)
          {
              return Problem("Entity set 'AutomationDBContext.Automations'  is null.");
          }
            _context.Automations.Add(automation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutomation", new { id = automation.Id }, automation);
        }

        private bool AutomationExists(int id)
        {
            return (_context.Automations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
