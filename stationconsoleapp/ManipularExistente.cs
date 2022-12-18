using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Pdfa;
using System.Drawing.Printing;
using iText.Layout;
using iText.Layout.Element;
using Humanizer.Localisation;
using iText.Layout.Properties;
using iText.IO.Source;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.IO.Font.Constants;
using iText.Kernel.Font;

namespace stationconsoleapp
{
    class ManipularExistente
    {
        public void generateFile()
        {

            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]) + SEPARATOR;

            string src = routePath + "resources" + SEPARATOR + "formatoemer.pdf";
            string dest = routePath + "iTextGeneratedFiles" + SEPARATOR + System.IO.Path.GetRandomFileName() + ".pdf";

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(dest));

            PageSize pageSize = PageSize.LETTER;
            Document document = new Document(pdfDoc, pageSize);




            // add content
            //PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            //IDictionary<String, PdfFormField> fields = form.GetFormFields();

            //PdfFormField toSet;
            //fields.TryGetValue("HoraDespacho", out toSet);
            //toSet.SetValue("James Bond");

            //fields.TryGetValue("CasillaExample", out toSet);
            //toSet.SetValue("Yes");




            pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundReporteEmergenciaEventHandler(routePath));


            document.SetTopMargin(60f);

            document.Add(new AreaBreak(AreaBreakType.LAST_PAGE));
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

            string DOG = routePath + "resources" + SEPARATOR + "prueba1negocio.jpeg";
            string SWAMPER = routePath + "resources" + SEPARATOR + "3.jpg";
            iText.Layout.Element.Image dog = new iText.Layout.Element.Image(ImageDataFactory.Create(DOG));
            iText.Layout.Element.Image dog2 = new iText.Layout.Element.Image(ImageDataFactory.Create(DOG));
            iText.Layout.Element.Image swamper = new iText.Layout.Element.Image(ImageDataFactory.Create(SWAMPER));

            dog.SetWidth(255);
            dog.SetHeight(150);

            swamper.SetWidth(255);
            swamper.SetHeight(150);

            dog2.SetWidth(490);
            dog2.SetHeight(280);

            PdfFont BOLDFONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            Paragraph p1 = new Paragraph("UBICACIÓN (FOTO) CON COORDENADAS").SetFont(BOLDFONT);

            Paragraph p2 = new Paragraph()
                            .Add("")
                            .Add(dog2);

            p2.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

            p1.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            document.Add(p1);
            document.Add(p2);

            //iText.Layout.Element.Image fox = new Image(ImageDataFactory.Create(FOX));
            //iText.Layout.Element.Image dog = new iText.Layout.Element.Image(ImageDataFactory.Create(DOG));

            //Paragraph p = new Paragraph()
            //                .Add("The quick brown ")
            //                .Add(fox)
            //                .Add("jumps over the lazy ")
            //                .Add(dog);

            //document.Add(p);


            //document.Add(new AreaBreak(AreaBreakType.LAST_PAGE));
            //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

            float[] tableColumns = new float[] { 1, 1 };
            Table table = new Table(UnitValue.CreatePercentArray(tableColumns))
                              .UseAllAvailableWidth();

            table.AddCell(new Cell().Add(dog).Add((new Paragraph("Descripcion Imagen 1"))));
            table.AddCell(new Cell().Add(swamper).Add(new Paragraph("Descripcion Imagen 1")));

            table.AddCell(new Cell().Add(dog).Add((new Paragraph("Descripcion Imagen 1"))));
            table.AddCell(new Cell().Add(swamper).Add(new Paragraph("Descripcion Imagen 1")));

            table.AddCell(new Cell().Add(dog).Add((new Paragraph("Descripcion Imagen 1"))));
            table.AddCell(new Cell().Add(swamper).Add(new Paragraph("Descripcion Imagen 1")));

            //table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 1")));
            //table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 2")));

            //table.AddCell(new Cell().Add(dog));
            //table.AddCell(new Cell().Add(swamper));

            //table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 3")));
            //table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 4")));

            //table.AddCell(new Cell().Add(dog));
            //table.AddCell(new Cell().Add(swamper));

            //table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 5")));
            //table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 6")));

            document.Add(table);

            pdfDoc.Close();

            //// Create output PDF
            //PdfWriter writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            //PdfDocument pdfDocument = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            //PageSize pageSize = PageSize.LEGAL;
            //Document document = new Document(pdfDocument, pageSize, false);

            //// Load existing PDF
            ////PdfDocument pdfDoc = new PdfDocument(new PdfReader(src));


            ////PdfPage x = pdfDoc.GetFirstPage();
            ////document.Add(x);

            //PdfReader reder = new PdfReader(src);
            //Pdf







            //string DOG = routePath + "resources" + SEPARATOR + "dog.bmp";
            //string FOX = routePath + "resources" + SEPARATOR + "fox.bmp";

            //PdfDocument pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(dest));

            //PageSize pageSize = PageSize.LEGAL;
            //Document document = new Document(pdfDoc, pageSize, false);
            //PdfPage page = pdfDoc.AddNewPage(PageSize.LETTER);

            //// add content
            //PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            //IDictionary<String, PdfFormField> fields = form.GetFormFields();

            //PdfFormField toSet;

            //iText.Layout.Element.Image dog = new iText.Layout.Element.Image(ImageDataFactory.Create(DOG));
            //fields.TryGetValue("HoraDespacho", out toSet);
            //toSet.SetValue("James Bond");

            //fields.TryGetValue("CasillaExample", out toSet);
            //toSet.SetValue("Yes");

            //document.Add(new AreaBreak(AreaBreakType.LAST_PAGE));
            //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            //Paragraph p = new Paragraph()
            //                .Add("The quick brown ")
            //                .Add("jumps over the lazy ")
            //                .Add(dog);

            //document.Add(p);

            ////iText.Layout.Element.Image fox = new Image(ImageDataFactory.Create(FOX));




            //document.Close();
        }
    }
}
