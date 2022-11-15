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

namespace stationconsoleapp
{
    class ActaCircunstanciada
    {
        public void SetBackgroundImg(PdfDocument pdf, string routePath, PageSize pageSize)
        {
            //PageSize pageSize = PageSize.LETTER;
            // Esto agrega la imagen de fondo
            string IMAGE = routePath + System.IO.Path.DirectorySeparatorChar + "resources" + System.IO.Path.DirectorySeparatorChar + "ActaCircBg.jpg";
            ImageData image = ImageDataFactory.Create(IMAGE);
            PdfCanvas canvas = new PdfCanvas(pdf.AddNewPage());
            canvas.SaveState();
            PdfExtGState state = new PdfExtGState().SetFillOpacity(0.6f);
            canvas.SetExtGState(state);
            Rectangle rect = new Rectangle(0, 0, pageSize.GetWidth(), pageSize.GetHeight());
            canvas.AddImageFittedIntoRectangle(image, rect, false);
            canvas.RestoreState();
        }

        public Document SetMargins(Document document)
        {
            float marginDocument = 65f;
            //document.SetMargins(0, marginDocument, marginDocument, 0);
            document.SetLeftMargin(marginDocument);
            document.SetRightMargin(marginDocument);
            document.SetTopMargin(55f);
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

        public Paragraph GetBodyFirstPage(
            string Hora, 
            string Fecha, 
            string OrdenVerificador, 
            string OrdenDomicilio, 
            string OrdenEmpresa,
            string OrdenGiro,
            string OrdenFechaCreacion,
            string OrdenFolio,
            string ActaNumCredencial,
            string ActaFechaComision,
            string NumOficio,
            string ActaEntrevistado,
            string ActaIdenficacion,
            string ActaEmitida,
            string ActaNumId,
            string ActaPuesto,
            string ActaTestigo1,
            string ActaDomicilio_Testigo1,
            string ActaId_Testigo1,
            string Acta_Num_Id_Testigo1,
            string Acta_Puesto_Testigo1,
            string Acta_Testigo2,
            string Acta_Id_Testigo2,
            string Acta_Num_Id_Testigo2,
            string Acta_Puesto_Testigo2


        )
        {
            Paragraph p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFontSize(6);

            p.Add(
                "En la Ciudad de Tijuana Baja California, siendo las " + Hora + " horas del día " + Fecha + " el suscrito " + OrdenVerificador +
                " en mi carácter de Verificador Técnico adscrito a la Dirección Municipal de Protección Civil, me constituí en el domicilio ubicado en " +
                OrdenDomicilio + ", mismo que corresponde a " + OrdenEmpresa + " con giro de " + OrdenGiro + " para efectos de realizar diligencia de inspección derivada del mandamiento expreso en la orden de inspección de fecha" +
                OrdenFechaCreacion + " con folio " + OrdenFolio + " por lo que una vez en dicho lugar y previa identificación de la envestidura de un servidor con credencial número " + ActaNumCredencial
            );

            return p;
        }

        public void generateFile()
        {
            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";

            PdfWriter writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            PdfDocument pdf = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            PageSize pageSize = PageSize.LEGAL;
            Document document = new Document(pdf, pageSize); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#

            ////

            PdfFont BOLDFONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document = SetMargins(document);
            SetBackgroundImg(pdf, routePath, pageSize);

            var ac = new
            {
                Folio = "000001",
                HoraCreacion = "14:12"
            };

            document.Add(GetFolioParagraphForDocument(ac.Folio));
            document.Add(GetTituloActaForDocument(BOLDFONT));


            document.Close();
        }
    }
}
