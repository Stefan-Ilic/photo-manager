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
using PicDB.Helper;

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
            var pdf = new PdfWriter("Report");
            pdf.Title($"Report of {pic.FileName}");

            pdf.Image(pic.FilePath);

            pdf.Heading1("EXIF Information");
            pdf.Line($"Make: {pic.EXIF.Make}");
            pdf.Line($"f-Number: {pic.EXIF.FNumber}");
            pdf.Line($"Exposure Time: {pic.EXIF.ExposureTime}");
            pdf.Line($"Flash: {pic.EXIF.Flash}");
            pdf.Line($"ISO Value: {pic.EXIF.ISOValue}");
            pdf.Line($"Exposure Program: {pic.EXIF.ExposureProgram}");

            pdf.Heading1("IPTC Information");
            pdf.Line($"Keywords: {pic.IPTC.Keywords}");
            pdf.Line($"Caption: {pic.IPTC.Caption}");
            pdf.Line($"By-Line: {pic.IPTC.ByLine}");
            pdf.Line($"Copyright Notice: {pic.IPTC.CopyrightNotice}");
            pdf.Line($"Headline: {pic.IPTC.Headline}");

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
