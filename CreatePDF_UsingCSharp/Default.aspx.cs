using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CreatePDF_UsingCSharp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {

        }
        protected void GeneratePDF(object sender, System.EventArgs e)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                Chunk chunk = new Chunk("This is from chunk.");
                document.Add(chunk);
                Phrase phrase = new Phrase("This is from Phrase.");
                document.Add(phrase);
                Paragraph paragraph = new Paragraph("This is from paragraph.");
                document.Add(paragraph);

                string text = @"PDF file succesfully created.";
                Paragraph paragraph2 = new Paragraph();
                paragraph2.SpacingBefore = 10;
                paragraph2.SpacingAfter = 10;
                paragraph2.Alignment = Element.ALIGN_LEFT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.HELVETICA, 14f, BaseColor.BLUE);
                paragraph2.Add(text);
                document.Add(paragraph2);

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";

                string pdfName = "myTable";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        protected void GenerateTablePDF(object sender, System.EventArgs e)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
            PdfPTable table = new PdfPTable(4);
            table.TotalWidth = 400f;
            table.LockedWidth = true;
            PdfPCell header = new PdfPCell(new Phrase("Jorgesys Table"));
            header.Colspan = 4;
            table.AddCell(header);
            table.AddCell("Cell 1");
            table.AddCell(customCell());
            table.AddCell("Cell 3...");
            table.AddCell("Cell 4...");
            PdfPTable nested = new PdfPTable(1);
            nested.AddCell("Nested Row 1...");
            nested.AddCell("Nested Row 2...");
            nested.AddCell("Nested Row 3...");
            PdfPCell nesthousing = new PdfPCell(nested);
            nesthousing.Padding = 0f;
            table.AddCell(nesthousing);
            PdfPCell bottom = new PdfPCell(new Phrase("bottom"));
            bottom.Colspan = 3;
            table.AddCell(bottom);

            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            document.Add(table);

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";

                string pdfName = "myTable2";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();

            }
        }


        private PdfPCell customCell()
        {

            PdfPCell cell = new PdfPCell(new Phrase("Cell 2", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, BaseColor.YELLOW)))
            {
                BackgroundColor = new BaseColor(0, 150, 0),
                BorderColor = new BaseColor(255, 242, 0),
                Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER,
                BorderWidthBottom = 3f,
                BorderWidthTop = 3f,
                PaddingBottom = 10f,
                PaddingLeft = 20f,
                PaddingTop = 4f
            };
            return cell;
        }


    }
}