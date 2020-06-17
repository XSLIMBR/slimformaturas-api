using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompanyController : ControllerBase
    {
        private readonly MssqlContext _context;

        public ShippingCompanyController(MssqlContext context)
        {
            _context = context;
        }

        // GET: api/ShippingCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingCompany>>> GetShippingCompany()
        {
            return await _context.ShippingCompany.ToListAsync();
        }

        // GET: api/ShippingCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingCompany>> GetShippingCompany(string id)
        {
            var shippingCompany = await _context.ShippingCompany.FindAsync(id);

            if (shippingCompany == null)
            {
                return NotFound();
            }

            return shippingCompany;
        }

        // PUT: api/ShippingCompany/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingCompany(string id, ShippingCompany shippingCompany)
        {
            if (id != shippingCompany.ShippingCompanyId)
            {
                return BadRequest();
            }

            _context.Entry(shippingCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingCompanyExists(id))
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

        // POST: api/ShippingCompany
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShippingCompany>> PostShippingCompany(ShippingCompany shippingCompany)
        {
            _context.ShippingCompany.Add(shippingCompany);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShippingCompanyExists(shippingCompany.ShippingCompanyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShippingCompany", new { id = shippingCompany.ShippingCompanyId }, shippingCompany);
        }

        // DELETE: api/ShippingCompany/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShippingCompany>> DeleteShippingCompany(string id)
        {
            var shippingCompany = await _context.ShippingCompany.FindAsync(id);
            if (shippingCompany == null)
            {
                return NotFound();
            }

            _context.ShippingCompany.Remove(shippingCompany);
            await _context.SaveChangesAsync();

            return shippingCompany;
        }

        private bool ShippingCompanyExists(string id)
        {
            return _context.ShippingCompany.Any(e => e.ShippingCompanyId == id);
        }
    }
}
