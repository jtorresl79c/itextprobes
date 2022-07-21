using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationconsoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            //OrdenInspeccion ordenInspeccion = new OrdenInspeccion();
            //ordenInspeccion.generateFile();


            //ImageExample imageExample = new ImageExample();
            //imageExample.generateFile();

            //TableExample tableExample = new TableExample();
            //tableExample.generateFile();

            //CanvasExample canvasExample = new CanvasExample();
            //canvasExample.generateFile();

            RectangleExample rectangleExample = new RectangleExample();
            rectangleExample.generateFile();

        }
    }
}
