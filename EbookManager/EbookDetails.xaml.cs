using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EbookManager.BLL;

namespace EbookManager
{
    /// <summary>
    /// Interaction logic for EbookDetails.xaml
    /// </summary>
    public partial class EbookDetails : Window
    {
        public EbookDetails(Ebook ebook)
        {
            InitializeComponent();
            var ebookViewSource = (Ebook)FindResource("ebookViewSource");
            ebookViewSource = ebook;
            Image.Source= new BitmapImage(new Uri(Path.Combine(FilePaths.EbookDataDirectory, ebook.Id.ToString(),"cover.png"))).Clone();
        }
    }
}
