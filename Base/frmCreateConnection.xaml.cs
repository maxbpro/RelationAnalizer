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
using System.Data.SqlClient;
using System.Data;

namespace Base
{
 
    public partial class frmCreateConnection : Window
    {
        private DataTable table = null;

        public frmCreateConnection(DataTable table)
        {
            InitializeComponent();
            this.table = table;
            for (int i = 0; i < 300; i += 10)
            {
                cmbTimeWaitCon.Items.Add(i);
                cmbTimeWaitExecute.Items.Add(i);
            }
            cmbTimeWaitCon.SelectedIndex = 1;
            cmbTimeWaitExecute.SelectedIndex = 0;
            txtBD.Text = "testBD";
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

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = cmbDataSource.Text;
                builder.InitialCatalog = txtBD.Text;
                builder.Encrypt = (bool)chcIncript.IsChecked;
                builder.ConnectTimeout = int.Parse(cmbTimeWaitCon.Text);
                builder.LoadBalanceTimeout = int.Parse(cmbTimeWaitExecute.Text);
                builder.IntegratedSecurity = !(bool)chcIntegratedSecurity.IsChecked;
                if (chcIntegratedSecurity.IsChecked == true)
                {
                    builder.Password = password.Password;
                    builder.UserID = txtuser.Text;
                }
                builder.Pooling = false;
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                Attention attention = new Attention("Подключение успешно");
                attention.ShowDialog();
                connection.Close();
            }
            catch (Exception ex)
            {
                Attention attention = new Attention("Ошибка подключения " + ex.Message);
                attention.ShowDialog();
            }
        }

     
        private void btnCreateConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = cmbDataSource.Text;
                builder.InitialCatalog = txtBD.Text;
                builder.Encrypt = (bool)chcIncript.IsChecked;
                builder.ConnectTimeout = int.Parse(cmbTimeWaitCon.Text);
                builder.LoadBalanceTimeout = int.Parse(cmbTimeWaitExecute.Text);
                builder.IntegratedSecurity = !(bool)chcIntegratedSecurity.IsChecked;
                if (chcIntegratedSecurity.IsChecked == true)
                {
                    builder.Password = password.Password;
                    builder.UserID = txtuser.Text;
                }
                builder.Pooling = false;
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM " + TableName.Text, builder.ConnectionString);
                adapter.Fill(table);
                MainWindow.TableName = TableName.Text;
                MainWindow.BDName = txtBD.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                Attention attention = new Attention("Ошибка подключения " + ex.Message);
                attention.ShowDialog();
            }
        }

     
    }
}
