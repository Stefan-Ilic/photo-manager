using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using BIF.SWE2.Interfaces.ViewModels;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PicDB.Reporting
{
    /// <summary>
    /// Class used to create reports
    /// </summary>
    public static class Report
    {
        /// <summary>
        /// Creates report for a single picture
        /// </summary>
        /// <param name="pic"></param>
        public static void Create(IPictureViewModel pic)
        {
            // Create a new PDF document
            var pdf = new PdfDocument();
            pdf.Info.Title = $"Report of {pic.FileName}";

            // Create a new PDF document
            var page = pdf.AddPage();

            // Get an XGraphics object for drawing
            var gfx = XGraphics.FromPdfPage(page);

            // Create fonts
            var titleFont = new XFont("Arial", 20, XFontStyle.Bold);
            var h2Font = new XFont("Arial", 15, XFontStyle.Bold);
            var standardFont = new XFont("Arial", 12);
            // Title
            gfx.DrawString($"Report of {pic.FileName}",
                titleFont, XBrushes.Black, new XRect(0, 10, page.Width, page.Height),
                XStringFormats.TopCenter);

            //Image
            var image = XImage.FromFile(pic.FilePath);
            var scalingFactor = (decimal)image.PixelHeight / 800;
            var newWidth = Convert.ToInt32(image.PixelWidth * scalingFactor);
            var newHeight = Convert.ToInt32(image.PixelHeight * scalingFactor);
            var startingPoint = (595 / 2) - (newWidth / 2); // 595 is page width in pixels
            gfx.DrawImage(image, startingPoint, 80, newWidth, newHeight);

            //EXIF
            gfx.DrawString("EXIF Information",
                h2Font, XBrushes.Black, new XRect(50, 350, page.Width, page.Height),
                XStringFormats.TopLeft);

            gfx.DrawString($"Make: {pic.EXIF.Make}",
                standardFont, XBrushes.Black, new XRect(50, 370, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"F-Number: {pic.EXIF.FNumber}",
                standardFont, XBrushes.Black, new XRect(50, 390, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"Exposure Time: {pic.EXIF.ExposureTime}",
                standardFont, XBrushes.Black, new XRect(50, 410, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"ISO Value: {pic.EXIF.ISOValue}",
                standardFont, XBrushes.Black, new XRect(50, 430, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"Flash: {pic.EXIF.Flash}",
                standardFont, XBrushes.Black, new XRect(50, 450, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"Exposure Program: {pic.EXIF.ExposureProgram}",
                standardFont, XBrushes.Black, new XRect(50, 470, page.Width, page.Height),
                XStringFormats.TopLeft);

            //IPTC
            gfx.DrawString("IPTC Information",
                h2Font, XBrushes.Black, new XRect(50, 500, page.Width, page.Height),
                XStringFormats.TopLeft);

            gfx.DrawString($"Keywords: {pic.IPTC.Keywords}",
                standardFont, XBrushes.Black, new XRect(50, 520, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"By-Line: {pic.IPTC.ByLine}",
                standardFont, XBrushes.Black, new XRect(50, 540, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"Copyright Notice: {pic.IPTC.CopyrightNotice}",
                standardFont, XBrushes.Black, new XRect(50, 560, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"Headline: {pic.IPTC.Headline}",
                standardFont, XBrushes.Black, new XRect(50, 580, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString($"Caption: {pic.IPTC.Caption}",
                standardFont, XBrushes.Black, new XRect(50, 600, page.Width, page.Height),
                XStringFormats.TopLeft);

            // Save the document...
            var pdfName = $"{pic.FileName.TrimEnd(".jpg".ToCharArray())}.pdf";
            var dir = Path.Combine(AppContext.Instance.WorkingDirectory, "Reports");
            Directory.CreateDirectory(dir);
            pdf.Save(Path.Combine(dir, pdfName));
            //TODO Display Photographer
            //TODO error handling if file is currently open
        }
    }
}
