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
    class RectangleExample
    {
        public void generateFile()
        {
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";


            var fos = new FileStream(dest, FileMode.Create);
            var writer = new PdfWriter(fos);
            var pdf = new PdfDocument(writer);
            var ps = PageSize.A4.Rotate();
            var page = pdf.AddNewPage(ps);

            var canvas = new PdfCanvas(page);


            //Store a "backup" of the current graphical state

            canvas.SaveState();



            //Change the page's coordinate system so that 0,0 is at the center

            canvas.ConcatMatrix(1, 0, 0, 1, ps.GetWidth() / 2, ps.GetHeight() / 2);




            // When joining lines we want them to use a rounded corner

            canvas.SetLineJoinStyle(PdfCanvasConstants.LineJoinStyle.ROUND);



            //Draw X axis

            canvas.MoveTo(-(ps.GetWidth() / 2 - 15), 0)

                    .LineTo(ps.GetWidth() / 2 - 15, 0)

                    .Stroke();



            //Draw Y axis

            canvas.MoveTo(0, -(ps.GetHeight() / 2 - 15))

                    .LineTo(0, ps.GetHeight() / 2 - 15)

                    .Stroke();



            //Draw X axis arrow

            canvas.MoveTo(ps.GetWidth() / 2 - 25, -10)

                    .LineTo(ps.GetWidth() / 2 - 15, 0)

                    .LineTo(ps.GetWidth() / 2 - 25, 10)

                    .Stroke();



            //Draw Y axis arrow

            canvas.MoveTo(-10, ps.GetHeight() / 2 - 25)

                    .LineTo(0, ps.GetHeight() / 2 - 15)

                    .LineTo(10, ps.GetHeight() / 2 - 25)

                    .Stroke();



            //Draw X serif

            for (int i = -((int)ps.GetWidth() / 2 - 61); i < ((int)ps.GetWidth() / 2 - 60); i += 40)
            {

                canvas.MoveTo(i, 5).LineTo(i, -5);

            }

            //Draw Y serif

            for (int j = -((int)ps.GetHeight() / 2 - 57); j < ((int)ps.GetHeight() / 2 - 56); j += 40)
            {

                canvas.MoveTo(5, j).LineTo(-5, j);

            }

            canvas.Stroke();



            //"Restore" our "backup" which resets any changes that the above made

            canvas.RestoreState();



            pdf.Close();

            //Paragraph p = new Paragraph("This is the text added in the rectangle.");

            //PdfCanvas canvas = new PdfCanvas(page);
            //Rectangle rect = new Rectangle(ps.GetWidth() - 90, ps.GetHeight() - 100, 50, 50);

            //canvas.Rectangle(rect);
            //canvas.Stroke();
            //pdf.Close();
        }
    }
}
