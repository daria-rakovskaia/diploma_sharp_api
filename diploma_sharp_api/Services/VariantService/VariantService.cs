using diploma_sharp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace diploma_sharp_api.Services.VariantService
{
    public class VariantService : IVariantService
    {
        private readonly HseExamProgContext context;

        public VariantService(HseExamProgContext _context)
        {
            context = _context;
        }

        public async Task<List<Variant>> GetVariantsAsync()
        {
            return await context.Variants.ToListAsync();
        }
    }
}
