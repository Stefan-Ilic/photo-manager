using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;
using PicDB.Helper;

namespace PicDB
{
    /// <summary>
    /// The Business Layer Implementation
    /// </summary>
    public class BusinessLayer : IBusinessLayer
    {
        #region Ctor

        /// <summary>
        /// ctor for mock dal
        /// </summary>
        /// <param name="type"></param>
        public BusinessLayer(string type = "real")
        {
            Dal = DalFactory.Create(type);
        }

        #endregion

        #region Pictures

        /// <summary>
        /// Returns a list of ALL Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures()
        {
            return Dal.GetPictures(null, null, null, null);
        }

        //TODO Search for names
        //TODO Search for photographers
        //TODO Search for IPTC
        //TODO Search for EXIF
        /// <summary>
        /// Returns a filterd list of Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts,
            IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            return Dal.GetPictures(namePart, photographerParts, iptcParts, exifParts);
        }

        /// <summary>
        /// Returns ONE Picture from the database.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPictureModel GetPicture(int ID)
        {
            return Dal.GetPicture(ID);
        }

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        /// <param name="picture"></param>
        public void Save(IPictureModel picture)
        {
            picture.ID = GenerateId(DataObject.Picture);
            Dal.Save(picture);
        }

        /// <summary>
        /// Deletes a Picture from the database AND from the file system.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePicture(int ID)
        {

        }

        /// <summary>
        /// Syncs the picture folder with the database.
        /// </summary>
        public void Sync()
        {
            if (Dal.GetType() == typeof(MockDal)) return;

            var newPics = new List<IPictureModel>();
            var picdir = Path.Combine(AppContext.Instance.WorkingDirectory, "Pictures");
            var fullFiles = Directory.GetFiles(picdir, "*.jpg", SearchOption.TopDirectoryOnly);
            var files = fullFiles.Select(Path.GetFileName).ToList();
            foreach (var file in files)
            {
                newPics.Add(new PictureModel(file));
            }

            var curPics = GetPictures();
            var curPicNames = GetPictures().Select(x => x.FileName);

            var picNamesToDelete = curPicNames.Except(files).ToList();
            var picNamesToAdd = files.Except(curPicNames).ToList();

            foreach (var pic in curPics)
            {
                if (picNamesToDelete.Contains(pic.FileName))
                {
                    DeletePicture(pic.ID);
                }
            }

            foreach (var picName in picNamesToAdd)
            {
                Save(new PictureModel(picName)
                {
                    EXIF = ExtractEXIF(picName)
                });
            }
        }

        #endregion

        #region Photographer

        /// <summary>
        /// Returns a list of ALL Photographers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return Dal.GetPhotographers();
        }

        /// <summary>
        /// Returns ONE Photographer
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPhotographerModel GetPhotographer(int ID)
        {
            return Dal.GetPhotographer(ID);
        }

        /// <summary>
        /// Saves all changes.
        /// </summary>
        /// <param name="photographer"></param>
        public void Save(IPhotographerModel photographer)
        {
            photographer.ID = GenerateId(DataObject.Photographer);
            Dal.Save(photographer);
        }

        /// <summary>
        /// Deletes a Photographer. A Exception is thrown if a Photographer is still linked to a picture.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePhotographer(int ID)
        {

        }

        #endregion

        #region IPTC, Exif

        /// <summary>
        /// Extracts IPTC information from a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IIPTCModel ExtractIPTC(string filename)
        {
            if (!PictureExists(filename))
            {
                throw new MissingPictureException();
            }
            return new IPTCModel()
            {
                ByLine = "But",
                Caption = "Can",
                CopyrightNotice = "You",
                Headline = "Do",
                Keywords = "This"
            };
        }

        /// <summary>
        /// Extracts EXIF information from a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEXIFModel ExtractEXIF(string filename)
        {
            if (!PictureExists(filename))
            {
                throw new MissingPictureException();
            }
            //return new EXIFModel()
            //{
            //    ExposureTime = 1,
            //    FNumber = 1,
            //    ISOValue = 1,
            //    Make = "Nikon I guess"
            //};
            return MetaDataExtractor<EXIFModel>.Create(filename);
        }

        /// <summary>
        /// Writes IPTC information back to a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="iptc"></param>
        public void WriteIPTC(string filename, IIPTCModel iptc)
        {

        }

        /// <summary>
        /// Returns a list of ALL Cameras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICameraModel> GetCameras()
        {
            return Dal.GetCameras();
        }

        /// <summary>
        /// Returns ONE Camera
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ICameraModel GetCamera(int ID)
        {
            return Dal.GetCamera(ID);
        }

        #endregion

        #region Dal

        /// <summary>
        /// The DataAccessLayer used
        /// </summary>
        public IDataAccessLayer Dal { get; set; }

        #endregion

        #region Helper

        /// <summary>
        /// Path where the pictures are located
        /// </summary>
        public string PicturePath { get; set; } = Path.Combine(AppContext.Instance.WorkingDirectory, "Pictures");

        private bool PictureExists(string filename)
        {
            return File.Exists(Path.Combine(PicturePath, filename));
        }

        private enum DataObject
        {
            Photographer,
            Picture
        }
        private int GenerateId(DataObject obj)
        {
            switch (obj)
            {
                case DataObject.Photographer:
                    return GetPhotographers().Max(x => x.ID) + 1;
                case DataObject.Picture:
                    if (!GetPictures().Any())
                    {
                        return 1;
                    }
                    return GetPictures().Max(x => x.ID) + 1;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        #endregion
    }
}
