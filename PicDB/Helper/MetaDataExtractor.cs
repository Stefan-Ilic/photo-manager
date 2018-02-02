using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.Iptc;
using PicDB.Models;
using Directory = System.IO.Directory;

namespace PicDB.Helper
{
    /// <summary>
    /// Extracts Metadata from a picture
    /// </summary>
    public class MetaDataExtractor<T>
    {
        /// <summary>
        /// Extracts metadata and assigns properties according to Type of Metadata
        /// </summary>
        /// <param name="fileName"></param>
        public MetaDataExtractor(string fileName)
        {
            const string path = @"C:\projects\SWE2\SWE2-CS\deploy\Pictures\";
            var fullPath = Path.Combine(path, fileName);
            if (typeof(T) == typeof(EXIFModel))
            {
                ExtractExif(fullPath);
            }
            else if (typeof(T) == typeof(IPTCModel))
            {
                ExtractIptc(fullPath);
            }
            else
            {
                throw new NotSupportedException("Type is not supported");
            }
        }

        private void ExtractExif(string fullPath)
        {
            var directories = ImageMetadataReader.ReadMetadata(fullPath);
            var exif = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            if (exif != null)
            {
                foreach (var tag in exif.Tags)
                {
                    switch (tag.Name)
                    {
                        case "F-Number":
                            try
                            {
                                FNumber = Convert.ToDecimal(tag.Description.TrimStart('f').TrimStart('/'));
                            }
                            catch (Exception)
                            {
                                FNumber = 0;
                            }
                            break;
                        case "Exposure Time":
                            try
                            {
                                ExposureTime = Convert.ToDecimal(tag.Description);
                            }
                            catch (Exception)
                            {
                                FNumber = 0;
                            }
                            break;
                        case "ISO Value":
                            try
                            {
                                ISOValue = Convert.ToDecimal(tag.Description);
                            }
                            catch (Exception)
                            {
                                ISOValue = 0;
                            }
                            break;
                        case "Flash":
                            if (!tag.Description.Contains("not"))
                            {
                                Flash = true;
                            }
                            break;
                        case "Exposure Program":
                            //TODO TO BE DONE
                            break;
                    }
                }
            }
            var exifMake = directories.OfType<ExifIfd0Directory>().FirstOrDefault();
            if (exifMake != null)
            {
                foreach (var tag in exifMake.Tags)
                {
                    if (tag.Name == "Make")
                    {
                        Make = tag.Description;
                    }
                }
            }
        }

        private void ExtractIptc(string fullPath)
        {
            var directories = ImageMetadataReader.ReadMetadata(fullPath);
            var iptc = directories.OfType<IptcDirectory>().FirstOrDefault();
            if (iptc == null) return;
            foreach (var tag in iptc.Tags)
            {
                switch (tag.Name)
                {
                    case "Keywords":
                        Keywords = tag.Description;
                        break;
                    case "By-line":
                        ByLine = tag.Description;
                        break;
                    case "Copyright Notice":
                        CopyrightNotice = tag.Description;
                        break;
                    case "Headline":
                        Headline = tag.Description;
                        break;
                    case "Caption/Abstract":
                        Caption = tag.Description;
                        break;
                }
            }
        }

        /// <summary>
        /// EXIF: Name of camera
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// EXIF: Aperture number
        /// </summary>
        public decimal FNumber { get; set; }

        /// <summary>
        /// EXIF: Exposure time
        /// </summary>
        public decimal ExposureTime { get; set; }

        /// <summary>
        /// EXIF: ISO value
        /// </summary>
        public decimal ISOValue { get; set; }

        /// <summary>
        /// EXIF: Flash yes/no
        /// </summary>
        public bool Flash { get; set; }

        /// <summary>
        /// EXIF: The exposure program
        /// </summary>
        public ExposurePrograms ExposureProgram { get; set; }

        /// <summary>
        /// IPTC: A list of keywords
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// IPTC: Name of the photographer
        /// </summary>
        public string ByLine { get; set; }

        /// <summary>
        /// IPTC: copyright noties. 
        /// </summary>
        public string CopyrightNotice { get; set; }

        /// <summary>
        /// IPTC:Summary/Headline of the picture
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// IPTC: Caption/Abstract, a description of the picture
        /// </summary>
        public string Caption { get; set; }
    }
}
