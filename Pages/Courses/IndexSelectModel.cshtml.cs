using NetCoreRazorEFCoreSchool.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreRazorEFCoreSchool.Pages.Courses
{
  public class IndexSelectModel : PageModel
  {
    private readonly NetCoreRazorEFCoreSchool.Data.SchoolContext _context;

    public IndexSelectModel(NetCoreRazorEFCoreSchool.Data.SchoolContext context)
    {
      _context = context;
    }

    public IList<CourseViewModel> CourseVM { get; set; }

    public async Task OnGetAsync()
    {
      CourseVM = await _context.Courses
        .Select(p => new CourseViewModel
        {
          CourseID = p.CourseID,
          Title = p.Title,
          Credits = p.Credits,
          DepartmentName = p.Department.Name
        }).ToListAsync();
    }
  }
}