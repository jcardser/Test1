using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test1.Data;

namespace Test1.Helper
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboEntranceAsync()
        {
            List<SelectListItem> list = await _context.Entrances.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Description
            })
                .OrderBy(e => e.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione una entrada...", Value = "0" });
            return list;
        }
    }
}
