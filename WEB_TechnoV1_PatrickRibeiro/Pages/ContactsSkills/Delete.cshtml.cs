using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_TechnoV1_PatrickRibeiro.Data;
using WEB_TechnoV1_PatrickRibeiro.Models;

namespace WEB_TechnoV1_PatrickRibeiro.Pages.ContactsSkills
{
    public class DeleteModel : PageModel
    {
        private readonly WEB_TechnoV1_PatrickRibeiro.Data.APIContext _context;

        public DeleteModel(WEB_TechnoV1_PatrickRibeiro.Data.APIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contacts Contacts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.id == id);

            if (Contacts == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contacts = await _context.Contacts.FindAsync(id);

            if (Contacts != null)
            {
                _context.Contacts.Remove(Contacts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
