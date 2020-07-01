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
    [Route("api/quotations")]
    [ApiController]
    public class QuotationsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public QuotationsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Quotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotation()
        {
            return await _context.Quotation.ToListAsync();
        }

        // GET: api/Quotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quotation>> GetQuotation(int id)
        {
            var quotation = await _context.Quotation.FindAsync(id);

            if (quotation == null)
            {
                return NotFound();
            }

            return quotation;
        }

        // PUT: api/Quotations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotation(int id, Quotation quotation)
        {
            if (id != quotation.QuotationId)
            {
                return BadRequest();
            }

            _context.Entry(quotation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotationExists(id))
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

        // POST: api/Quotations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quotation>> PostQuotation(Quotation quotation)
        {
            _context.Quotation.Add(quotation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuotation", new { id = quotation.QuotationId }, quotation);
        }

        // DELETE: api/Quotations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quotation>> DeleteQuotation(int id)
        {
            var quotation = await _context.Quotation.FindAsync(id);
            if (quotation == null)
            {
                return NotFound();
            }

            _context.Quotation.Remove(quotation);
            await _context.SaveChangesAsync();

            return quotation;
        }

        private bool QuotationExists(int id)
        {
            return _context.Quotation.Any(e => e.QuotationId == id);
        }
    }
}
