using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactListDev.Models;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactListController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactListController : ControllerBase
    {
        private readonly ContactDetailContext _context;

        public ContactListController(ContactDetailContext context)
        {
            _context = context;
        }

        // GET: api/Contact
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ContactDetail>>> GetContactDetail()
        {
            return await _context.Contact.ToListAsync();
        }

        // GET api/ContactListController/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ContactDetail>> GetContactDetail(int id)
        {
            var contactDetail = await _context.Contact.FindAsync(id);

            if (contactDetail == null)
            {
                return NotFound();
            }

            return contactDetail;
        }

        // POST api/ContactListController
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ContactDetail>> PostContactDetail(ContactDetail contactDetail)
        {
            _context.Contact.Add(contactDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactDetail", new { id = contactDetail.id, name = contactDetail.Name, contactDetail });
        }

        // PUT api/ContactListController/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutContactDetails(int id, ContactDetail contactDetail)
        {
            if (id != contactDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(contactDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailExists(id))
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


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteContactDetail(int id)
        {
            var contactDetail = await _context.Contact.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contactDetail);
            await _context.SaveChangesAsync();

            return NoContent();

        }


        private bool ContactDetailExists(int id)
        {
            return _context.Contact.Any(x => x.id == id);
        }
    }
}
