using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Xceed.Wpf.Toolkit;

namespace Orlik
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            // nie dziala mi do konca to gowno
            //var context = new CodeFirstDemoEntities();
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            //this.dataList.ItemsSource = context.ORLIK_DATABASE1.ToList();  
            // trzeba dodac przycisk search
            // trzeba ogarnac pole na wyswietlanie sie wolnych propozycji

            
            
        }

        
    }
}
