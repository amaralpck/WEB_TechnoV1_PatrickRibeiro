using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_TechnoV1_PatrickRibeiro.Data;
using WEB_TechnoV1_PatrickRibeiro.Models;

namespace WEB_TechnoV1_PatrickRibeiro.Pages.SkillList
{
    public class CreateModel : PageModel
    {
        private readonly WEB_TechnoV1_PatrickRibeiro.Data.APISKKContext _context;
        public string numContact;
        public CreateModel(WEB_TechnoV1_PatrickRibeiro.Data.APISKKContext context)
        {
            _context = context;
            
        }

        public IActionResult OnGet()
        {
            numContact = Request.Query["id"].ToString();
            return Page();
        }

        [BindProperty]
        public Skills Skills { get; set; }

        public Contacts Contacts { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Skills.Add(Skills);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
