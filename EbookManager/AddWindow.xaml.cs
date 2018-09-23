using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EbookManager.BLL;
using Microsoft.Win32;
using Newtonsoft.Json;
using Image = System.Drawing.Image;

namespace EbookManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            EbookService = new EbookService();
        }

        private Ebook ebookViewSource;
        private EbookService EbookService;
        private string coverPath;
        private string ebookPath;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ebookViewSource = ((Ebook)(this.FindResource("Ebook")));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EbookService.RegisterEbook(ebookViewSource,coverPath,ebookPath);
            this.Close();
        }

        private void BtnEbook_OnClick(object sender, RoutedEventArgs e)
        {
            var dl = new OpenFileDialog();
            if (dl.ShowDialog()==true)
            {
                ebookPath= dl.FileName;
            }
        }

        private void BtnCover_OnClick(object sender, RoutedEventArgs e)
        {
            var dl = new OpenFileDialog();
            if (dl.ShowDialog() == true)
            {
                coverPath = dl.FileName;
                //var ima = Image.FromFile(dl.FileName);
                //var ms = new MemoryStream();
                //ima.Save(ms,ImageFormat.Png);
                //ebookViewSource.CoverImage = ms.ToArray();
            }
        }
    }
}
