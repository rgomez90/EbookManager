using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace EbookManager.BLL
{
    public class EbookManagerInitializer
    {
        private static IList<Ebook> _ebooks;

        public static IList<Ebook> Ebooks => _ebooks;

        public static IList<Ebook> Initizialize()
        {
            if (!FilePaths.AppDirectoryExist())
            {
                var dir = Directory.CreateDirectory(FilePaths.AppDataDirectory);
                var dataDir = dir.CreateSubdirectory("data");
                dataDir.CreateSubdirectory("ebooks");
                File.Create(Path.Combine(dataDir.FullName, "ebooks.json")).Close();
                var list = new List<Ebook>();
                var jsonStr = JsonConvert.SerializeObject(list);
                File.WriteAllText(FilePaths.EbookListFile,jsonStr);
                File.Create(Path.Combine(dataDir.FullName, "genres.json"));
                File.WriteAllText(FilePaths.EbookGenresFile, JsonConvert.SerializeObject(new List<string>()));
                dir.CreateSubdirectory("logs");
            }
            LoadEbooks();
            return _ebooks;
        }

        private static void LoadEbooks()
        {
            var jsonStr = File.ReadAllText(FilePaths.EbookListFile);
            _ebooks = JsonConvert.DeserializeObject<List<Ebook>>(jsonStr);
        }
    }
}
