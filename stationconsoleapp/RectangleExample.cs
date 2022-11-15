using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iText;
using iText.Commons.Utils;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace stationconsoleapp
{
    class RectangleExample
    {
        public void generateFile()
        {
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";


            var fos = new FileStream(dest, FileMode.Create);
            var writer = new PdfWriter(fos);
            var pdf = new PdfDocument(writer);
            //var ps = PageSize.A4.Rotate();
            var ps = PageSize.LETTER;
            var page = pdf.AddNewPage(ps);

            var canvas = new PdfCanvas(page);


            Rectangle rect = new Rectangle(ps.GetWidth() - 180, 40, 130, 80);
            
            Paragraph p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(6);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);


            Canvas x = new Canvas(canvas, rect);
            p.Add(new Text("REVISÓ").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(new Text("\n"));
            p.Add(new Text("\n"));
            p.Add(new Text("\n"));
            p.Add(new Text("JUAN MANUEL SANDOVAL RODRIGUEZ").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(new Text("Verificador Inspector de Protección Civil"));
            p.Add(new Text("\n"));
            p.Add(new Text("Departamento de Verificaciones"));
            x.Add(p);

            //x.Add(new Paragraph("REVISO"));
            //x.Add(new Text("/n"));
            //x.Add(new Text("/n"));
            //x.Add(new Paragraph("REVISO2"));

            canvas.Rectangle(rect);
            canvas.Stroke();

            pdf.Close();

            //Paragraph p = new Paragraph("This is the text added in the rectangle.");

            //PdfCanvas canvas = new PdfCanvas(page);
            //Rectangle rect = new Rectangle(ps.GetWidth() - 90, ps.GetHeight() - 100, 50, 50);

            //canvas.Rectangle(rect);
            //canvas.Stroke();
            //pdf.Close();
        }
    }
}
