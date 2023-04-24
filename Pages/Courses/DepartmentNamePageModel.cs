using NetCoreRazorEFCoreSchool.Data;
using NetCoreRazorEFCoreSchool.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NetCoreRazorEFCoreSchool.Pages.Courses
{
  public class DepartmentNamePageModel : PageModel
  {
    public SelectList DepartmentNameSL { get; set; }

    public void PopulateDepartmentsDropDownList(SchoolContext _context,
        object selectedDepartment = null)
    {
      var departmentsQuery = from d in _context.Departments
                             orderby d.Name // Sort by name.
                             select d;

      DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(),
          nameof(Department.DepartmentID),
          nameof(Department.Name),
          selectedDepartment);
    }
  }
}