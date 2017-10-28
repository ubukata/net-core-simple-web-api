using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers
{
    [Route("api/[controller]")]
    public class PartiesController : Controller
    {
        private Lab6Context _context;

        public PartiesController(Lab6Context context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Parties.ToArrayAsync());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "PartyGet")]
        public async Task<IActionResult> Get(int id)
        {
            var party = await _context.Parties.FirstOrDefaultAsync(_ => _.PartyId == id);

            if (party == null)
            {
                return NotFound();
            }

            return Ok(party);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Party model)
        {
            try
            {
                _context.Parties.Add(model);
                await _context.SaveChangesAsync();
                if (model.PartyId != 0)
                {
                    var url = Url.Link("PartyGet", new { id = model.PartyId });
                    return Created(url, model);
                }

                return BadRequest("Could not add new party");
            }
            catch (Exception ex)
            {
                return BadRequest("Could not add new party: " + ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Party model)
        {
            try
            {
                var party = await _context.Parties.FirstOrDefaultAsync(_ => _.PartyId == id);

                if (party == null)
                {
                    return NotFound();
                }

                party.Address = model.Address;
                party.ExpectedNumberOfGuests = model.ExpectedNumberOfGuests;
                party.PartyDate = model.PartyDate;
                party.PartyName = model.PartyName;

                if (await _context.SaveChangesAsync() > 0)
                {
                    return NoContent();
                }

                return BadRequest("Could not update party");
            }
            catch (Exception ex)
            {
                return BadRequest("Could not update party: " + ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var party = await _context.Parties.FirstOrDefaultAsync(_ => _.PartyId == id);

                if (party == null)
                {
                    return NotFound();
                }

                _context.Parties.Remove(party);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return NoContent();
                }

                return BadRequest("Could not delete party");
            }
            catch (Exception ex)
            {
                return BadRequest("Could not delete party: " + ex.Message);
            }
        }
    }
}