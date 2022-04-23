using Microsoft.AspNetCore.Mvc.Rendering;

namespace Test1.Helper
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboEntranceAsync();
    }
}
