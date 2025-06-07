using diploma_sharp_api.PDFModels;

namespace diploma_sharp_api.Services.PDFService
{
    public interface IPDFService
    {
        byte[] GetPDF(PDFBody result);
    }
}
