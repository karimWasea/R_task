using DataAccessLayer;

 
using IReprosastory;

 

using Microsoft.AspNetCore.Mvc.Rendering;

 using System.Data.Entity;
 
namespace ReprestoryServess
{
    

    public class LookupService : Ilookup
    {
        public readonly ApplicationDBcontext _context;

        public LookupService(ApplicationDBcontext context)
        {
            _context = context;
        }



        public IQueryable<SelectListItem> GetAllParentDepartments()
        {
            var departments = _context.Departments



   .Select(x => new SelectListItem { Value = x.ParentDepartment.Id.ToString(), Text = x.ParentDepartment.Name }).AsNoTracking();
            return departments;
        }
    }


}