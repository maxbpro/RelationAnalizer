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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;

namespace Base
{
    public partial class MainWindow : Window
    {
        private DataTable table = null;
        public static string BDName = null;
        public static string TableName = null;
       
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding binding = new CommandBinding(ApplicationCommands.Open);
            binding.Executed += new ExecutedRoutedEventHandler(Open_Command);
            this.CommandBindings.Add(binding);
            table = new DataTable();
            frmCreateConnection winConnection = new frmCreateConnection(table);
            winConnection.ShowDialog();
            mainDataGrid.ItemsSource = table.DefaultView;
            txtBDName.Text = TableInfoSingleton.getInstance().DataBaseName;
            txtTableName.Text = TableInfoSingleton.getInstance().TableName;
        }

        void Open_Command(object sender, ExecutedRoutedEventArgs e)
        {
            table = new DataTable();
            frmCreateConnection winConnection = new frmCreateConnection(table);
            winConnection.ShowDialog();
            mainDataGrid.ItemsSource = table.DefaultView;
            txtBDName.Text = BDName;
            txtTableName.Text = TableName;
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

        

        

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("Вы хотите выйти из программы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.No)
            {
                e.Cancel=true;
            }
           
        }


        private void StartAnalize_Click(object sender, RoutedEventArgs e)
        {
            winAnalize win = new winAnalize(table);
            win.ShowDialog();
        }

    

       

    }
}
