using Microsoft.AspNetCore.Mvc.Rendering;

using ViewModel;

namespace IReprosastory
{
    public interface Ilookup
    {
        IQueryable<SelectListItem> GetAllParentDepartments();

    }
}


