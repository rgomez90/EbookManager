using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using EbookManager.BLL;

namespace EbookManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IList<Ebook> Test;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Test =EbookManagerInitializer.Initizialize();
        }
    }
}
