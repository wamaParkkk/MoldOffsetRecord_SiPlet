using System;
using System.IO;

namespace MoldOffsetRecord_SiPlet
{
    class Global
    {
        public static string ConfigurePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\Configure\"));
        public static string localLogFilePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\MES\"));
        public static string searchFileDirectory = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\DownloadedFiles\"));
    }
}
