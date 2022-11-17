using System;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Layout;
using iText.Layout.Element;

using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout.Properties;

using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Events;

namespace stationconsoleapp
{
    class GridExample
    {
        public void generateFile()
        {
            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";

            PdfWriter writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            PdfDocument pdfDocument = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            PageSize pageSize = PageSize.LEGAL;
            Document document = new Document(pdfDocument, pageSize); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#

            float paddingCell = 0;

            float[] tableColumns = new float[] { 1, 1 };
            Table table = new Table(UnitValue.CreatePercentArray(tableColumns))
                              .UseAllAvailableWidth();

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            // https://kb.itextpdf.com/home/it7kb/faq/how-to-define-the-width-of-a-cell
            table.SetWidth(500); // 1 inch = 72 units - 612 es lo MAXIMO (no contando margenes)
            table.SetHeight(200);

            table.SetTextAlignment(TextAlignment.CENTER);

            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            //table.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);

            Cell cell;

            Rectangle rect = new Rectangle(pageSize.GetWidth() - 180, 80, 230, 80);
            SolidLine line = new SolidLine(1f);
            line.SetColor(iText.Kernel.Colors.ColorConstants.BLACK);
            LineSeparator ls = new LineSeparator(line);
            var LineSeparatorWidth = rect.GetWidth();
            ls.SetWidth(LineSeparatorWidth);

            //p.Add(new Text("REVISÓ").SetFont(boldFont));
            Paragraph p;
            
            p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(6);
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("VERIFICADOR").SetFont(boldFont));
            //p.Add(new Text("\n"));
            //p.Add(new Text("Verificador Inspector de Protección Civil"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("Departamento de Verificaciones"));


            cell = new Cell();
            cell.Add(p);
            cell.SetPadding(paddingCell);
            cell.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);



            p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(6);
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("PERSONA QUE ATIENDE LA INSPECCIÓN").SetFont(boldFont));

            cell = new Cell();
            cell.Add(p);
            cell.SetPadding(paddingCell);
            cell.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);





            p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(6);
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("TESTIGO").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(new Text("NOMBRE Y FIRMA"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("Departamento de Verificaciones"));
            cell = new Cell();
            cell.SetPadding(paddingCell);
            cell.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);
            cell.Add(p);
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);




            p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(6);
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("TESTIGO").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(new Text("NOMBRE Y FIRMA"));

            cell = new Cell();
            cell.SetPadding(paddingCell);
            cell.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);
            cell.Add(p);
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            document.Add(table);






            document.Close();
        }
    }
}
