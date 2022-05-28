using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

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
            document.Add(new Paragraph("Hello World!"));
            document.Close();
        }
    }
}
