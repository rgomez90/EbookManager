﻿using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ebookViewSource = ((Ebook)(this.FindResource("Ebook")));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EbookService.RegisterEbook(ebookViewSource);
        }
    }
}
