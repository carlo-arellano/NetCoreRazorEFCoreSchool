using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetCoreRazorEFCoreSchool.Data;
using NetCoreRazorEFCoreSchool.Models;

namespace NetCoreRazorEFCoreSchool.Pages.Courses
{
  public class DetailsModel : DepartmentNamePageModel
  {
    private readonly NetCoreRazorEFCoreSchool.Data.SchoolContext _context;

    public DetailsModel(NetCoreRazorEFCoreSchool.Data.SchoolContext context)
    {
      _context = context;
    }

    public Course Course { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Courses == null)
      {
        return NotFound();
      }

      Course = await _context.Courses.AsNoTracking().Include(c => c.Department).FirstOrDefaultAsync();
      if (Course == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
