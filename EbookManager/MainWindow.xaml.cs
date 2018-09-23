using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using EbookManager.BLL;
using MessageBox = System.Windows.Forms.MessageBox;

namespace EbookManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private CollectionViewSource _ebookViewSource;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ebookViewSource = (CollectionViewSource)(this.FindResource("ebookViewSource"));
            _ebookViewSource.Source = EbookManagerInitializer.Ebooks;
            EbookManagerInitializer.Ebooks.CollectionChanged += Ebooks_CollectionChanged;
            SetButtonState();
        }

        private void Ebooks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SetButtonState();
        }

        private void SetButtonState()
        {
            var state = EbookManagerInitializer.Ebooks.Any();
            BtnDelete.IsEnabled = state;
            BtnDetails.IsEnabled = state;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddWindow { DataContext = new Ebook() };
            window.ShowDialog();
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Dou you really want to delete the ebook?", "Delete Ebook", MessageBoxButtons.YesNo);
            if (res != System.Windows.Forms.DialogResult.Yes) return;
            Ebook selectedEbook = (Ebook)ebookListView.SelectedItem;
            var service = new EbookService();
            service.DeleteEbook(selectedEbook.Id);
        }

        private void BtnDetails_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedEbook = (Ebook)ebookListView.SelectedItem;
            if (selectedEbook == null)
            {
                MessageBox.Show("No ebook selected!");
                return;
            }
            var win = new EbookDetails(selectedEbook);
            win.ShowDialog();
        }
    }
}
