using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PicDB
{
    /// <inheritdoc />
    /// <summary>
    /// Thrown when the user tries to access a picture that doesnt exist
    /// </summary>
    [Serializable]
    public class MissingPictureException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        /// <summary>
        /// Thrown when the user tries to access a picture that doesnt exist
        /// </summary>
        public MissingPictureException()
        {
        }

        /// <summary>
        /// Thrown when the user tries to access a picture that doesnt exist
        /// </summary>
        public MissingPictureException(string message) : base(message)
        {
        }

        /// <summary>
        /// Thrown when the user tries to access a picture that doesnt exist
        /// </summary>
        public MissingPictureException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Thrown when the user tries to access a picture that doesnt exist
        /// </summary>
        protected MissingPictureException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
