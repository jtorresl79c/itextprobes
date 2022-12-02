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

namespace stationconsoleapp
{
    class ManipularExistente
    {
        public void generateFile()
        {

            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]) + SEPARATOR;

            string DOG = routePath + "resources" + SEPARATOR + "dog.bmp";
            string FOX = routePath + "resources" + SEPARATOR + "fox.bmp";

            string src = routePath + "resources" + SEPARATOR + "formatoemer.pdf";
            string dest = routePath + "iTextGeneratedFiles" + SEPARATOR + System.IO.Path.GetRandomFileName() + ".pdf";

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(dest));

            PageSize pageSize = PageSize.LETTER;
            Document document = new Document(pdfDoc, pageSize);
            //pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundEventHandler(routePath));

            document.Add(new AreaBreak(AreaBreakType.LAST_PAGE));
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(new Paragraph("Folio: "));

            iText.Layout.Element.Image fox = new Image(ImageDataFactory.Create(FOX));
            iText.Layout.Element.Image dog = new iText.Layout.Element.Image(ImageDataFactory.Create(DOG));

            Paragraph p = new Paragraph()
                            .Add("The quick brown ")
                            .Add(fox)
                            .Add("jumps over the lazy ")
                            .Add(dog);

            document.Add(p);


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
