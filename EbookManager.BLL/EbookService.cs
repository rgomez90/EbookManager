using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace EbookManager.BLL
{
    public class EbookService
    {
        public void RegisterEbook(Ebook ebook, string coverPath, string ebookPath)
        {
            int id = 1;
            if (EbookManagerInitializer.Ebooks.Any())
                id = EbookManagerInitializer.Ebooks.Max(x => x.Id) + 1;
            ebook.SetId(id);
            var ebookDirectory = Directory.CreateDirectory(Path.Combine(FilePaths.EbookDataDirectory, ebook.Id.ToString()));
            File.Copy(ebookPath, Path.Combine(ebookDirectory.FullName, ebook.Title));
            //Image.FromStream(new MemoryStream(ebook.CoverImage)).Save("cover", ImageFormat.Png);
            if (!String.IsNullOrEmpty(coverPath))
            {
                File.Copy(coverPath, Path.Combine(ebookDirectory.FullName, "cover.png"));
            }
            ebook.RegistrationDate = DateTime.Now;
            EbookManagerInitializer.Ebooks.Add(ebook);
            SaveEbooksFile();
        }

        private static void SaveEbooksFile()
        {
            var jStr = JsonConvert.SerializeObject(EbookManagerInitializer.Ebooks);
            File.WriteAllText(FilePaths.EbookListFile, jStr);
        }

        public void DeleteEbook(int id)
        {
            if (id < 1) throw new ArgumentException();
            EbookManagerInitializer.Ebooks.Remove(EbookManagerInitializer.Ebooks.SingleOrDefault(x => x.Id == id));
            SaveEbooksFile();
            Directory.Delete(Path.Combine(FilePaths.EbookDataDirectory, id.ToString()), true);
        }
    }
}
