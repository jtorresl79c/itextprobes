using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace stationconsoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = Environment.CurrentDirectory;
            string dest = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]) + Path.DirectorySeparatorChar + "files" + Path.DirectorySeparatorChar + Path.GetRandomFileName() + ".pdf";

            var writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            var pdf = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            var document = new Document(pdf); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#



            // Create a PdfFont
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            PdfFont font2 = PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD);

            // Add a Paragraph
            //document.Add(new Paragraph("Primer parrafo").SetFont(font));
            //document.Add(new Paragraph("asdasdsad").SetFont(font).Add(" asdasdsad").SetFont(font2));
            //document.Add(new Paragraph("Segundo parafro"));

            var orden = new { 
                Director = "LIC. BERNARDO VILLEGAS RAMÍREZ", 
                FechaCreacion = "VEINTISIETE DE MAYO DEL DOS MIL VEINTIDOS",
                Inspector = "JASON OTHONIEL TORRES LUIS",
                Domicilio = "Avenida Independencia 1350, Zona Urbana Río, C. P. 22010",
                RepresentanteLegal = "ELIZABETH LILIANA MONDRAGON LOPEZ",
                Giro = "DEPARTAMENTO DE ELECTRONICOS Y LINEA BLANCA",
                Motivo = "Inspeccion extraordinaria"
            };

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            //TextAlignment x = new TextAlignment();
            ;
            Paragraph parExecSummHeader2 = new Paragraph().SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED);
            parExecSummHeader2.Add(new Text(orden.Director).SetFont(boldFont));
            parExecSummHeader2.Add(", Director Municipal de Protección Civil de este Municipio de Tijuana, Baja California, en uso de las facultades que me confieren los preceptos ");
            parExecSummHeader2.Add(new Text("1,2,4, fracciones III y V, 19 fracciones II, VIII y XV, 58, 58 bis, 58 ter, 58 quater, 58 quinquies,").SetFont(boldFont));
            parExecSummHeader2.Add(" 94, 95, 96, 97, 98, 99, 100, 101, 102, 103 , 104, 105, 106 y demás relativos y aplicables del Reglamento de Protección Civil, en esta ciudad de Tijuana Baja California siendo el día");
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

            //// Create a List
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
            document.Close();


        }
    }
}
