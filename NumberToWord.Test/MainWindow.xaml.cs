using System;
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

namespace NumberToWord.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controls.MainTest_InterfaceCtrl InterfaceCtrl;
        public MainWindow()
        {
            InitializeComponent();
            this.InterfaceCtrl = new Controls.MainTest_InterfaceCtrl();
            this.DataContext = InterfaceCtrl;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InterfaceCtrl.Number = (sender as TextBox).Text;
        }

        private void EnglishPrefix_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InterfaceCtrl.EnglishPrefix = (sender as TextBox).Text;
        }
        private void EnglishSuffix_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InterfaceCtrl.EnglishSuffix = (sender as TextBox).Text;
        }
    }
}
