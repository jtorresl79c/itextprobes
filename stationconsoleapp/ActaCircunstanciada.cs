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

using iText.Layout.Renderer;
using iText.Layout.Layout;


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
            float marginDocument = 38f;
            //document.SetMargins(0, marginDocument, marginDocument, 0);
            document.SetLeftMargin(marginDocument);
            document.SetRightMargin(marginDocument);
            document.SetTopMargin(100f);
            document.SetBottomMargin(70f);
            return document;
        }


        public Paragraph GetFolioParagraphForDocument(PdfFont BOLDFONT,string Folio)
        {
            Paragraph p = new Paragraph("Folio: " ).SetFont(BOLDFONT);
            p.Add(new Text(Folio).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA)));
            p.Add("\n");
            p.SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
            return p;    
        }

        public Paragraph GetTituloActaForDocument(PdfFont BOLDFONT)
        {
            Paragraph p = new Paragraph("ACTA CIRCUNSTANCIADA");

            p.Add("\n");

            p
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
            .SetFont(BOLDFONT)
            .SetFontSize(18);

            return p;
        }

        public Paragraph GetBodyFirstPage(
            PdfFont boldFont,
            Document document,
            string HoraInicio = "",
            string HoraFinal = "",
            string FechaFinal = "",
            string FechaCreacion = "",
            string OrdenVerificador = "",
            string OrdenDomicilio = "",
            string OrdenEmpresa = "",
            string OrdenGiro = "",
            string OrdenFechaCreacion = "",
            string OrdenFolio = "",
            string InspectorNumCredencial = "", // acta.num_cred
            string FechaComisionInspector = "", // acta.fecha_comision
            string NumOficioComision = "",
            string ActaEntrevistadoNombre = "",
            string ActaEntrevistadoDocumentoIdentidad = "", // acta.identificacion - INE,Pasaporte,Cred.Trabajo
            string ActaEntrevistadoDocumentoIdentidadDependencia = "", // acta.emitida
            string ActaEntrevistadoDocumentoIdentidadNumId = "",
            string ActaEntrevistadoPuesto = "",
            string ActaEntrevistadoPermiso = "",
            string ActaEntrevistadoObservaciones = "",
            string ActaTestigo1Nombre = "",
            string ActaTestigo1Domicilio = "",
            string ActaTestigo1DocumentoIdentidad = "",
            string ActaTestigo1DocumentoIdentidadNumId = "",
            string ActaTestigo1Puesto = "",
            string ActaTestigo2Nombre = "",
            string ActaTestigo2Domicilio = "",
            string ActaTestigo2DocumentoIdentidad = "",
            string ActaTestigo2DocumentoIdentidadNumId = "",
            string ActaTestigo2Puesto = "",
            string ActaObservaciones = ""
        )
        {

            Paragraph p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFontSize(11);

            p.Add(
                $"En la Ciudad de Tijuana Baja California, siendo las {HoraInicio} horas del día {FechaCreacion} el suscrito {OrdenVerificador} en mi carácter de " +
                $"Verificador Técnico adscrito a la Dirección Municipal de Protección Civil, me constituí en el domicilio ubicado en {OrdenDomicilio}, " +
                $"mismo que corresponde a {OrdenEmpresa} con giro de {OrdenGiro} para efectos de realizar diligencia de inspección derivada del mandamiento expreso " +
                $"en la orden de inspección de fecha {OrdenFechaCreacion} con folio {OrdenFolio} por lo que una vez en dicho lugar y previa identificación de la " +
                $"envestidura de un servidor con credencial número {InspectorNumCredencial} y oficio de comisión de fecha {FechaComisionInspector} con numero {NumOficioComision} " +
                $"ambos expedidos por la Dirección de Protección Civil, de este Municipio de Tijuana, Baja California, lugar en el que me entrevisto con la persona de nombre: " +
                $"{ActaEntrevistadoNombre} quien se identifica con {ActaEntrevistadoDocumentoIdentidad} emitida por {ActaEntrevistadoDocumentoIdentidadDependencia} " +
                $"número {ActaEntrevistadoDocumentoIdentidadNumId} y quien manifiesta ser: {ActaEntrevistadoPuesto} acto seguido hago del conocimiento del motivo de mi visita, " +
                $"entregando la original de orden de inspección, misma en la que se hace referencia del objeto y alcance de la presente diligencia, concediéndoles el uso de la voz" +
                $" para efectos de que designe dos testigos, apercibiéndole que en caso de no ser así, el de la voz podrá hacerlo de conformidad con lo previsto en el arábigo 100 párrafo " +
                $"segundo, del "
            );

            p.Add(new Text("REGLAMENTO DE PROTECCIÓN CIVIL PARA EL MUNICIPIO DE TIJUANA, BAJA CALIFORNIA, ").SetFont(boldFont));

            p.Add(
                $"por lo que el C. {ActaEntrevistadoNombre} manifiesta que {ActaEntrevistadoPermiso} su deseo designar a {ActaTestigo1Nombre} con domicilio en {ActaTestigo1Domicilio} " +
                $"quien se identifica con {ActaTestigo1DocumentoIdentidad} numero {ActaTestigo1DocumentoIdentidadNumId} quien funge como {ActaTestigo1Puesto} y el de nombre C. {ActaTestigo2Nombre} " +
                $"quien se identifica con {ActaTestigo2DocumentoIdentidad} numero {ActaTestigo2DocumentoIdentidadNumId} quien funge como {ActaTestigo2Puesto}. Acto seguido solicito al C. {ActaEntrevistadoNombre} " +
                $"que permita la práctica de la inspección para verificar el cumplimiento de los rubros notificados en la orden de inspección {OrdenFolio}, proporcione la información y/o documentación que se le " +
                $"requiera para el desahogo de la diligencia, apercibiéndola que, en caso de obstaculización u oposición a la misma, esta autoridad, podrá solicitar el auxilio de la fuerza pública, para efectuar " +
                $"la visita de inspección, en términos del artículo 102 del "
            );

            p.Add(new Text("REGLAMENTO DE PROTECCIÓN CIVIL DEL MUNICIPIO DE TIJUANA ").SetFont(boldFont));

            //p.Add("----------------------------------------");
            p.Add(new Tab());
            ILineDrawer filling = new DashedLine();
            PageSize pageSize1 = document.GetPdfDocument().GetDefaultPageSize();
            Rectangle effectivePageSize = document.GetPageEffectiveArea(pageSize1);
            float rightTabStopPoint = effectivePageSize.GetWidth();
            TabStop tabStop = new TabStop(rightTabStopPoint, TabAlignment.LEFT, filling);
            p.AddTabStops(tabStop);

            p.Add(new Text("\n"));

            p.Add(
                $"Así mismo, en este acto quienes intervienen en la instrumentación del acta son sabedores de las penas en que incurren los falsos declarantes en términos del artículo 320 del Código Penal para el " +
                $"Estado de Baja California, por lo que se les exhorta a conducirse con verdad en el desarrollo de la presente diligencia. A continuación, siendo las {HoraFinal} " + 
                $"se termina la inspección de campo y documental misma de la que se desprende lo siguiente: "
            );

            p.Add(new Tab());
            filling = new DashedLine();
            pageSize1 = document.GetPdfDocument().GetDefaultPageSize();
            effectivePageSize = document.GetPageEffectiveArea(pageSize1);
            rightTabStopPoint = effectivePageSize.GetWidth();
            tabStop = new TabStop(rightTabStopPoint, TabAlignment.LEFT, filling);
            p.AddTabStops(tabStop);

            p.Add("\n");

            p.Add(ActaObservaciones);

            //p.SetPaddingLeft(30);
            //p.SetPaddingRight(30);

            return p;
        }

        public Paragraph GetBodySecondPage(PdfFont BOLDFONT, Document document,
            string ActaEntrevistadoNombre,
            string ActaEntrevistadoObservaciones,
            string HoraFinal,
            string FechaFinal
        )
        {
            Paragraph p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFontSize(11);

            p.Add(
                $"En este acto, se concede el uso de la voz al (la) C. {ActaEntrevistadoNombre} con quien se atiende la diligencia para que manifieste lo que a su derecho convenga en relación a los hechos asentados y " +
                $"derivados de la presente inspección, manifestando lo siguiente: {ActaEntrevistadoObservaciones} Acto seguido emplazo para que dentro del término de "
            );

            p.Add(new Text("3 (tres) días hábiles ").SetFont(BOLDFONT));

            p.Add(
                "comparezca y manifieste lo que a su derecho convenga ante la Dirección Municipal de Protección Civil, ubicada en Avenida Guadalupe Ramírez y Segunda Sur, sin número, colonia del Río Parte Alta; " +
                "de lunes a viernes en un horario de "
            );
            p.Add(new Text("08:00 a 15:00 horas. ").SetFont(BOLDFONT));

            p.Add("- - No habiendo otro hecho que hacer constar, se da por terminada la presente Acta Circunstanciada levantada por duplicado, ");

            p.Add(new Text("entregando copia ").SetFont(BOLDFONT));

            p.Add($"de la misma a la persona que atiende la inspección siendo las {HoraFinal} horas del día {FechaFinal} firmando al calce quienes intervinieron en ella, para los efectos legales correspondientes. ");

            p.Add(new Tab());
            ILineDrawer filling = new DashedLine();
            PageSize pageSize1 = document.GetPdfDocument().GetDefaultPageSize();
            Rectangle effectivePageSize = document.GetPageEffectiveArea(pageSize1);
            float rightTabStopPoint = effectivePageSize.GetWidth();
            TabStop tabStop = new TabStop(rightTabStopPoint, TabAlignment.LEFT, filling);
            p.AddTabStops(tabStop);

            return p;
        }

        public Paragraph GetBodyLegend()
        {
            Paragraph p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED).SetFontSize(11);
            p.Add(
                "La presente acta circunstanciada se elabora con fundamento en lo dispuesto en los artículos 1, 2, 4 fracción V, 94, 95, 96, 97, 98, 99, 100, 101,102, 103, 105, 106, 107, 108, 109, 110, 111 Y 112 " +
                "todos del Reglamento de Protección Civil del Municipio de Tijuana, Baja California, en relación con lo previsto en el artículo 6 fracción VI del Reglamento de la Administración Pública Municipal del " +
                "Ayuntamiento de Tijuana."
            );
            return p;
        }

        public Table GetSignsTable(PageSize pageSize,
            string OrdenVerificador,
            string ActaEntrevistadoNombre,
            string ActaTestigo1Nombre,
            string ActaTestigo2Nombre
        )
        {
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
            p.Add(new Text("VERIFICADOR").SetFont(boldFont)).SetFontSize(11);
            p.Add(new Text("\n"));
            p.Add(OrdenVerificador);
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



            p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(11);
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("PERSONA QUE ATIENDE LA INSPECCIÓN").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(ActaEntrevistadoNombre);

            cell = new Cell();
            cell.Add(p);
            cell.SetPadding(paddingCell);
            cell.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);





            p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(11);
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("TESTIGO").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(ActaTestigo1Nombre);
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




            p = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(11);
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            //p.Add(new Text("\n"));
            p.Add(ls);
            p.Add(new Text("\n"));
            p.Add(new Text("TESTIGO").SetFont(boldFont));
            p.Add(new Text("\n"));
            p.Add(ActaTestigo2Nombre);
            p.Add(new Text("\n"));
            p.Add(new Text("NOMBRE Y FIRMA"));

            cell = new Cell();
            cell.SetPadding(paddingCell);
            cell.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);
            cell.Add(p);
            cell.SetBorder(Border.NO_BORDER);
            table.AddCell(cell);
            table.SetKeepWithNext(true);
            return table;
        }

        public void SetNumberPages(Document document)
        {
            PdfPage page;
            Rectangle pageSize;

            int numberOfPages = document.GetPdfDocument().GetNumberOfPages();
            PdfDocument pdfDocument = document.GetPdfDocument();
            Paragraph paragraph;
            IRenderer paragraphRenderer;
            LayoutResult result;
            float paragraphTotalWidth;

            float pageX;
            float pageY;
            for (int i = 1; i <= numberOfPages; i++)
            {

                page = pdfDocument.GetPage(i);
                pageSize = page.GetPageSize(); // Esto retorna null en la primera pagina si no se hace esto https://stackoverflow.com/questions/58691825/pdfdocument-getpagesize-not-set-to-an-instance-of-object-itext7

                //https://stackoverflow.com/questions/61911094/itext7-how-to-get-the-real-width-of-a-paragraph
                paragraph = new Paragraph(String.Format("{0}/{1}", i, numberOfPages));
                paragraphRenderer = paragraph.CreateRendererSubTree();
                result = paragraphRenderer.SetParent(document.GetRenderer()).Layout(new LayoutContext(new LayoutArea(1, new Rectangle(1000, 100))));
                paragraphTotalWidth = ((ParagraphRenderer)paragraphRenderer).GetMinMaxWidth().GetMaxWidth();
                //Console.WriteLine(paragraphTotalWidth);



                pageX = pageSize.GetRight() - document.GetRightMargin() - paragraphTotalWidth;
                pageY = pageSize.GetBottom() + 30;
                //float pageY = document.GetBottomMargin();

                // Write x of y to the right bottom
                document.ShowTextAligned(paragraph, pageX, pageY, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);

                ////write name to the left
                //pageX = pageSize.GetLeft() + document.GetLeftMargin();
                //pageY = pageSize.GetBottom() + 30;
                //Paragraph para = new Paragraph("Momo").SetMarginTop(10f);
                //document.ShowTextAligned(para, pageX, pageY, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);
            }
        }

        public void SetFolioInAllPages(Document document, string Folio)
        {
            int numberOfPages = document.GetPdfDocument().GetNumberOfPages();
            PdfDocument pdfDocument = document.GetPdfDocument();

            //https://stackoverflow.com/questions/61911094/itext7-how-to-get-the-real-width-of-a-paragraph
            Paragraph paragraph = new Paragraph("Folio: " + Folio);
            IRenderer paragraphRenderer = paragraph.CreateRendererSubTree();
            LayoutResult result = paragraphRenderer.SetParent(document.GetRenderer()).Layout(new LayoutContext(new LayoutArea(1, new Rectangle(1000, 100))));
            float paragraphTotalWidth = ((ParagraphRenderer)paragraphRenderer).GetMinMaxWidth().GetMaxWidth();
            //Console.WriteLine(paragraphTotalWidth);
            
            
            for (int i = 1; i <= numberOfPages; i++)
            {
                PdfPage page = pdfDocument.GetPage(i);
                Rectangle pageSize = page.GetPageSize(); // Esto retorna null en la primera pagina si no se hace esto https://stackoverflow.com/questions/58691825/pdfdocument-getpagesize-not-set-to-an-instance-of-object-itext7

                float pageX = pageSize.GetWidth() - document.GetRightMargin() - paragraphTotalWidth;
                float pageY = pageSize.GetHeight() - document.GetTopMargin();

                // Write x of y to the right bottom
                document.ShowTextAligned(paragraph, pageX, pageY, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);
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
            Document document = new Document(pdfDocument, pageSize, false); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C# && https://stackoverflow.com/questions/58691825/pdfdocument-getpagesize-not-set-to-an-instance-of-object-itext7 flush
            pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundEventHandler(routePath));
            ////

            PdfFont BOLDFONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            document = SetMargins(document);
            //SetBackgroundImg(pdfDocument, routePath, pageSize);

            var ac = new
            {
                Folio = "1000", // Folio del Acta Circunstanciada (ya se captura)
                HoraInicio = "14:25",
                HoraFinal = "16:00",
                FechaFinal = "25 de Noviembre de 2022",
                FechaCreacion = "02/09/22",
                OrdenVerificador = "ALFREDO ORTEGA SOTELO",
                OrdenDomicilio = "CALLE IMAGINARIA 232",
                OrdenEmpresa = "EMPRESA AERONAUTICA SA DE CV",
                OrdenGiro = "EMPRESA DE AVIONES SA DE CV PRUEBA",
                OrdenFechaCreacion = "10/05/22",
                OrdenFolio = "A57SDW6SDWE",
                InspectorNumCredencial = "532146", // acta.num_cred
                FechaComisionInspector = "10/10/10", // acta.fecha_comision
                NumOficioComision = "DPC/2458/2022",
                ActaEntrevistadoNombre = "JORGE LOPEZ HERNANDEZ",
                ActaEntrevistadoDocumentoIdentidad = "INE", // acta.identificacion - INE,Pasaporte,Cred.Trabajo
                ActaEntrevistadoDocumentoIdentidadDependencia = "GOBIERNO FEDERAL", // acta.emitida
                ActaEntrevistadoDocumentoIdentidadNumId = "4DS54221D",
                ActaEntrevistadoPuesto = "ADMINISTRADOR",
                ActaEntrevistadoPermiso = "SI ES",
                ActaEntrevistadoObservaciones = "Observaciones del entrevistado lorem",
                ActaTestigo1Nombre = "LUIS BARRAGAN TREJO",
                ActaTestigo1Domicilio = "CALLE INDEPENDENCIA 23340",
                ActaTestigo1DocumentoIdentidad = "INE",
                ActaTestigo1DocumentoIdentidadNumId = "587445",
                ActaTestigo1Puesto = "SUPERVISOR",
                ActaTestigo2Nombre = "ERNESTO AVILA ORTEGA",
                ActaTestigo2Domicilio = "CALLE DAPIAN 3423",
                ActaTestigo2DocumentoIdentidad = "PASAPORTE",
                ActaTestigo2DocumentoIdentidadNumId = "45354DDSS",
                ActaTestigo2Puesto = "JEFE",
                ActaObservaciones = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vehicula aliquet justo, a ornare diam. Morbi laoreet sit amet quam ac fermentum. Aliquam sollicitudin et nisl et aliquet. Etiam neque quam, viverra in mattis vel, rutrum sed risus. Vivamus tristique diam leo, eu sagittis ligula venenatis ac. Aliquam ultrices porttitor fermentum. Cras ut tortor semper, tempus turpis eu, fringilla orci. Donec quis urna at tortor auctor cursus ut non risus. Duis laoreet metus eu purus sodales auctor. Nam iaculis, tellus non ultrices vehicula, risus sem dictum dolor, eleifend sollicitudin augue diam eu augue. Nulla commodo porttitor tellus sed porta. In sodales dui vestibulum nibh mattis, nec varius felis pretium. Vivamus non odio id dolor iaculis ullamcorper. Proin fermentum porttitor leo, et viverra elit scelerisque eget.  Vestibulum maximus eleifend pharetra. Quisque sed congue libero. Aenean feugiat finibus ligula in lobortis. Phasellus pretium pretium nunc, et ullamcorper ante bibendum sit amet. Quisque vel velit id purus varius elementum eget vel nulla. Aliquam placerat, massa id aliquam lacinia, turpis turpis condimentum sapien, non aliquam odio lectus id neque. Donec vehicula, enim ut sodales molestie, lectus tellus pulvinar arcu, id consectetur quam lorem vitae sapien. Maecenas lacinia convallis lacus, nec blandit nulla. Suspendisse potenti. Aenean et lectus lobortis, ornare mi eu, porta nisl. Phasellus orci neque, rhoncus et neque sed, accumsan fermentum urna. Cras semper massa quis mi rutrum congue.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vehicula aliquet justo, a ornare diam. Morbi laoreet sit amet quam ac fermentum. Aliquam sollicitudin et nisl et aliquet. Etiam neque quam, viverra in mattis vel, rutrum sed risus. Vivamus tristique diam leo, eu sagittis ligula venenatis ac. Aliquam ultrices porttitor fermentum. Cras ut tortor semper, tempus turpis eu, fringilla orci. Donec quis urna at tortor auctor cursus ut non risus. Duis laoreet metus eu purus sodales auctor. Nam iaculis, tellus non ultrices."
            };

            Console.WriteLine(ac.ActaObservaciones.Length.ToString());

            //document.Add(GetFolioParagraphForDocument(BOLDFONT, ac.Folio));
            document.Add(GetTituloActaForDocument(BOLDFONT));
            document.Add(GetBodyFirstPage(
                BOLDFONT,
                document,
                ac.HoraInicio,
                ac.HoraFinal,
                ac.FechaFinal,
                ac.FechaCreacion,
                ac.OrdenVerificador,
                ac.OrdenDomicilio,
                ac.OrdenEmpresa,
                ac.OrdenGiro,
                ac.OrdenFechaCreacion,
                ac.OrdenFolio,
                ac.InspectorNumCredencial,
                ac.FechaComisionInspector,
                ac.NumOficioComision,
                ac.ActaEntrevistadoNombre,
                ac.ActaEntrevistadoDocumentoIdentidad,
                ac.ActaEntrevistadoDocumentoIdentidadDependencia,
                ac.ActaEntrevistadoDocumentoIdentidadNumId,
                ac.ActaEntrevistadoPuesto,
                ac.ActaEntrevistadoPermiso,
                ac.ActaEntrevistadoObservaciones,
                ac.ActaTestigo1Nombre,
                ac.ActaTestigo1Domicilio,
                ac.ActaTestigo1DocumentoIdentidad,
                ac.ActaTestigo1DocumentoIdentidadNumId,
                ac.ActaTestigo1Puesto,
                ac.ActaTestigo2Nombre,
                ac.ActaTestigo2Domicilio,
                ac.ActaTestigo2DocumentoIdentidad,
                ac.ActaTestigo2DocumentoIdentidadNumId,
                ac.ActaTestigo2Puesto,
                ac.ActaObservaciones
            ));


            if (!(ac.ActaObservaciones.Length >= 2069))
            {
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE)); // Salto de pagina
            }



            //document.Add(new Paragraph("\n"));
            //document.Add(GetFolioParagraphForDocument(BOLDFONT, ac.Folio));
            document.Add(GetBodySecondPage(BOLDFONT, document,ac.ActaEntrevistadoNombre, ac.ActaEntrevistadoObservaciones,ac.HoraFinal, ac.FechaFinal));
            document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(GetBodyLegend());
            //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE)); // Salto de pagina

            Table SignsTable = GetSignsTable(pageSize, ac.OrdenVerificador, ac.ActaEntrevistadoNombre, ac.ActaTestigo1Nombre, ac.ActaTestigo2Nombre);

            //https://kb.itextpdf.com/home/it7kb/faq/how-to-add-a-table-to-the-bottom-of-the-last-page
            //using iText.Layout.Renderer;
            //using iText.Layout.Layout;
            //IRenderer tableRenderer = SignsTable.CreateRendererSubTree().SetParent(document.GetRenderer());
            //LayoutResult tableLayoutResult = tableRenderer.Layout(new LayoutContext(new LayoutArea(0, new Rectangle(pdfDocument.GetDefaultPageSize().GetWidth(), 1000))));
            //float totalHeight = tableLayoutResult.GetOccupiedArea().GetBBox().GetHeight(); // La altura de la tabla esta fixeada, es 200

            //Paragraph paragraph = new Paragraph("Folio: DPC/1548/2022");
            //IRenderer paragraphRenderer = paragraph.CreateRendererSubTree();
            //LayoutResult result = paragraphRenderer.SetParent(document.GetRenderer()).Layout(new LayoutContext(new LayoutArea(1, new Rectangle(1000, 100))));
            //float totalWidth = ((ParagraphRenderer)paragraphRenderer).GetMinMaxWidth().GetMaxWidth();
            //Console.WriteLine(totalWidth);

            document.Add(SignsTable);


            //Paragraph p = new Paragraph("Hello world").Add(new Tab());
            //ILineDrawer filling = new DashedLine();
            //PageSize pageSize1 = document.GetPdfDocument().GetDefaultPageSize();
            //Rectangle effectivePageSize = document.GetPageEffectiveArea(pageSize1);
            //float rightTabStopPoint = effectivePageSize.GetWidth();
            //TabStop tabStop = new TabStop(rightTabStopPoint, TabAlignment.LEFT, filling);
            //p.AddTabStops(tabStop);
            //document.Add(p);



            SetNumberPages(document);
            SetFolioInAllPages(document, "DPC/155465448/2022");

            document.Close();
        }
    }
}
