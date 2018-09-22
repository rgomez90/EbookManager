using System;
using System.IO;

namespace EbookManager.BLL
{
    public static class FilePaths
    {

        public static string RootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string AppDataDirectory = Path.Combine(RootDirectory, "EbookManager");

        public static string EbookDataDirectory = Path.Combine(AppDataDirectory, "data");

        public static string EbookGenresFile = Path.Combine(EbookDataDirectory, "genres.json");

        public static string EbookListFile = Path.Combine(EbookDataDirectory, "ebooks.json");


        public static bool AppDirectoryExist()
        {
            return Directory.Exists(AppDataDirectory);
        }
    }
}