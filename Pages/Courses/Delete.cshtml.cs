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
  public class DeleteModel : DepartmentNamePageModel
  {
    private readonly NetCoreRazorEFCoreSchool.Data.SchoolContext _context;

    public DeleteModel(NetCoreRazorEFCoreSchool.Data.SchoolContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Course Course { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Courses == null)
      {
        return NotFound();
      }

      Course = await _context.Courses
          .AsNoTracking()
          .Include(c => c.Department)
          .FirstOrDefaultAsync(m => m.CourseID == id);

      if (Course == null)
      {
        return NotFound();
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.Courses == null)
      {
        return NotFound();
      }
      var course = await _context.Courses.FindAsync(id);

      if (course != null)
      {
        Course = course;
        _context.Courses.Remove(Course);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
