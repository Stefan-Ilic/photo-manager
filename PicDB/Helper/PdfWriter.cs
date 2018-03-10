using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PicDB.Helper
{
    /// <summary>
    /// Helper class for writing PDFs using PdfSharp
    /// </summary>
    public class PdfWriter
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public PdfWriter(string title)
        {
            Pdf.Info.Title = title;
            Page = Pdf.AddPage();
            Gfx = XGraphics.FromPdfPage(Page);
        }

        /// <summary>
        /// Tracks the line height
        /// </summary>
        private int _tracker = 20;

        /// <summary>
        /// The pdf document object
        /// </summary>
        public PdfDocument Pdf { get; set; } = new PdfDocument();

        /// <summary>
        /// Used for drawing on pdf
        /// </summary>
        public XGraphics Gfx { get; set; }

        /// <summary>
        /// The curret page in the pdf
        /// </summary>
        public PdfPage Page { get; set; }

        /// <summary>
        /// Title Font
        /// </summary>
        public XFont TitleFont { get; set; } = new XFont("Arial", 20, XFontStyle.Bold);

        /// <summary>
        /// Heading1 Font
        /// </summary>
        public XFont Heading1Font { get; set; } = new XFont("Arial", 15, XFontStyle.Bold);

        /// <summary>
        /// Standard Font
        /// </summary>
        public XFont StandardFont { get; set; } = new XFont("Arial", 12);

        /// <summary>
        /// Writes title
        /// </summary>
        /// <param name="title"></param>
        public void Title(string title)
        {
            Gfx.DrawString(title,
                TitleFont, XBrushes.Black, new XRect(0, _tracker, Page.Width, Page.Height),
                XStringFormats.TopCenter);
            _tracker += 50;
        }

        /// <summary>
        /// saves the pdf (you need to add pdf extension yourself)
        /// </summary>
        /// <param name="file"></param>
        public void Save(string file)
        {
            Pdf.Save(file);
        }

        /// <summary>
        /// Writes an Image to PDF
        /// </summary>
        /// <param name="path"></param>
        public void Image(string path)
        {
            //Image
            var image = XImage.FromFile(path);
            var scalingFactor = (decimal)image.PixelHeight / 800;
            var newWidth = Convert.ToInt32(image.PixelWidth * scalingFactor);
            var newHeight = Convert.ToInt32(image.PixelHeight * scalingFactor);
            var startingPoint = (595 / 2) - (newWidth / 2); // 595 is page width in pixels
            Gfx.DrawImage(image, startingPoint, _tracker, newWidth, newHeight);
            _tracker += newHeight + 10;
        }

        /// <summary>
        /// Writes Heading 1 to pdf
        /// </summary>
        /// <param name="heading"></param>
        public void Heading1(string heading)
        {
            _tracker += 10;
            Gfx.DrawString(heading,
                Heading1Font, XBrushes.Black, new XRect(50, _tracker, Page.Width, Page.Height),
                XStringFormats.TopLeft);
            _tracker += 20;
        }

        /// <summary>
        /// Writes a paragraph to pdf
        /// </summary>
        /// <param name="text"></param>
        public void Line(string text)
        {
            Gfx.DrawString(text,
                StandardFont, XBrushes.Black, new XRect(50, _tracker, Page.Width, Page.Height),
                XStringFormats.TopLeft);
            _tracker += 20;
        }
    }
}
