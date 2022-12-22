using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project_Accepted.Models;

namespace API_Project_Accepted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchOddsController : ControllerBase
    {
        private readonly Accepted_ApiContext _context;

        public MatchOddsController(Accepted_ApiContext context)
        {
            _context = context;
        }

        // GET: api/MatchOdds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchOdds>>> GetMatchOdds()
        {
            return await _context.MatchOdds.ToListAsync();
        }

        // GET: api/MatchOdds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchOdds>> GetMatchOdds(int id)
        {
            var matchOdds = await _context.MatchOdds.FindAsync(id);

            if (matchOdds == null)
            {
                return NotFound();
            }

            return matchOdds;
        }

        // PUT: api/MatchOdds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchOdds(int id, MatchOdds matchOdds)
        {
            if (id != matchOdds.Id)
            {
                return BadRequest();
            }

            _context.Entry(matchOdds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchOddsExists(id))
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

        // POST: api/MatchOdds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MatchOdds>> PostMatchOdds(MatchOdds matchOdds)
        {
            _context.MatchOdds.Add(matchOdds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchOdds", new { id = matchOdds.Id }, matchOdds);
        }

        // DELETE: api/MatchOdds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MatchOdds>> DeleteMatchOdds(int id)
        {
            var matchOdds = await _context.MatchOdds.FindAsync(id);
            if (matchOdds == null)
            {
                return NotFound();
            }

            _context.MatchOdds.Remove(matchOdds);
            await _context.SaveChangesAsync();

            return matchOdds;
        }

        private bool MatchOddsExists(int id)
        {
            return _context.MatchOdds.Any(e => e.Id == id);
        }
    }
}
