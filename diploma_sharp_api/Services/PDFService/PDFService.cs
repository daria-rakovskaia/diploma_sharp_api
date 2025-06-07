using diploma_sharp_api.PDFModels;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace diploma_sharp_api.Services.PDFService
{
    public class PDFService : IPDFService
    {
        public byte[] GetPDF(PDFBody result)
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                PdfFont font = PdfFontFactory.CreateFont(
                            "Fonts/timesnewromanpsmt.ttf",
                            PdfEncodings.IDENTITY_H,
                            PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED
                        );
                document.Add(new Paragraph(result.Result)
                    .SetFont(font)
                    .SetFontSize(13));

                document.Close();
                return memoryStream.ToArray();
            }
        }
    }
}
