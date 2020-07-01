using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using truckapi;
using truckapi.Models;

namespace truckapi.Controllers
{
    [Route("api/recivers")]
    [ApiController]
    public class ReciversController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ReciversController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Recivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reciver>>> GetReciver()
        {
            return await _context.Reciver.ToListAsync();
        }

        // GET: api/Recivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reciver>> GetReciver(int id)
        {
            var reciver = await _context.Reciver.FindAsync(id);

            if (reciver == null)
            {
                return NotFound();
            }

            return reciver;
        }

        // PUT: api/Recivers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciver(int id, Reciver reciver)
        {
            if (id != reciver.ReciverId)
            {
                return BadRequest();
            }

            _context.Entry(reciver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciverExists(id))
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

        // POST: api/Recivers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reciver>> PostReciver(Reciver reciver)
        {
            _context.Reciver.Add(reciver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReciver", new { id = reciver.ReciverId }, reciver);
        }

        // DELETE: api/Recivers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reciver>> DeleteReciver(int id)
        {
            var reciver = await _context.Reciver.FindAsync(id);
            if (reciver == null)
            {
                return NotFound();
            }

            _context.Reciver.Remove(reciver);
            await _context.SaveChangesAsync();

            return reciver;
        }

        private bool ReciverExists(int id)
        {
            return _context.Reciver.Any(e => e.ReciverId == id);
        }
    }
}
