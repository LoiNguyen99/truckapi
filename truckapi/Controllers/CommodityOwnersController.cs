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
    [Route("api/commodity-owners")]
    [ApiController]
    public class CommodityOwnersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CommodityOwnersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/CommodityOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommodityOwner>>> GetCommodityOwner()
        {
            return await _context.CommodityOwner.ToListAsync();
        }

        // GET: api/CommodityOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommodityOwner>> GetCommodityOwner(int id)
        {
            var commodityOwner = await _context.CommodityOwner.FindAsync(id);

            if (commodityOwner == null)
            {
                return NotFound();
            }

            return commodityOwner;
        }

        // PUT: api/CommodityOwners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommodityOwner(int id, CommodityOwner commodityOwner)
        {
            if (id != commodityOwner.CommodityOwnerId)
            {
                return BadRequest();
            }

            _context.Entry(commodityOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommodityOwnerExists(id))
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

        // POST: api/CommodityOwners
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommodityOwner>> PostCommodityOwner(CommodityOwner commodityOwner)
        {
            _context.CommodityOwner.Add(commodityOwner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommodityOwner", new { id = commodityOwner.CommodityOwnerId }, commodityOwner);
        }

        // DELETE: api/CommodityOwners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommodityOwner>> DeleteCommodityOwner(int id)
        {
            var commodityOwner = await _context.CommodityOwner.FindAsync(id);
            if (commodityOwner == null)
            {
                return NotFound();
            }

            _context.CommodityOwner.Remove(commodityOwner);
            await _context.SaveChangesAsync();

            return commodityOwner;
        }

        private bool CommodityOwnerExists(int id)
        {
            return _context.CommodityOwner.Any(e => e.CommodityOwnerId == id);
        }
    }
}
