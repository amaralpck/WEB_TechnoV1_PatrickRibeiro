using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using WEB_TechnoV1_PatrickRibeiro.Data;
using WEB_TechnoV1_PatrickRibeiro.Models;

namespace WEB_TechnoV1_PatrickRibeiro.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly APISKKContext _contextSK;

        public ContactsController(APIContext context,APISKKContext contextSK)
        {
            _context = context;
            _contextSK = contextSK;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacts>> GetContacts(int id)
        {
            var contacts = await _context.Contacts.FindAsync(id);

            if (contacts == null)
            {
                return NotFound();
            }

            return contacts;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacts(int id, Contacts contacts)
        {
            if (id != contacts.id)
            {
                return BadRequest();
            }

            _context.Entry(contacts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsExists(id))
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

        // POST: api/Contacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contacts>> PostContacts(Contacts contacts)
        {
            _context.Contacts.Add(contacts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContacts", new { id = contacts.id }, contacts);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contacts>> DeleteContacts(int id)
        {
            var contacts = await _context.Contacts.FindAsync(id);
            if (contacts == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contacts);
           
            //_contextSK.Skills.Remove(contactAll.id);
            await _context.SaveChangesAsync();

            return contacts;
        }

        /*SKILLS***************************************************/


        // GET: api/Skills
        [HttpGet("Skills")]
        public async Task<ActionResult<IEnumerable<Skills>>> GetSkills()
        {
            return await _contextSK.Skills.ToListAsync();
        }

        // GET: api/Skills/5
        [HttpGet("Skills/{id}")]
        public async Task<ActionResult<Skills>> GetSkills(int id)
        {
            var skills = await _contextSK.Skills.FindAsync(id);

            if (skills == null)
            {
                return NotFound();
            }

            return skills;
        }

        // PUT: api/Skills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Skills/{id}")]
        public async Task<IActionResult> PutSkills(int id, Skills skills)
        {
            if (id != skills.id)
            {
                return BadRequest();
            }

            _contextSK.Entry(skills).State = EntityState.Modified;

            try
            {
                await _contextSK.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillsExists(id))
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

        // POST: api/Skills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Skills")]
        public async Task<ActionResult<Skills>> PostSkills(Skills skills)
        {
            _contextSK.Skills.Add(skills);
            await _contextSK.SaveChangesAsync();

            return CreatedAtAction("GetContacts", new { id = skills.id }, skills);
        }

        // DELETE: api/Skills/5
        [HttpDelete("Skills/{id}")]
        public async Task<ActionResult<Skills>> DeleteSkills(int id)
        {
            var skills = await _contextSK.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }

            _contextSK.Skills.Remove(skills);
            await _contextSK.SaveChangesAsync();

            return skills;
        }

        // DELETE: api/AllSkillsForOneContact/5
        [HttpDelete("AllSkillsForOneContact/{id_contact}")]
        public void DeleteSkillsAll(int id_contact)
        {
            _contextSK.Skills.Where(s => s.id_contact == id_contact).ToList().ForEach(s => _contextSK.Skills.Remove(s));
            _contextSK.SaveChanges();
        }


        private bool ContactsExists(int id)
        {
            return _context.Contacts.Any(e => e.id == id);
        }

        private bool SkillsExists(int id)
        {
            return _contextSK.Skills.Any(e => e.id == id);
        }

    }
}
