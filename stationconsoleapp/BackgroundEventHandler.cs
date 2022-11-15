using iText.Kernel.Events;
using iText.IO.Image;
using System;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;

namespace stationconsoleapp
{
    public class BackgroundEventHandler : IEventHandler
    {
        protected string routePath;
        public BackgroundEventHandler(string routePath)
        {
            this.routePath = routePath;
        }

        public virtual void HandleEvent(Event @event)
        {
            string IMAGE = routePath + System.IO.Path.DirectorySeparatorChar + "resources" + System.IO.Path.DirectorySeparatorChar + "ActaCircBg.jpg";
            //Image img = new Image(ImageDataFactory.Create(IMAGE)).ScaleToFit(1700, 1000).SetFixedPosition(0, 0);
            Image img = new Image(ImageDataFactory.Create(IMAGE));

            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;

            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(),
                    page.GetResources(), pdfDoc);

            Rectangle area = page.GetPageSize();

            new Canvas(canvas, area).Add(img);

            //Console.WriteLine("Hola mundo @#sa");



            //PdfExtGState state = new PdfExtGState().SetFillOpacity(0.6f);
            //canvas.SetExtGState(state);
            //Rectangle rect = new Rectangle(0, 0, pageSize.GetWidth(), pageSize.GetHeight());
            //canvas.AddImageFittedIntoRectangle(image, rect, false);
            //canvas.RestoreState();
        }
    }
}
