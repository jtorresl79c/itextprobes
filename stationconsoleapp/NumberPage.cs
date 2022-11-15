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
    class NumberPage
    {
        //public void SetBackgroundImg(PdfDocument pdf, string routePath, PageSize pageSize)
        //{
        //    // Esto agrega la imagen de fondo
        //    string IMAGE = routePath + System.IO.Path.DirectorySeparatorChar + "resources" + System.IO.Path.DirectorySeparatorChar + "ActaCircBg.jpg";
        //    ImageData image = ImageDataFactory.Create(IMAGE);
        //    PdfCanvas canvas = new PdfCanvas(pdf.AddNewPage());
        //    canvas.SaveState();
        //    PdfExtGState state = new PdfExtGState().SetFillOpacity(0.6f);
        //    canvas.SetExtGState(state);
        //    Rectangle rect = new Rectangle(0, 0, pageSize.GetWidth(), pageSize.GetHeight());
        //    canvas.AddImageFittedIntoRectangle(image, rect, false);
        //    canvas.RestoreState();
        //}
        public Document SetMargins(Document document)
        {
            float marginDocument = 40f;
            //document.SetMargins(0, marginDocument, marginDocument, 0);
            document.SetLeftMargin(marginDocument);
            document.SetRightMargin(marginDocument);
            document.SetTopMargin(80f); // 50f
            return document;
        }

        public Paragraph GetFolioParagraphForDocument(string Folio)
        {
            return new Paragraph("Folio: " + Folio).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
        }

        public Paragraph GetTituloActaForDocument(PdfFont BOLDFONT)
        {
            return new Paragraph("ACTA CIRCUNSTANCIADA").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFont(BOLDFONT);
        }

        public void SetNumberPages(Document document)
        {
            int numberOfPages = document.GetPdfDocument().GetNumberOfPages();
            PdfDocument pdfDocument = document.GetPdfDocument();
            for (int i = 1; i <= numberOfPages; i++)
            {
                PdfPage page = pdfDocument.GetPage(i);
                Rectangle pageSize = page.GetPageSize();
                float pageX = pageSize.GetRight() - document.GetRightMargin() - 40;
                float pageY = pageSize.GetBottom() + 30;

                // Write x of y to the right bottom
                Paragraph p = new Paragraph(String.Format("{0} de {1}", i, numberOfPages));
                document.ShowTextAligned(p, pageX, pageY, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);

                // write name to the left
                //pageX = pageSize.GetLeft() + document.GetLeftMargin();
                //pageY = pageSize.GetBottom() + 30;
                //Paragraph para = new Paragraph("Momo").SetMarginTop(10f);
                //document.ShowTextAligned(para, pageX, pageY, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);
            }
        }


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

            
            pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundEventHandler(routePath));

            var ac = new
            {
                Folio = "000001",
                HoraCreacion = "14:12"
            };

            ////

            PdfFont BOLDFONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document = SetMargins(document);


            //document.Add(new Paragraph("1asdsadsa dsad sad asd "));

            //SetBackgroundImg(pdfDocument, routePath, pageSize1);
            //document.Add(new Paragraph("1"));
            //SetBackgroundImg(pdfDocument, routePath, pageSize1);
            //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            //document.Add(new Paragraph("2"));


            //string IMAGE = routePath + System.IO.Path.DirectorySeparatorChar + "resources" + System.IO.Path.DirectorySeparatorChar + "ActaCircBg.jpg";
            //PdfCanvas canvas = new PdfCanvas(document.GetPdfDocument().AddNewPage());
            //canvas.AddImageFittedIntoRectangle(ImageDataFactory.Create(IMAGE), pageSize1, false);


            //SetBackgroundImg(pdfDocument, routePath, pageSize1);

            //document.Add(GetFolioParagraphForDocument(ac.Folio));


            document.Add(new Paragraph("lorem lsakdl;sakdl;sakd;lkdsad"));
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(new Paragraph("s;lajdklakskldjsakdl "));



            SetNumberPages(document);



            document.Close();


        }
    }
}
