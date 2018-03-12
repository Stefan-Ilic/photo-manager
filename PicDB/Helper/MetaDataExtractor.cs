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
            var path = Path.Combine(AppContext.Instance.WorkingDirectory, "Pictures");
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
            var exifMake = directories.OfType<ExifIfd0Directory>().FirstOrDefault();
            var exposureTime = exif?.GetDescription(ExifDirectoryBase.TagExposureTime).TrimEnd(" sec".ToCharArray())
                .Split('/');
            return new EXIFModel()
            {
                FNumber = Convert.ToDecimal(exif?.GetDescription(ExifDirectoryBase.TagFNumber).TrimStart('f')
                    .TrimStart('/')),
                ExposureTime = Convert.ToDecimal(exposureTime?[0]) / Convert.ToDecimal(exposureTime?[1]),
                ISOValue = Convert.ToDecimal(exif?.GetDescription(ExifDirectoryBase.TagIsoEquivalent)),
                Flash = exif?.GetDescription(ExifDirectoryBase.TagIsoEquivalent).Contains("not") ?? false,
                ExposureProgram = GetExposureProgram(exif?.GetDescription(ExifDirectoryBase.TagExposureProgram)),
                Make = exifMake?.GetDescription(ExifDirectoryBase.TagMake)
            };
        }

        private static IIPTCModel ExtractIptc(string fullPath)
        {
            var directories = ImageMetadataReader.ReadMetadata(fullPath);
            var iptc = directories.OfType<IptcDirectory>().FirstOrDefault();
            return new IPTCModel()
            {
                //Keywords = iptc?.GetDescription(IptcDirectory.TagKeywords),
                Keywords = "But, Can, You, Do, This, _._",
                //ByLine = iptc?.GetDescription(IptcDirectory.TagByLine),
                ByLine = "Stefan Ilic",
                // Caption = iptc?.GetDescription(IptcDirectory.TagCaption),
                Caption = "Fake Caption",
                // CopyrightNotice = iptc?.GetDescription(IptcDirectory.TagCopyrightNotice),
                CopyrightNotice = "Get some if you want some",
                // Headline = iptc?.GetDescription(IptcDirectory.TagHeadline),
                Headline = "Bat child escapes"
            };
        }

        private static ExposurePrograms GetExposureProgram(string exp)
        {
            switch (exp.ToLower())
            {
                case "aperture priority":
                    return ExposurePrograms.AperturePriority;
                case "not defined":
                    return ExposurePrograms.NotDefined;
                case "manual":
                    return ExposurePrograms.Manual;
                case "program normal":
                    return ExposurePrograms.Normal;
                case "shutter priority":
                    return ExposurePrograms.ShutterPriority;
                case "creative program":
                    return ExposurePrograms.CreativeProgram;
                case "action program":
                    return ExposurePrograms.ActionProgram;
                case "portrait mode":
                    return ExposurePrograms.PortraitMode;
                case "landscape mode":
                    return ExposurePrograms.LandscapeMode;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
