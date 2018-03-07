using System;
using System.IO;

namespace PicDB
{
    /// <summary>
    /// Provides additional management of the context of the app.
    /// </summary>
    internal sealed class AppContext
    {
        #region Singleton
        /// <summary>
        /// Gets the singleton instance of the <see cref="AppContext"/> class.
        /// </summary>
        public static AppContext Instance => _instance.Value;
        private static readonly Lazy<AppContext> _instance = new Lazy<AppContext>(() => new AppContext());

        private AppContext() { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the path for the current working directory.
        /// </summary>
        public string WorkingDirectory
        {
            get => _workingDirectory ??
                   Path.GetDirectoryName(new Uri(typeof(AppContext).Assembly.CodeBase).LocalPath);
            set => _workingDirectory = value;
        }
        private string _workingDirectory;
        #endregion
    }
}