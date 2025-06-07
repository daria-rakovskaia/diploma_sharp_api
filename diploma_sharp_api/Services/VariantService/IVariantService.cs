using diploma_sharp_api.Models;

namespace diploma_sharp_api.Services.VariantService
{
    public interface IVariantService
    {
        Task<List<Variant>> GetVariantsAsync();
    }
}
