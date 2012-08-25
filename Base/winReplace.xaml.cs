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
    /// Interaction logic for winReplace.xaml
    /// </summary>
    public partial class winReplace : Window
    {
        public winReplace(List<string> keys, string child, string keyParent)
        {
            InitializeComponent();
           // Первая таблица (с зависимой колонкой)
            DataGridTextColumn column = null;
            for(int i=0; i<keys.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = keys[i];
                dgridParent.Columns.Add(column);
            }
            column = new DataGridTextColumn();
            column.Header = child;
            dgridParent.Columns.Add(column);

            // Вторая таблица, ключи
            for(int i=0; i<keys.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = keys[i];
                dgridChild1.Columns.Add(column);
            }
            // Третья таблица, засимые ключ и столбец
            column = new DataGridTextColumn();
            column.Header = keyParent;
            dgridChild2.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = child;
            dgridChild2.Columns.Add(column);
        }

        public winReplace(string key,  string parent, string child)
        {
            InitializeComponent();
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = key;
            dgridParent.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = parent;
            dgridParent.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = child;
            dgridParent.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = key;
            dgridChild1.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = parent;
            dgridChild1.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = parent;
            dgridChild2.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = child;
            dgridChild2.Columns.Add(column);
        }

        public winReplace(string keyTotal, string Determ, string child, string f)
        {
            InitializeComponent();
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = Determ;
            dgridParent.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = child;
            dgridParent.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = keyTotal;
            dgridParent.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = keyTotal;
            dgridChild1.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = Determ;
            dgridChild1.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = Determ;
            dgridChild2.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = child;
            dgridChild2.Columns.Add(column);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                try
                {
                    BD.GlassHelper.ExtendGlassFrame(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникли сложности с включением эффекта Aero Glass. " + ex.Message);
                }
            }
            else
            {
                this.Background = Brushes.White;
            }

        }

        public winReplace(List<string> keys, string parent, string child, string mode2)
        {
            InitializeComponent();
            DataGridTextColumn column = new DataGridTextColumn();
            for (int i = 0; i < keys.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = keys[i];
                dgridParent.Columns.Add(column);
            }
            column = new DataGridTextColumn();
            column.Header = parent;
            dgridParent.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = child;
            dgridParent.Columns.Add(column);

            column = new DataGridTextColumn();
            for (int i = 0; i < keys.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = keys[i];
                dgridChild1.Columns.Add(column);
            }
            column = new DataGridTextColumn();
            column.Header = parent;
            dgridChild1.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = parent;
            dgridChild2.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = child;
            dgridChild2.Columns.Add(column);
        }

    }
}
