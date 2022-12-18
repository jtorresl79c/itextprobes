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
    class ReporteEmergencia
    {
        public void generateFile()
        {

            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]) + SEPARATOR;

            string src = routePath + "resources" + SEPARATOR + "ReporteEmergenciaTemplate.pdf";
            string dest = routePath + "iTextGeneratedFiles" + SEPARATOR + System.IO.Path.GetRandomFileName() + ".pdf";

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(dest));

            PageSize pageSize = PageSize.LETTER;
            Document document = new Document(pdfDoc, pageSize);

            pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundReporteEmergenciaEventHandler(routePath));
            PdfFont BOLDFONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document.SetTopMargin(60);
            document.SetBottomMargin(60);

            //////////////////////////////
            float[] TopTableColumns = new float[] { 1 };
            Table TopTable = new Table(UnitValue.CreatePercentArray(TopTableColumns))
                              .UseAllAvailableWidth();

            TopTable.AddCell(new Cell().Add(new Paragraph("DESCRIPCIÓN DE SISTEMA DE EMERGENCIA DEL INCIDENTE:").SetFontSize(9).SetFont(BOLDFONT).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
            Paragraph DescrSistemaEmerParagraph = new Paragraph(" Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla placerat vitae enim vel semper. Donec sed rutrum elit. Nulla neque sapien, blandit at elit in, lacinia aliquam orci. Quisque vitae purus a quam tempor imperdiet nec imperdiet augue. Praesent ultricies in massa ut sollicitudin. Nunc quis condimentum dui. Curabitur in est bibendum, scelerisque lorem sit amet, ullamcorper risus. Quisque euismod at ante eget rhoncus. Aenean vitae scelerisque nunc, quis eleifend mi. ").SetFontSize(9);
            TopTable.AddCell(new Cell().Add(DescrSistemaEmerParagraph));

            TopTable.AddCell(new Cell().Add(new Paragraph("DEPENDENCIAS INVOLUCRADAS:").SetFontSize(9).SetFont(BOLDFONT).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
            Paragraph DependenciasInvolucradasParagraph = new Paragraph(" Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla placerat vitae enim vel semper. Donec sed rutrum elit. Nulla neque sapien, blandit at elit in, lacinia aliquam orci. Quisque vitae purus a quam tempor imperdiet nec imperdiet augue. Praesent ultricies in massa ut sollicitudin. Nunc quis condimentum dui. Curabitur in est bibendum, scelerisque lorem sit amet, ullamcorper risus. Quisque euismod at ante eget rhoncus. Aenean vitae scelerisque nunc, quis eleifend mi. ").SetFontSize(9);
            TopTable.AddCell(new Cell().Add(DependenciasInvolucradasParagraph));

            TopTable.AddCell(new Cell().Add(new Paragraph("ACCIONES Y/U OBSERVACIONES:").SetFontSize(9).SetFont(BOLDFONT).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
            Paragraph AccionesObsParagraph = new Paragraph("Se atiende reporte derivado del sistema de emergencias 9-1-1 por olor a humo en estación infantil. Al momento de arribar al lugar de los hechos se encontraba la dirección de bomberos a cargo del capitán Luis Cárdenas al cual hace referencia que realizaron maniobras sobre el segundo nivel de dicho inmueble para descartar algún conato de incendio en las instalaciones eléctricas. Así mismo se realiza recorrido en conjunto con quien refiere ser docente por lo que se obtuvieron las siguientes observaciones: El sistema contra incendios no funciona, extintores despresurizados, lámparas no aptas ya que la iluminación es muy deficiente, así como falta de estas mismas en áreas estratégicas como en el área de maternal, falta de señalamientos, cables eléctricos expuestos, losa levantada en el área por donde pasa el tubo de aguas residuales, falta de anclaje en estantes para evitar algún tipo de incidente con el personal y los infantes que transitan por los pasillos. Destacando a su vez, al momento del incidente no se realizó la evacuación adecuada ya que no constaban con el equipo de protección personal, no contaban con la mochila móvil ya que su sistema de alarma fue por voceo y se utilizó la alarma con la que cuenta el inmueble. Cabe mencionar que el personal no cerro las llaves del gas y tampoco se inhabilitaron los brakes de la luz. Por lo que se solicita a quien atiende la diligencia el programa interno (oficio) aprobado, abalado y vigente de protección civil, el cual no muestra. Por lo que esta dirección procede a la clausura de dicho inmueble por indicaciones del subdirector de verificaciones Sergio Pérez y respaldada por el director Bernardo Villegas, para salvaguardar la integridad del personal y los infantes del lugar. Destacando que, se realiza la colocación de 5 sellos en las puertas del exterior que dan acceso a 40 niños. Por lo que se hace el exhorto al representante legal del establecimiento a apersonarse en un plazo máximo de 3 días hábiles para presentar la documentación que a su derecho convenga y a su vez la regularización de estos mismos. Asi mismo se hace de su conocimiento que se abrirá expediente a partir de esta acta circunstanciada con folio 000627.").SetFontSize(9);
            TopTable.AddCell(new Cell().Add(AccionesObsParagraph));

            TopTable.SetMarginTop(389.5f);
            TopTable.SetWidth(551.3f);

            document.Add(TopTable);

            Paragraph pBlank = new Paragraph("");
            pBlank.Add("\n");
            pBlank.Add("\n");
            document.Add(pBlank);
            // add content
            //PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            //IDictionary<String, PdfFormField> fields = form.GetFormFields();

            //PdfFormField toSet;
            //fields.TryGetValue("HoraDespacho", out toSet);
            //toSet.SetValue("James Bond");

            //fields.TryGetValue("CasillaExample", out toSet);
            //toSet.SetValue("Yes");

            ////////////////////////////////

            //document.Add(new AreaBreak(AreaBreakType.LAST_PAGE));
            //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

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

            //PdfFont BOLDFONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
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


            document.Add(new AreaBreak(AreaBreakType.LAST_PAGE));
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

            float[] tableColumns = new float[] { 1, 1 };
            Table table = new Table(UnitValue.CreatePercentArray(tableColumns))
                              .UseAllAvailableWidth();

            table.AddCell(new Cell().Add(dog));
            table.AddCell(new Cell().Add(swamper));

            table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 1")));
            table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 2")));

            table.AddCell(new Cell().Add(dog));
            table.AddCell(new Cell().Add(swamper));

            table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 3")));
            table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 4")));

            table.AddCell(new Cell().Add(dog));
            table.AddCell(new Cell().Add(swamper));

            table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 5")));
            table.AddCell(new Cell().Add(new Paragraph("Descripcion Imagen 6")));

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
