using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using donationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace donationAPI.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
      public class DCanditateController : ControllerBase
      {
            private readonly DonationDbContext _context;

            public DCanditateController(DonationDbContext context)
            {
                  _context = context;
            }

            // GET : api/DCanditate
            [HttpGet]
            public async Task<ActionResult<IEnumerable<DCanditate>>> GetCanditates()
            {
                  return await _context.DCanditates.ToListAsync();
            }

            // GET : api/DCanditate/5
            [HttpGet("{id}")]
            public async Task<ActionResult<DCanditate>> GetCanditates(int id)
            {
                  var dCanditate = await _context.DCanditates.FindAsync(id);

                  if (dCanditate == null)
                  {
                        return NotFound();
                  }

                  return dCanditate;
            }

            // PUT : api/DCanditate/5
            [HttpPut("{id}")]
            public async Task<ActionResult> PutDCanditate(int id, DCanditate dCanditate)
            {
                  dCanditate.Id = id;

                  _context.Entry(dCanditate).State = EntityState.Modified;

                  try
                  {
                        await _context.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                        if (!DCanditateExists(id))
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
            // POST : api/DCanditate
            [HttpPost]
            public async Task<ActionResult<DCanditate>> PostCanditate(DCanditate dCanditate)
            {
                  _context.DCanditates.Add(dCanditate);
                  await _context.SaveChangesAsync();

                  return CreatedAtAction(nameof(GetCanditates), new { Id = dCanditate.Id }, dCanditate);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<DCanditate>> DeleteDCanditate(int id)
            {
                  var dCanditate = await _context.DCanditates.FindAsync(id);
                  if (dCanditate == null)
                  {
                        return NotFound();
                  }

                  _context.DCanditates.Remove(dCanditate);
                  await _context.SaveChangesAsync();

                  return dCanditate;
            }
            private bool DCanditateExists(int id)
            {
                  return _context.DCanditates.Any(e => e.Id == id);
            }
      }
}