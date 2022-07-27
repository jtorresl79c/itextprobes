using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

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
    class OficioSimulacro
    {



        public Table GetTable()
        {
            float[] tableColumns = new float[] { 1, 1.5f };
            Table table = new Table(UnitValue.CreatePercentArray(tableColumns))
                              .UseAllAvailableWidth();

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            table.SetWidth(150);

            table.SetTextAlignment(TextAlignment.LEFT);

            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);

            Cell cell;

            cell = new Cell();
            cell.Add(new Paragraph("Dependencia").SetFontSize(6).SetFont(boldFont));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            cell = new Cell();
            cell.Add(new Paragraph("Secretaria de Gobierno").SetFontSize(6));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);



            cell = new Cell();
            cell.Add(new Paragraph("Sección").SetFontSize(6).SetFont(boldFont));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            cell = new Cell();
            cell.Add(new Paragraph("Dirección de Protección Civil").SetFontSize(6));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);






            cell = new Cell();
            cell.Add(new Paragraph("Número de Oficio").SetFontSize(6).SetFont(boldFont));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            cell = new Cell();
            cell.Add(new Paragraph("DPC/0346/2022.").SetFontSize(6));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);




            cell = new Cell();
            cell.Add(new Paragraph("Expediente").SetFontSize(6).SetFont(boldFont));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            cell = new Cell();
            cell.Add(new Paragraph("Departamento de Verificaciones").SetFontSize(6));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);




            cell = new Cell();
            cell.Add(new Paragraph("Asunto").SetFontSize(6).SetFont(boldFont));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            cell = new Cell();
            cell.Add(new Paragraph("Evaluación de Simulacro").SetFontSize(6));
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            return table;
        }

        public string DateToTextDate(DateTime datetime) // 25 de julio de 2022
        {
            int day = datetime.Day; // 1, 2, 3, 4

            int year = datetime.Year;

            int month = datetime.Month; // january, febraury, june, etc
            var culture = new System.Globalization.CultureInfo("es-ES");
            string MonthInSpanish = culture.DateTimeFormat.GetMonthName(month); // enero, febrero, marzo, abril, mayo, junio

            //DayOfWeek dayOfWeek = datetime.DayOfWeek; // Dia de la semana en ingles: Monday, Sunday, Tuesday, etc
            //string dayOfWeekInSpanish = culture.DateTimeFormat.GetDayName(dayOfWeek).ToString(); //  Si sirve, pero lo comente porque no se esta usando

            string Fecha = $"{day} de {MonthInSpanish} de {year}.";

            return Fecha;
        }

        public string GetDayInTextOfDatetime(DateTime datetime) // lunes, martes, miercoles
        {
            var culture = new System.Globalization.CultureInfo("es-ES");
            DayOfWeek dayOfWeek = datetime.DayOfWeek; // Dia de la semana en ingles: Monday, Sunday, Tuesday, etc
            string dayOfWeekInSpanish = culture.DateTimeFormat.GetDayName(dayOfWeek).ToString(); // lunes, martes, miercoles
            return dayOfWeekInSpanish;
        }

        public string DateToFullDateInText(DateTime datetime)
        {
            int day = datetime.Day; // 1, 2, 3, 4

            int year = datetime.Year;

            int month = datetime.Month; // january, febraury, june, etc
            var culture = new System.Globalization.CultureInfo("es-ES");
            string MonthInSpanish = culture.DateTimeFormat.GetMonthName(month); // enero, febrero, marzo, abril, mayo, junio

            DayOfWeek dayOfWeek = datetime.DayOfWeek; // Dia de la semana en ingles: Monday, Sunday, Tuesday, etc
            string dayOfWeekInSpanish = culture.DateTimeFormat.GetDayName(dayOfWeek).ToString(); //  Si sirve, pero lo comente porque no se esta usando

            string Fecha = $"{dayOfWeekInSpanish} {day} de {MonthInSpanish} de {year}.";

            return Fecha;
        }

        public Paragraph GetFechaAndPlace(DateTime datetime)
        {

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            ////DateTime datetime = datetime;
            //int day = datetime.Day; // 1, 2, 3, 4

            //int year = datetime.Year;

            //int month = datetime.Month; // january, febraury, june, etc
            //var culture = new System.Globalization.CultureInfo("es-ES");
            //string MonthInSpanish = culture.DateTimeFormat.GetMonthName(month); // enero, febrero, marzo, abril, mayo, junio

            //DayOfWeek dayOfWeek = datetime.DayOfWeek; // Dia de la semana en ingles: Monday, Sunday, Tuesday, etc
            //string dayOfWeekInSpanish = culture.DateTimeFormat.GetDayName(dayOfWeek).ToString(); //  Si sirve, pero lo comente porque no se esta usando

            //string Fecha = $"{day} de {MonthInSpanish} de {year}.";

            //string fulltext = $"Tijuana, Baja California, {GetDayInTextOfDatetime(datetime)}, {DateToTextDate(datetime)}";
            string fulltext = $"Tijuana, Baja California, {DateToFullDateInText(datetime)}";

            return new Paragraph(fulltext).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT).SetFontSize(10).SetFont(font);

        }


        public Paragraph GetNames()
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            //Paragraph paragraph = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFont(font).SetMarginBottom(marginBottom);
            Paragraph paragraph = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFont(font).SetFontSize(10);
            //parExecSummHeader2.Add(new Text(Director).SetFont(boldFont));
            //parExecSummHeader2.Add(", Director Municipal de Protección Civil de este Municipio de Tijuana, Baja California, en uso de las facultades que me confieren los preceptos ");
            //parExecSummHeader2.Add(" del antes mencionado, en donde deberá de verificar lo siguiente:");
            paragraph.Add(new Text("FANNY WONG LI").SetFont(boldFont));
            paragraph.Add(new Text("\n"));
            paragraph.Add("REPRESENTANTE LEGAL");
            paragraph.Add(new Text("\n"));
            paragraph.Add("ACCENTECH S.A DE C.V");
            paragraph.Add(new Text("\n"));
            paragraph.Add(new Text("P R E S E N T E").SetFont(boldFont));

            return paragraph;

        }

        public Paragraph GetBodyFirstParagraph()
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            Paragraph paragraph = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFont(font).SetFontSize(10);
            paragraph.Add(new Tab());
            paragraph.Add("Por medio del presente tengo a bien dirigirme a Usted para informarle las observaciones y recomendaciones del simulacro que se nos solicitó, según su oficio recibido en esta Dirección el día ");
            paragraph.Add(new Text("viernes 28 de enero del 2022").SetFont(boldFont)); // Variable
            paragraph.Add(", junto con su recibo de pago con folio ");
            paragraph.Add(new Text("#202201100000241").SetFont(boldFont)); // Variable
            paragraph.Add(", para presenciar el día ");
            paragraph.Add("miércoles 16 de febrero del 2022 "); // Variable
            paragraph.Add("a las ");
            paragraph.Add(new Text("11:00 hrs.").SetFont(boldFont)); // WWWWVariable
            paragraph.Add(" en las instalaciones de la empresa ");
            paragraph.Add(new Text("ACCENTECH S.A DE C.V").SetFont(boldFont)); // Variable
            paragraph.Add(", ubicado en ");
            paragraph.Add(new Text("Águila Azteca, No. 20051 int. 6-C, Colonia Rancho el Aguila delegación municipal Cerro Colorado" + ". ").SetFont(boldFont)); // Variable
            paragraph.Add("Esto como parte de sus medidas de seguridad en materia de Protección Civil, de acuerdo a lo dispuesto en los Artículos 76 Apartado B, Fracción V, VI y VII del Reglamento de la Ley General de Protección Civil; Art. 58 QUATER Apartado B Fracción V, VI y VII del Reglamento de Protección Civil para el Municipio de Tijuana, y demás relativos y aplicables en la materia, en el cual, entre otros puntos, en los que se establece que deberá realizar ");
            paragraph.Add(new Text("al menos dos (2) ").SetFont(boldFont)); // Variable
            paragraph.Add("simulacros al año. Cabe mencionar que personal adscrito a esta Dirección debe acudir, previo aviso escrito, a sus simulacros con el fin de proporcionarle observaciones del desarrollo de estos, liquidando los derechos respectivos marcados en la Ley de Ingresos del Estado de Baja California vigente. Al respecto le informo lo siguiente.");


            return paragraph;

        }

        public Paragraph GetBodySecondParagraph()
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont obliqueFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLDOBLIQUE);

            Paragraph paragraph = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFont(font).SetFontSize(10).SetMarginBottom(15f);
            paragraph.Add(new Tab());
            paragraph.Add("Siendo el día ");
            paragraph.Add(new Text("miércoles 16 de febrero del 2022" + ", ").SetFont(boldFont)); // Variable
            paragraph.Add("personal técnico adscrito a esta Dirección, acudió al lugar antes mencionado, donde se observó que el ");
            paragraph.Add(new Text("simulacro de gabinete ").SetFont(boldFont));
            paragraph.Add("ocurrió de manera satisfactoria, en tiempo y forma, tanto el personal como los usuarios participaron de manera eficiente. De igual forma, se le informa que ");
            paragraph.Add(new Text("deberá mantener vigente anualmente su Programa Interno de Protección Civil (PIPC) ").SetFont(boldFont));
            paragraph.Add("actualizándolo, dándole difusión y seguimiento interno. ");
            paragraph.Add(new Text("Se le informa que, debido a nuevas normas y políticas internas de esta Dirección, solamente podremos participar en simulacros agendados en días y horas laborales (lunes a viernes de 8a.m. a 5p.m.).").SetFont(obliqueFont));

            return paragraph;
        }

        public Paragraph GetBodyLegend()
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            Paragraph paragraph = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFont(boldFont).SetFontSize(10).SetMarginBottom(15f);
            paragraph.Add(new Text("\"2022, Año de la Erradicación de la Violencia Contra las Mujeres\"").SetFont(boldFont));
            

            return paragraph;
        }

        public Paragraph GetBodyAtentamente()
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            Paragraph paragraph = new Paragraph("A T E N T A M E N T E").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFont(font).SetMarginBottom(60f).SetFontSize(10);



            return paragraph;
        }

        public Paragraph GetBodySigns()
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            Paragraph paragraph = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10);
            paragraph.Add(new Text("LIC. BERNARDO VILLEGAS RAMIREZ").SetFont(boldFont));
            paragraph.Add(new Text("\n"));
            paragraph.Add(new Text("DIRECTOR DE PROTECCIÓN CIVIL").SetFont(font));
            paragraph.Add(new Text("\n"));
            paragraph.Add(new Text("SECRETARIA DE GOBIERNO").SetFont(font));

            return paragraph;
        }

        public void SetRevisoCanvas(PdfDocument page)
        {
            var ps = PageSize.LETTER;
            var canvas = new PdfCanvas(page, 1);
            Rectangle rect = new Rectangle(ps.GetWidth() - 180, 80, 130, 80);
            Canvas rectangleContainer = new Canvas(canvas, rect);
            

            SolidLine line = new SolidLine(1f);
            line.SetColor(iText.Kernel.Colors.ColorConstants.BLACK);
            LineSeparator ls = new LineSeparator(line);
            var LineSeparatorWidth = rect.GetWidth();
            ls.SetWidth(LineSeparatorWidth);


            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            Paragraph p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(6);
            p.Add(new Text("REVISÓ").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(new Text("\n"));
            p.Add(new Text("\n"));
            p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("JUAN MANUEL SANDOVAL RODRIGUEZ").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(new Text("Verificador Inspector de Protección Civil"));
            p.Add(new Text("\n"));
            p.Add(new Text("Departamento de Verificaciones"));

            rectangleContainer.Add(p);

            // Si quitas esto sigue funcionando, PERO si se quiere activar el canvas.Stroke() es necesario
            // el canvas.Rectangle(rect)
            //canvas.Rectangle(rect);
            //canvas.Stroke();
        }

        public void SetCCPCanvas(PdfDocument page)
        {
            var ps = PageSize.LETTER;
            var canvas = new PdfCanvas(page, 1);
            Rectangle rect = new Rectangle(65, 30, 130, 80);
            Canvas rectangleContainer = new Canvas(canvas, rect);

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            Paragraph p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(6);
            p.Add("C.c.p.-Archivo 2022.");
            p.Add(new Text("\n"));
            p.Add("BVR/SAPI/SMVS");

            rectangleContainer.Add(p);

            // Si quitas esto sigue funcionando, PERO si se quiere activar el canvas.Stroke() es necesario
            // el canvas.Rectangle(rect)
            //canvas.Rectangle(rect);
            //canvas.Stroke();
        }

        public void SetBackgroundImg(PdfDocument pdf, string routePath)
        {
            PageSize pageSize = PageSize.LETTER;
            // Esto agrega la imagen de fondo
            string IMAGE = routePath + System.IO.Path.DirectorySeparatorChar + "resources" + System.IO.Path.DirectorySeparatorChar + "SimulacroOficio.jpg";
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

        public void generateFile()
        {
            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";

            PdfWriter writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            PdfDocument pdf = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            PageSize pageSize = PageSize.LETTER;
            Document document = new Document(pdf, pageSize); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#

            document = SetMargins(document);

            SetBackgroundImg(pdf, routePath);

            document.Add(GetTable());
            document.Add(GetFechaAndPlace(DateTime.Now));
            document.Add(GetNames());
            document.Add(GetBodyFirstParagraph());
            document.Add(GetBodySecondParagraph());
            document.Add(GetBodyLegend());
            document.Add(GetBodyAtentamente());
            document.Add(GetBodySigns());

            SetRevisoCanvas(pdf);

            SetCCPCanvas(pdf);

            document.Close();
        }



    }
}
