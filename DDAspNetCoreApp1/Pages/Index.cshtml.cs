using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DDAspNetCoreApp1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Console.WriteLine($"入力された名前は：{Name} です。");

            DDExcel.Create(Name);

            DDPdf.Create(Name);

            return Page();
        }
    }
}
