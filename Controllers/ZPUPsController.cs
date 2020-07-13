using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZPUPsController : ControllerBase
    {
        private readonly ZPUPContext _context;

        public ZPUPsController(ZPUPContext context)
        {
            _context = context;
        }

        // GET: api/ZPUPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZPUP>>> GetZPUPs()
        {
            return await _context.ZPUPs.ToListAsync();
        }

        // GET: api/ZPUPs/5
        [HttpGet("{UserId} {IPAddress}")]
        public async Task<ActionResult<ZPUP>> GetZPUP(int UserId, string ipAddress)
        {
            var zPUP = await _context.ZPUPs.FindAsync(UserId, ipAddress);

            if (zPUP == null)
            {
                return NotFound();
            }

            return zPUP;
        }

        // PUT: api/ZPUPs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZPUP(int id, ZPUP zPUP)
        {
            if (id != zPUP.ZPUPId)
            {
                return BadRequest();
            }

            _context.Entry(zPUP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZPUPExists(id))
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

        // POST: api/ZPUPs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ZPUP>> PostZPUP(ZPUP zPUP)
        {
            _context.ZPUPs.Add(zPUP);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetZPUP), new { id = zPUP.ZPUPId }, zPUP);
        }

        // DELETE: api/ZPUPs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ZPUP>> DeleteZPUP(int id)
        {
            var zPUP = await _context.ZPUPs.FindAsync(id);
            if (zPUP == null)
            {
                return NotFound();
            }

            _context.ZPUPs.Remove(zPUP);
            await _context.SaveChangesAsync();

            return zPUP;
        }

        private bool ZPUPExists(int id)
        {
            return _context.ZPUPs.Any(e => e.ZPUPId == id);
        }
    }
}
