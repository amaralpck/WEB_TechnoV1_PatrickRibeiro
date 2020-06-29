using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_TechnoV1_PatrickRibeiro.Data;
using WEB_TechnoV1_PatrickRibeiro.Models;

namespace WEB_TechnoV1_PatrickRibeiro.Pages.SkillList
{
    public class DetailsModel : PageModel
    {
        private readonly WEB_TechnoV1_PatrickRibeiro.Data.APISKKContext _context;

        public DetailsModel(WEB_TechnoV1_PatrickRibeiro.Data.APISKKContext context)
        {
            _context = context;
        }

        public Skills Skills { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skills = await _context.Skills.FirstOrDefaultAsync(m => m.id == id);

            if (Skills == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
