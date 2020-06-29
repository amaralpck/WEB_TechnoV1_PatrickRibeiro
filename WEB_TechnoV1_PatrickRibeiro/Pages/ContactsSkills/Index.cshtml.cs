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
    public class IndexModel : PageModel
    {
        private readonly WEB_TechnoV1_PatrickRibeiro.Data.APIContext _context;

        public IndexModel(WEB_TechnoV1_PatrickRibeiro.Data.APIContext context)
        {
            _context = context;
        }

        public IList<Contacts> Contacts { get;set; }

        public async Task OnGetAsync()
        {
            Contacts = await _context.Contacts.ToListAsync();
        }
    }
}
