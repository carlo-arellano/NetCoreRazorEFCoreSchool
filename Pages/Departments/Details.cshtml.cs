using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetCoreRazorEFCoreSchool.Data;
using NetCoreRazorEFCoreSchool.Models;

namespace NetCoreRazorEFCoreSchool.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly NetCoreRazorEFCoreSchool.Data.SchoolContext _context;

        public DetailsModel(NetCoreRazorEFCoreSchool.Data.SchoolContext context)
        {
            _context = context;
        }

      public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            else 
            {
                Department = department;
            }
            return Page();
        }
    }
}
