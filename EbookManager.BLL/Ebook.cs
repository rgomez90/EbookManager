using System;
using System.IO;
using System.Windows.Controls;

namespace EbookManager
{
    class Ebook
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Resume { get; set; }
        public string Author { get; set; }
        public string Editorial { get; set; }
        public int Edition { get; set; }
        public string Isbn { get; set; }
        public Image Cover { get; set; }
        public FileInfo FilePath { get; set; }
    }
}
