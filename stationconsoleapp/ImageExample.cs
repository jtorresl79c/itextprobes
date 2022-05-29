using System;
using System.Collections.Generic;
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
    class ImageExample
    {
        public void generateFile()
        {
            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]) + SEPARATOR;
            
            string DOG = routePath + "img" + SEPARATOR + "dog.bmp";
            string FOX = routePath + "img" + SEPARATOR + "fox.bmp";
            
            string dest = routePath + "files" + SEPARATOR + System.IO.Path.GetRandomFileName() + ".pdf";
            var writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            var pdf = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            PageSize pageSize = PageSize.LETTER;
            var document = new Document(pdf, pageSize); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#


            //var fox = new Image(ImageDataFactory.Create(FOX));
            //var dog = new Image(ImageDataFactory.Create(DOG));

            // Lo mismo que arriba, pero aqui su tipo de variable no es generico
            iText.Layout.Element.Image fox = new Image(ImageDataFactory.Create(FOX));
            iText.Layout.Element.Image dog = new iText.Layout.Element.Image(ImageDataFactory.Create(DOG));

            Paragraph p = new Paragraph()
                            .Add("The quick brown ")
                            .Add(fox)
                            .Add("jumps over the lazy ")
                            .Add(dog);

            document.Add(p);

            document.Close();



            //const String DEST = "../../../results/chapter01/quick_brown_fox.pdf";







        }
    }
}
