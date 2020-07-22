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
    [Route("api/requests")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public RequestsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest(String status, String driverId)
        {
            if (driverId == null)
            {
                if (status == null || status.Length == 0)
                {
                    return await _context.Request.Include(r => r.CommodityOwner.Address.Places)
                        .Include(r => r.Reciver.Address.Places)
                        .Include(r => r.Quotations).ThenInclude(q => q.Driver)
                        .Include(r => r.Status).OrderBy(r => r.StatusId).ThenByDescending(r => r.DateCreate)
                        .ToListAsync();
                }
                else
                {
                    return await _context.Request.Include(r => r.CommodityOwner.Address.Places)
                            .Include(r => r.Reciver.Address.Places)
                            .Include(r => r.Quotations).ThenInclude(q => q.Driver)
                            .Include(r => r.Status).OrderBy(r => r.StatusId).ThenByDescending(r => r.DateCreate)
                            .Where(r => r.StatusId == int.Parse(status))
                            .ToListAsync();
                }
            }
            else
            {
                List<Request> requests = await _context.Request.Include(r => r.CommodityOwner.Address.Places).Include(r => r.Reciver.Address.Places)
                            .Include(r => r.User)
                            .Include(r => r.Quotations).ThenInclude(q => q.Driver)
                            .Include(r => r.Status).OrderBy(r => r.StatusId).ThenByDescending(r => r.DateCreate)
                            .Where(r => r.StatusId == int.Parse(status))
                            .ToListAsync();
                List<Request> removeRequests = new List<Request>();
                foreach (Request request in requests)
                {
                    if (request.Quotations.Any(q => q.DriverId == driverId))
                    {
                        removeRequests.Add(request);
                    }
                }

                foreach (Request request1 in removeRequests)
                {
                    requests.Remove(request1);
                }

                return requests;
            }

        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Request.Include(r => r.CommodityOwner.Address.Places)
                    .Include(r => r.Reciver.Address.Places).FirstAsync(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Request.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.RequestId }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.RequestId == id);
        }
    }
}
