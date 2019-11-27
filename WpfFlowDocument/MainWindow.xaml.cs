using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace WpfFlowDocument
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string path = ConfigurationManager.AppSettings.Get("Path");
            string color = ConfigurationManager.AppSettings.Get("Color");
            myParagraphBody.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(color);

            using (FileStream fs=new FileStream(path, FileMode.Open))
            {
                using(StreamReader sr=new StreamReader(fs))
                {
                    string allText = sr.ReadToEnd();
                    myParagraphBody.Inlines.Add(allText);
                }
            }
        }
    }
}
