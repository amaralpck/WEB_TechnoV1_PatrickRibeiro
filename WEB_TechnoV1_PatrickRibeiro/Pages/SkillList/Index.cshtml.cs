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
    public class IndexModel : PageModel
    {
        private readonly WEB_TechnoV1_PatrickRibeiro.Data.APISKKContext _context;
        public int numContact;
        public IndexModel(WEB_TechnoV1_PatrickRibeiro.Data.APISKKContext context)
        {
            _context = context;
            //numContact = Int32.Parse(Request.Query["id"].ToString());
        }

        public IList<Skills> Skills { get;set; }
        public IList<Contacts> Contacts { get; set; }
        public async Task OnGetAsync()
        {
            Skills = await _context.Skills.ToListAsync();
        }
    }
}
