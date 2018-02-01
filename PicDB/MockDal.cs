using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;

namespace PicDB
{
    /// <summary>
    /// The MockDal
    /// </summary>
    public class MockDal : IDataAccessLayer
    {
        /// <summary>
        /// Mock of the Pictures table
        /// </summary>
        public static List<IPictureModel> Pictures = new List<IPictureModel>
        {
            new PictureModel()
            {
                ID = 5678,
                FileName = "test5678.jpg"
            },
            new PictureModel()
            {
                ID = 1234,
                FileName = "blume"
            }
        };

        /// <summary>
        /// Mock of the Photographers table
        /// </summary>
        public static List<IPhotographerModel> Photographers = new List<IPhotographerModel>
        {

            new PhotographerModel()
            {
                ID = 5678,
                FirstName = "Hans",
                LastName = "Maulwurf",
                BirthDay = new DateTime(2000, 1, 1)
            },
            new PhotographerModel()
            {
                ID = 1234,
                FirstName = "Stefan",
                LastName = "Ilic",
                BirthDay = new DateTime(1997, 1, 10)
            }
        };

        /// <summary>
        /// Mock of the Cameras table
        /// </summary>
        public static List<ICameraModel> Cameras = new List<ICameraModel>
        {
            new CameraModel()
            {
                ID = 1234,
                Producer = "Canon",
                Make = "1DX",
                BoughtOn = new DateTime(2017, 10, 1)
            },
            new CameraModel()
            {
                ID = 5678,
                Producer = "Nikon",
                Make = "D4",
                BoughtOn = new DateTime(2017, 2, 7)
            }
        };

        /// <summary>
        /// Returns a filterd list of Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts,
            IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            if (namePart == null && photographerParts == null && iptcParts == null && exifParts == null)
            {
                return Pictures;
            }
            return Pictures.Where(x => x.FileName == namePart);
        }

        /// <summary>
        /// Returns ONE Picture from the database.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPictureModel GetPicture(int ID)
        {
            return Pictures.Single(x => x.ID == ID);
        }

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        /// <param name="picture"></param>
        public void Save(IPictureModel picture)
        {
            Pictures.Add(picture);
        }

        /// <summary>
        /// Deletes a Picture from the database.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePicture(int ID)
        {
            Pictures.RemoveAll(x => x.ID == ID);
        }

        /// <summary>
        /// Returns a list of ALL Photographers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return Photographers;
        }

        /// <summary>
        /// Returns ONE Photographer
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPhotographerModel GetPhotographer(int ID)
        {
            return new PhotographerModel();
        }

        /// <summary>
        /// Saves all changes.
        /// </summary>
        /// <param name="photographer"></param>
        public void Save(IPhotographerModel photographer)
        {
            Photographers.Add(photographer);
        }

        /// <summary>
        /// Deletes a Photographer. A Exception is thrown if a Photographer is still linked to a picture.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePhotographer(int ID)
        {
            Photographers.RemoveAll(x => x.ID == ID);
        }

        /// <summary>
        /// Returns a list of ALL Cameras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICameraModel> GetCameras()
        {
            return Cameras;
        }

        /// <summary>
        /// Returns ONE Camera
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ICameraModel GetCamera(int ID)
        {
            return new CameraModel();
        }
    }
}
