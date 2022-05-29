using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText;
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
    class OrdenInspeccion
    {
        public void generateFile()
        {
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "files" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";

            var writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            var pdf = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            PageSize pageSize = PageSize.LETTER;
            var document = new Document(pdf, pageSize); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#

            float marginDocument = 50f;
            //document.SetMargins(0, marginDocument, marginDocument, 0);
            document.SetLeftMargin(marginDocument);
            document.SetRightMargin(marginDocument);
            document.SetTopMargin(130f);


            // Esto agrega la imagen de fondo
            string IMAGE = routePath + System.IO.Path.DirectorySeparatorChar + "img" + System.IO.Path.DirectorySeparatorChar + "backgroundPC5.jpg";
            ImageData image = ImageDataFactory.Create(IMAGE);
            PdfCanvas canvas = new PdfCanvas(pdf.AddNewPage());
            canvas.SaveState();
            PdfExtGState state = new PdfExtGState().SetFillOpacity(0.6f);
            canvas.SetExtGState(state);
            Rectangle rect = new Rectangle(0, 0, pageSize.GetWidth(), pageSize.GetHeight());
            canvas.AddImageFittedIntoRectangle(image, rect, false);
            canvas.RestoreState();


            //Console.WriteLine(pdf.GetNumberOfPages());
            //canvas = new PdfCanvas(pdf.GetPage(2));
            //canvas.SaveState();
            //state = new PdfExtGState().SetFillOpacity(0.6f);
            //canvas.SetExtGState(state);
            //rect = new Rectangle(0, 0, pageSize.GetWidth(), pageSize.GetHeight());
            //canvas.AddImageFittedIntoRectangle(image, rect, false);
            //canvas.RestoreState();

            // Create a PdfFont
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            //PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            //PdfFont font2 = PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD);

            // Add a Paragraph
            //document.Add(new Paragraph("Primer parrafo").SetFont(font));
            //document.Add(new Paragraph("asdasdsad").SetFont(font).Add(" asdasdsad").SetFont(font2));
            //document.Add(new Paragraph("Segundo parafro"));

            var orden = new
            {
                Folio = "000001",
                Director = "LIC. BERNARDO VILLEGAS RAMÍREZ",
                FechaCreacion = "VEINTISIETE DE SEPTIEMBRE DEL DOS MIL VEINTIDOS",
                Inspector = "JASON OTHONIEL TORRES LUIS",
                Domicilio = "Avenida Independencia 1350, Zona Urbana Río, C. P. 22010",
                RepresentanteLegal = "ELIZABETH LILIANA MONDRAGON LOPEZ",
                Giro = "DEPARTAMENTO DE ELECTRONICOS, LINEA BLANCA, HERRAMIENTAS Y PAPEL",
                Motivo = "Inspeccion extraordinaria"
            };

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            //TextAlignment x = new TextAlignment();

            //document.Add(new Paragraph("Folio: " + orden.Folio).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT).SetMarginTop(100f));
            document.Add(new Paragraph("Folio: " + orden.Folio).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));

            float marginBottom = 10f;

            Paragraph parExecSummHeader2 = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFont(font).SetMarginBottom(marginBottom);
            //Paragraph parExecSummHeader2 = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFont(font);
            parExecSummHeader2.Add(new Text(orden.Director).SetFont(boldFont));
            parExecSummHeader2.Add(", Director Municipal de Protección Civil de este Municipio de Tijuana, Baja California, en uso de las facultades que me confieren los preceptos ");
            parExecSummHeader2.Add(new Text("1,2,4, fracciones III y V, 19 fracciones II, VIII y XV, 58, 58 bis, 58 ter, 58 quater, 58 quinquies,").SetFont(boldFont));
            parExecSummHeader2.Add(" 94, 95, 96, 97, 98, 99, 100, 101, 102, 103 , 104, 105, 106 y demás relativos y aplicables del Reglamento de Protección Civil, en esta ciudad de Tijuana Baja California siendo el día ");
            parExecSummHeader2.Add(orden.FechaCreacion);
            parExecSummHeader2.Add(", solicito a usted ");
            parExecSummHeader2.Add(orden.Inspector);
            parExecSummHeader2.Add(" que en su calidad de");
            parExecSummHeader2.Add(new Text(" VERIFICADOR TÉCNICO").SetFont(boldFont));
            parExecSummHeader2.Add(" de esta dirección, se apersone en el domicilio ubicado en: ");
            parExecSummHeader2.Add(orden.Domicilio);
            parExecSummHeader2.Add(" que corresponde a: ");
            parExecSummHeader2.Add(orden.RepresentanteLegal);
            parExecSummHeader2.Add(" con el giro de: ");
            parExecSummHeader2.Add(orden.Giro);
            parExecSummHeader2.Add(" para efectos de que con motivo de: ");
            parExecSummHeader2.Add(orden.Motivo);
            parExecSummHeader2.Add(", realice");
            parExecSummHeader2.Add(new Text(" INSPECCIÓN DE SEGURIDAD").SetFont(boldFont));
            parExecSummHeader2.Add(" del antes mencionado, en donde deberá de verificar lo siguiente:");
            document.Add(parExecSummHeader2);

            //List list = new List().SetSymbolIndent(12).SetListSymbol("\u2022").SetFont(font);
            List list = new List(ListNumberingType.DECIMAL).SetSymbolIndent(12).SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetMarginBottom(marginBottom);
            //List list = new List(ListNumberingType.DECIMAL).SetSymbolIndent(12).SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED);
            // Add ListItem objects
            list.Add(new ListItem("Se cuente con programa interno de protección civil y que se encuentre debidamente autorizado por la autoridad competente."))
                .Add(new ListItem("Que el programa interno de protección civil autorizado se encuentre debidamente difundido y aplicado en la estructura y personal de dicho inmueble. "));
            // Add the list
            document.Add(list);

            //Paragraph o1 = new Paragraph("");
            //o1.SetMultipliedLeading(3.0f);


            document.Add(new Paragraph("Sin otro particular sírvase diligenciar lo supra mencionado con estricto apego a los valores y directrices de esta dirección, velando y ponderando la salvaguarda de la vida, la integridad y salud de la población, los bienes y el medio ambiente.").SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetMarginBottom(marginBottom));


            document.Add(new Paragraph("ATENTAMENTE").SetFont(boldFont).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetMarginBottom(60f));


            //document.Add(new Paragraph(orden.Director).SetFont(boldFont).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            //document.Add(new Paragraph("DIRECTOR DE PROTECCIÓN CIVIL MUNICIPAL").SetFont(boldFont).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            //document.Add(new Paragraph("SECRETARIA DE GOBIERNO").SetFont(boldFont).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

            Paragraph finalText = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            finalText.Add(new Text(orden.Director).SetFont(boldFont));
            finalText.Add(new Text("\n"));
            finalText.Add(new Text("DIRECTOR DE PROTECCIÓN CIVIL MUNICIPAL").SetFont(boldFont));
            finalText.Add(new Text("\n"));
            finalText.Add(new Text("SECRETARIA DE GOBIERNO").SetFont(boldFont));

            document.Add(finalText);

            //// Create a List EJEMPLO
            //List list = new List().SetSymbolIndent(12).SetListSymbol("\u2022").SetFont(font);
            //// Add ListItem objects
            //list.Add(new ListItem("Never gonna give you up"))
            //    .Add(new ListItem("Never gonna let you down"))
            //    .Add(new ListItem("Never gonna run around and desert you"))
            //    .Add(new ListItem("Never gonna make you cry"))
            //    .Add(new ListItem("Never gonna say goodbye"))
            //    .Add(new ListItem("Never gonna tell a lie and hurt you"));
            //// Add the list
            //document.Add(list);
            //Close document


            // Detectar si hay mas de dos paginas, en caso de que si haya mas de 1 pagina
            //agregar el canvas
            //Console.WriteLine(pdf.GetNumberOfPages());
            //canvas = new PdfCanvas(pdf.GetPage(2));
            //canvas.SaveState();
            //state = new PdfExtGState().SetFillOpacity(0.6f);
            //canvas.SetExtGState(state);
            //rect = new Rectangle(0, 0, pageSize.GetWidth(), pageSize.GetHeight());
            //canvas.AddImageFittedIntoRectangle(image, rect, false);
            //canvas.RestoreState();


            document.Close();
        }
    }
}
