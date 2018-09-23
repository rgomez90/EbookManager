using System;
using System.IO;

namespace EbookManager
{
    public class Ebook
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Resume { get; set; }
        public string Author { get; set; }
        public string Editorial { get; set; }
        public int Edition { get; set; }
        public string Isbn { get; set; }
        public byte[] CoverImage { get; set; }
        public FileInfo FilePath { get; set; }
        public int Id { get; protected set; }
        public FileInfo EbookFile { get; set; }

        public void SetId(int id)
        {
            if (id == 0) throw new ArgumentException(nameof(id));
            if (Id == 0)
                Id = id;
            else throw new InvalidOperationException();
        }
    }
}
