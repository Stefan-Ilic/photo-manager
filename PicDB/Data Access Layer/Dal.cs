using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;

namespace PicDB.Data_Access_Layer
{
    /// <summary>
    /// DataAccessLayer for real database access
    /// </summary>
    public class Dal : IDataAccessLayer
    {
        /// <summary>
        /// Returns a filterd list of Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts,
            IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            Connect();

            var list = new List<IPictureModel>();
            var command = new SqlCommand(
                @"SELECT Pictures.ID as picture_id, Filename, Make, FNumber, ExposureTime, ISOValue, Flash, ExposureProgram, Keywords, Caption, ByLine, CopyrightNotice, Headline
                FROM Pictures 
                INNER JOIN EXIF 
                ON Pictures.ID = EXIF.ID
                INNER JOIN IPTC
                ON Pictures.ID = IPTC.ID", Connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //var EXIF = (string)reader["EXIF"];
                    //var IPTC = (string)reader["IPTC"];
                    list.Add(new PictureModel((string)reader["FileName"])
                    {
                        ID = (int)reader["picture_id"],
                        EXIF = new EXIFModel()
                        {
                            Make = (string)reader["Make"],
                            FNumber = (decimal)reader["FNumber"],
                            ExposureTime = (decimal)reader["ExposureTime"],
                            ISOValue = (decimal)reader["ISOValue"],
                            Flash = (bool)reader["Flash"],
                            ExposureProgram = (ExposurePrograms)reader["ExposureProgram"]
                        },
                        IPTC = new IPTCModel()
                        {
                            Keywords = (string)reader["Keywords"],
                            ByLine = (string)reader["ByLine"],
                            Caption = (string)reader["Caption"],
                            CopyrightNotice = (string)reader["CopyrightNotice"],
                            Headline = (string)reader["Headline"],
                        }
                    });
                }
            }

            Disconnect();

            return list;
        }

        /// <summary>
        /// Returns ONE Picture from the database.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPictureModel GetPicture(int ID)
        {
            return new PictureModel();
        }

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        /// <param name="picture"></param>
        public void Save(IPictureModel picture)
        {
            Connect();





            var command = new SqlCommand(@"INSERT INTO Pictures (FileName) OUTPUT INSERTED.ID
                VALUES (@filename)", Connection);
            //command.Parameters.AddWithValue("@id", picture.ID);
            command.Parameters.AddWithValue("@filename", picture.FileName);
            //command.Parameters.AddWithValue("@iptc", iptcId);
            //command.Parameters.AddWithValue("@exif", exifId);
            //command.Parameters.AddWithValue("@camera", picture.Camera.ID);
            //command.ExecuteNonQuery();
            var newId = (int)command.ExecuteScalar();

            command = new SqlCommand(@"INSERT INTO EXIF (ID, Make, FNumber, ExposureTime, ISOValue, Flash, ExposureProgram)
                VALUES (@id, @make, @fNumber, @exposureTime, @isoValue, @flash, @exposureProgram)", Connection);
            command.Parameters.AddWithValue("@id", newId);
            command.Parameters.AddWithValue("@make", picture.EXIF.Make);
            command.Parameters.AddWithValue("@fNumber", picture.EXIF.FNumber);
            command.Parameters.AddWithValue("@exposureTime", picture.EXIF.ExposureTime);
            command.Parameters.AddWithValue("@isoValue", picture.EXIF.ISOValue);
            command.Parameters.AddWithValue("@flash", picture.EXIF.Flash);
            command.Parameters.AddWithValue("@exposureProgram", (int)picture.EXIF.ExposureProgram);
            command.ExecuteNonQuery();

            command = new SqlCommand(@"INSERT INTO IPTC (ID, Keywords, ByLine, CopyrightNotice, Headline, Caption)
                VALUES (@id, @keywords, @byLine, @copyrightNotice, @headline, @caption)", Connection);
            command.Parameters.AddWithValue("@id", newId);
            command.Parameters.AddWithValue("@keywords", picture.IPTC.Keywords);
            command.Parameters.AddWithValue("@byLine", picture.IPTC.ByLine);
            command.Parameters.AddWithValue("@copyrightNotice", picture.IPTC.CopyrightNotice);
            command.Parameters.AddWithValue("@headline", picture.IPTC.Headline);
            command.Parameters.AddWithValue("@caption", picture.IPTC.Caption);
            command.ExecuteNonQuery();

            Disconnect();
        }

        /// <summary>
        /// Deletes a Picture from the database.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePicture(int ID)
        {
            Connect();

            var command = new SqlCommand(
                @"DELETE FROM Pictures WHERE ID = @id;
                DELETE FROM EXIF WHERE ID = @id;
                DELETE FROM IPTC WHERE ID = @id"
                , Connection);
            command.Parameters.AddWithValue("@id", ID);
            command.ExecuteNonQuery();

            Disconnect();
        }

        /// <summary>
        /// Returns a list of ALL Photographers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return new List<IPhotographerModel>();
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

        }

        /// <summary>
        /// Deletes a Photographer. A Exception is thrown if a Photographer is still linked to a picture.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePhotographer(int ID)
        {

        }

        /// <summary>
        /// Returns a list of ALL Cameras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICameraModel> GetCameras()
        {
            return new List<ICameraModel>();
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

        /// <summary>
        /// The connection string for the database connection
        /// </summary>
        public string ConnectionString { get; set; } =
            "Data Source=Ilic;Initial Catalog = PicDB; Integrated Security = True;";

        /// <summary>
        /// The connection to the database
        /// </summary>
        public SqlConnection Connection { get; set; }

        private void Connect()
        {
            if (Connection != null) return;
            Connection = new SqlConnection { ConnectionString = ConnectionString };
            Connection.Open();
        }

        private void Disconnect()
        {
            if (Connection == null) return;
            Connection.Close();
            Connection.Dispose();
            Connection = null;
        }

        #region Helper

        private enum DataObject
        {
            Iptc,
            Exif
        }
        private int GenerateId(DataObject obj)//TODO delete if useless
        {
            switch (obj)
            {
                case DataObject.Iptc:
                    return GetIptcCount() + 1;
                case DataObject.Exif:
                    return GetExifCount() + 1;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private int GetExifCount()
        {
            var command = new SqlCommand(@"SELECT * FROM EXIF", Connection);
            try
            {
                return (int)command.ExecuteScalar();
            }
            catch (Exception) //TODO change this later or delete entirely
            {
                return 0;
            }
        }

        private int GetIptcCount()
        {
            var command = new SqlCommand(@"SELECT * FROM IPTC", Connection);
            try
            {
                return (int)command.ExecuteScalar();
            }
            catch (Exception) //TODO change this later or delete entirely
            {
                return 0;
            }
        }

        private static string GetConnectionString()
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            var settings = ConfigurationManager.ConnectionStrings["standard"];

            // If found, return the connection string.
            returnValue = settings?.ConnectionString;

            return returnValue;
        }

        #endregion
    }
}
