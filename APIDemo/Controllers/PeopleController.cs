using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDemo.Models;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DemoContext _context;

        public PeopleController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemoModel>>> GetDemoModel()
        {
          if (_context.DemoModel == null)
          {
              return NotFound();
          }
            return await _context.DemoModel.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DemoModel>> GetDemoModel(int id)
        {
          if (_context.DemoModel == null)
          {
              return NotFound();
          }
            var demoModel = await _context.DemoModel.FindAsync(id);

            if (demoModel == null)
            {
                return NotFound();
            }

            return demoModel;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemoModel(int id, DemoModel demoModel)
        {
            if (id != demoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(demoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DemoModel>> PostDemoModel(DemoModel demoModel)
        {
          if (_context.DemoModel == null)
          {
              return Problem("Entity set 'DemoContext.DemoModel'  is null.");
          }
            _context.DemoModel.Add(demoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemoModel", new { id = demoModel.Id }, demoModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemoModel(int id)
        {
            if (_context.DemoModel == null)
            {
                return NotFound();
            }
            var demoModel = await _context.DemoModel.FindAsync(id);
            if (demoModel == null)
            {
                return NotFound();
            }

            _context.DemoModel.Remove(demoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DemoModelExists(int id)
        {
            return (_context.DemoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
