using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.Iptc;
using PicDB.Models;

namespace PicDB.Helper
{
    /// <summary>
    /// Extracts Metadata from a picture
    /// </summary>
    public static class MetaDataExtractor<T>
    {
        /// <summary>
        /// Extracts metadata and assigns properties according to Type of Metadata
        /// </summary>
        /// <param name="fileName"></param>
        public static T Create(string fileName)
        {
            var path = Path.Combine(AppContext.Instance.WorkingDirectory,"Pictures");
            var fullPath = Path.Combine(path, fileName);
            if (typeof(T) == typeof(EXIFModel))
            {
                return (T)ExtractExif(fullPath);
            }

            if (typeof(T) == typeof(IPTCModel))
            {
                return (T)ExtractIptc(fullPath);
            }

            throw new NotSupportedException("Type is not supported");
        }

        private static IEXIFModel ExtractExif(string fullPath)
        {
            var directories = ImageMetadataReader.ReadMetadata(fullPath);
            var exif = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            var returner = new EXIFModel();
            if (exif != null)
            {
                foreach (var tag in exif.Tags)
                {
                    switch (tag.Name)
                    {
                        case "F-Number":
                            try
                            {
                                returner.FNumber = Convert.ToDecimal(tag.Description.TrimStart('f').TrimStart('/'));
                            }
                            catch (Exception)
                            {
                                returner.FNumber = 0;
                            }
                            break;
                        case "Exposure Time":
                            try
                            {
                                var newTag = tag.Description.TrimEnd(" sec".ToCharArray());
                                var calc = newTag.Split('/');
                                returner.ExposureTime = Convert.ToDecimal(calc[0]) / Convert.ToDecimal(calc[1]);
                            }
                            catch (Exception)
                            {
                                returner.FNumber = 0;
                            }
                            break;
                        case "ISO Speed Ratings":
                            try
                            {
                                returner.ISOValue = Convert.ToDecimal(tag.Description);
                            }
                            catch (Exception)
                            {
                                returner.ISOValue = 0;
                            }
                            break;
                        case "Flash":
                            if (!tag.Description.Contains("not"))
                            {
                                returner.Flash = true;
                            }
                            break;
                        case "Exposure Program":
                            switch (tag.Description.ToLower())
                            {
                                case "aperture priority":
                                    returner.ExposureProgram = ExposurePrograms.AperturePriority;
                                    break;
                                case "not defined":
                                    returner.ExposureProgram = ExposurePrograms.NotDefined;
                                    break;
                                case "manual":
                                    returner.ExposureProgram = ExposurePrograms.Manual;
                                    break;
                                case "program normal":
                                    returner.ExposureProgram = ExposurePrograms.Normal;
                                    break;
                                case "shutter priority":
                                    returner.ExposureProgram = ExposurePrograms.ShutterPriority;
                                    break;
                                case "creative program":
                                    returner.ExposureProgram = ExposurePrograms.CreativeProgram;
                                    break;
                                case "action program":
                                    returner.ExposureProgram = ExposurePrograms.ActionProgram;
                                    break;
                                case "portrait mode":
                                    returner.ExposureProgram = ExposurePrograms.PortraitMode;
                                    break;
                                case "landscape mode":
                                    returner.ExposureProgram = ExposurePrograms.LandscapeMode;
                                    break;
                                default:
                                    throw new NotSupportedException();
                            }
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
                        returner.Make = tag.Description;
                    }
                }
            }

            return returner;
        }

        private static IIPTCModel ExtractIptc(string fullPath)
        {
            var directories = ImageMetadataReader.ReadMetadata(fullPath);
            var iptc = directories.OfType<IptcDirectory>().FirstOrDefault();
            var returner = new IPTCModel();
            if (iptc == null) return returner;
            foreach (var tag in iptc.Tags)
            {
                switch (tag.Name)
                {
                    case "Keywords":
                        returner.Keywords = tag.Description;
                        break;
                    case "By-line":
                        returner.ByLine = tag.Description;
                        break;
                    case "Copyright Notice":
                        returner.CopyrightNotice = tag.Description;
                        break;
                    case "Headline":
                        returner.Headline = tag.Description;
                        break;
                    case "Caption/Abstract":
                        returner.Caption = tag.Description;
                        break;
                }
            }

            return returner;
        }
    }
}
