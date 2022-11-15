using Humanizer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            //RectangleExample rectangleExample = new RectangleExample();
            //rectangleExample.generateFile();

            //TableExample tableExample = new TableExample();
            //tableExample.generateRightTable();

            //OficioSimulacro oficioSimulacro = new OficioSimulacro();
            //oficioSimulacro.generateFile();

            //ActaCircunstanciada ac = new ActaCircunstanciada();
            //ac.generateFile();


            //NumberPage np = new NumberPage();
            //np.generateFile();

            GridExample ge = new GridExample();
            ge.generateFile();




            //DateTime date = DateTime.Now;
            //var culture = new System.Globalization.CultureInfo("es-ES");
            //string Dia = date.Day.ToWords(culture).ToUpper();
            //string Mes = culture.DateTimeFormat.GetMonthName(date.Month).ToString().ToUpper(); // enero, febrero, marzo, abril, mayo, junio
            //string Year = date.Year.ToWords(culture).ToUpper();
            //string Todo = $"{Dia} DE {Mes} DEL {Year}";

        }
    }
}
