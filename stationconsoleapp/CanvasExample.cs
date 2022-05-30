using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iText;
using iText.Commons.Utils;
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
    class CanvasExample
    {
        public void generateFile()
        {
            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";
            
            var fos = new FileStream(dest, FileMode.Create);
            var writer = new PdfWriter(fos);
            var pdf = new PdfDocument(writer);
            var ps = PageSize.A4.Rotate();
            var page = pdf.AddNewPage(ps);

            
            
            //var canvas = new PdfCanvas(page);
            //canvas.ConcatMatrix(1, 0, 0, 1, ps.GetWidth() / 2, ps.GetHeight() / 2);



            // Draw the axes
            pdf.Close();
        }
    }
}
