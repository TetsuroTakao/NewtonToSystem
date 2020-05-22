using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Web;

// The Blank Window item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewtonToSystem
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        Facade dataAccessLayer = new Facade();
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void SystemButtonClick(object sender, RoutedEventArgs e)
        {
            FormattedText.Text = dataAccessLayer.GetCard(false);
            JsonText.Text = dataAccessLayer.OriginalJSON;
            QurryAPIUrl.Text = dataAccessLayer.QurryAPIUrl;
        }

        private void NewtonButtonClick(object sender, RoutedEventArgs e) 
        {
            FormattedText.Text = dataAccessLayer.GetCard(true);
            JsonText.Text = dataAccessLayer.OriginalJSON;
            QurryAPIUrl.Text = dataAccessLayer.QurryAPIUrl;
        }
    }
}
