using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetCoreRazorEFCoreSchool.Models;
using NetCoreRazorEFCoreSchool.Data;

namespace NetCoreRazorEFCoreSchool.Pages.Students
{
  public class DeleteModel : PageModel
  {
    private readonly NetCoreRazorEFCoreSchool.Data.SchoolContext _context;

    public DeleteModel(NetCoreRazorEFCoreSchool.Data.SchoolContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Student Student { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Students == null)
      {
        return NotFound();
      }

      var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);

      if (student == null)
      {
        return NotFound();
      }
      else
      {
        Student = student;
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.Students == null)
      {
        return NotFound();
      }
      var student = await _context.Students.FindAsync(id);

      if (student != null)
      {
        Student = student;
        _context.Students.Remove(Student);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
