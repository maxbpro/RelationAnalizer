using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Base
{
    /// <summary>
    /// Interaction logic for Attention.xaml
    /// </summary>
    public partial class Attention : Window
    {
        public Attention(string text)
        {
            InitializeComponent();
            textblock1.Text = text;
        }


        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
