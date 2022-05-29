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
    class TableExample
    {
        public virtual void Process(Table table, String line, PdfFont font, bool isHeader)
        {
            // StringTokenizer(string text, char separator)
            // ALABAMA;AL;Montgomery;Birmingham;4,708,708;52,423;CST (UTC-6);EST (UTC-5);YES
            // tokenizer nos devuelve algo asi como un 'array' en donde cada elemento es un item
            // separado por ;, de esa forma podemos loopearlo y usarlo para agregar la info en la celda.
            StringTokenizer tokenizer = new StringTokenizer(line, ";");
            while (tokenizer.HasMoreTokens())
            {
                var tokenizerNextToken = tokenizer.NextToken();
                if (isHeader)
                {
                    table.AddHeaderCell(new Cell().Add(new Paragraph(tokenizerNextToken).SetFont(font)));
                }
                else
                {
                    table.AddCell(new Cell().Add(new Paragraph(tokenizerNextToken).SetFont(font)));
                }
            }
        }
        public void generateFileOfficalPageExample()
        {
            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";

            var writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            var pdf = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            PageSize pageSize = PageSize.A4.Rotate();
            var document = new Document(pdf, pageSize); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#
            document.SetMargins(20, 20, 20, 20);

            string DATA = routePath + SEPARATOR + "resources" + SEPARATOR + "united_states.csv";
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);


            float[] tableColumns = new float[] { 4, 1, 3, 4, 3, 3, 3, 3, 1 };
            Table table = new Table(UnitValue.CreatePercentArray(tableColumns))
                              .UseAllAvailableWidth();

            using (StreamReader sr = File.OpenText(DATA))
            {
                String line = sr.ReadLine(); // Se obtiene la primera linea del documento,
                                             // el cual contiene los nombres de las columnas de los headers
                                             // separador por ;

                //string line2 = sr.ReadLine(); // Si descomentaramos esta linea ahora tendriamos 
                // la segunda linea del documento, el cual es ALABAMA;AL;Montgomery;Birmingham;4,708,708;52,423;CST (UTC-6);EST (UTC-5);YES

                // El .ReadLine() es como si fuera un metodo estatico, ya que cada vez que se llama
                // se obtiene una linea (primera, segunda, tercera linea) y la siguiente vez que lo
                // si lo llamamos y obtuvimos la segunda linea, la siguiente vez que lo llamemos 
                // obtendriamos la tercera linea, PERO ENTENDAMOS SOLO POR LLAMARLO YA OBTENEMOS OTRA LINEA
                // si descomentamos 'line2' la linea que estariamos enviando en #SD123 seria la tercera linea
                // haciendo que la segunda linea ya no se imprimiera.

                Process(table, line, bold, true);
                while ((line = sr.ReadLine()) != null)
                {
                    Process(table, line, font, false); // #SD123
                }
            }

            document.Add(table);
            //Close document
            document.Close();

        }

        public void generateFile()
        {
            char SEPARATOR = System.IO.Path.DirectorySeparatorChar;
            string filepath = Environment.CurrentDirectory;
            string routePath = (filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0]);
            string dest = routePath + System.IO.Path.DirectorySeparatorChar + "iTextGeneratedFiles" + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName() + ".pdf";

            var writer = new PdfWriter(dest); // La funcion que crea literalmente el archivo en disco, sus parametros puede ser un string como aqui, o un obj de tipo http.response
            var pdf = new PdfDocument(writer); // Esto es lo que maneja el contenido que creamos, pero en un lenguaje de pdf creo, 
            PageSize pageSize = PageSize.A4.Rotate();
            var document = new Document(pdf, pageSize); // Para que no tengamos que meternos en la sintaxis de pdf, creo que esto la hace de traductor, para que podamos escribir en C#
            document.SetMargins(20, 20, 20, 20);

            string DATA = routePath + SEPARATOR + "resources" + SEPARATOR + "united_states.csv";
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);


            //float[] tableColumns = new float[] { 1,1,1,1,1,1,1,1,1 };
            float[] tableColumns = new float[] { 4, 1, 3, 4, 3, 3, 3, 3, 1 };

            // https://kb.itextpdf.com/home/it7kb/ebooks/itext-7-jump-start-tutorial-for-net/chapter-1-introducing-basic-building-blocks-net#Chapter1:Introducingbasicbuildingblocks|.NET-Publishingadatabase
            // Imagina 'table' como una hoja en blanco el cual representa la tabla completa,
            // Le estamos diciendo que va a tener 9 columnas con diferente tamaño, en la pagina
            // cada item del array 'tableColumns' indica una columna de la tabla, el valor que se
            // le asigna corresponde al tamaño de la columna, en la pagina te medio explica como
            // estos valores afectar al tamaño, pero funciona mas o menos igual a css grid, si 
            // descomentamos el tableColumns con puros unos, eso significa que todas las columnas
            // tendrian el mismo valor
            Table table = new Table(UnitValue.CreatePercentArray(tableColumns))
                              .UseAllAvailableWidth();


            
            // Tenemos que entender que una vez que la tabla se 'creo' lo unico que nosotros nos toca
            // hacer es llenar la tabla, pero se llena como si fuera un array, puros .Add, por cada .Add
            // nosotros agregamos una celda en el header que se recorre a la derecha.
            // (el AddHeaderCell es importante porque si la tabla no entra en una sola hoja, pues se pasa a la siguiente
            // pero como le indicamos cual es el header la siguiente hoja tambien tendra header)
            table.AddHeaderCell(new Cell().Add(new Paragraph("name").SetFont(bold))); // 1 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("abbr").SetFont(bold))); // 2 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("capital").SetFont(bold))); // 3 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("most populous city").SetFont(bold))); // 4 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("population").SetFont(bold))); // 5 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("square miles").SetFont(bold))); // 6 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("time zone 1").SetFont(bold))); // 7 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("time zone 2").SetFont(bold))); // 8 Cell
            table.AddHeaderCell(new Cell().Add(new Paragraph("dst").SetFont(bold))); // 9 Cell




            // Aqui hay que tener cuidado, cuandro agregamos una celda, se agrega en la posicion 1 claro,
            // y cada vez que se agrega se va agregando de izquierda a derecha, y se pasa a la siguiente fila
            // una vez que las columnas se hallan llenado en su totalidad,  (especificadas en tableColumns
            // los cuales fueron 9 columnas), por lo que no tenemos que preocuparnos por poner un comando para
            // pasar a la siguiente fila, pero por lo mismo hay que tener cuidado, si nuestra primera fila solo
            // tiene 8 columnas (y la 9na columna debe de estar en blanco) hay que poner el table.AddCell(new Cell().Add(new Paragraph("")))
            // vacio, ya que si no se pone la primera columna de la que queramos que sea nuestra siguiente fila, ahora sera la ultima columna
            // de la fila incorrecta.

            table.AddCell(new Cell().Add(new Paragraph("ALABAMA")));
            table.AddCell(new Cell().Add(new Paragraph("AL")));
            table.AddCell(new Cell().Add(new Paragraph("Montgomery")));
            table.AddCell(new Cell().Add(new Paragraph("Birmingham")));
            table.AddCell(new Cell().Add(new Paragraph("4,708,708")));
            table.AddCell(new Cell().Add(new Paragraph("52,423")));
            table.AddCell(new Cell().Add(new Paragraph("CST (UTC-6)")));
            table.AddCell(new Cell().Add(new Paragraph("EST (UTC-5)")));
            table.AddCell(new Cell().Add(new Paragraph("YES")));


            table.AddCell(new Cell().Add(new Paragraph("ALASKA")));
            table.AddCell(new Cell().Add(new Paragraph("AK")));
            table.AddCell(new Cell().Add(new Paragraph("Juneau")));
            table.AddCell(new Cell().Add(new Paragraph("Anchorage")));
            table.AddCell(new Cell().Add(new Paragraph("")));


            // Al final solo agregamos la tabla al documento como si fuera un simple parrafo o imagen.
            document.Add(table);
            //Close document
            document.Close();
        }
    }
}
