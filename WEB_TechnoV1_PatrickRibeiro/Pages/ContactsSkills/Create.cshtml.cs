using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_TechnoV1_PatrickRibeiro.Data;
using WEB_TechnoV1_PatrickRibeiro.Models;

namespace WEB_TechnoV1_PatrickRibeiro.Pages.ContactsSkills
{
    public class CreateModel : PageModel
    {
        private readonly WEB_TechnoV1_PatrickRibeiro.Data.APIContext _context;

        public CreateModel(WEB_TechnoV1_PatrickRibeiro.Data.APIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contacts Contacts { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contacts.Add(Contacts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
