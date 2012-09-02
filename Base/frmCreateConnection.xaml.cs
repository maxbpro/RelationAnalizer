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
using System.ComponentModel;

namespace Base
{
 
    public partial class frmCreateConnection : Window
    {
        private DataTable table = null;
        private List<string> items_bases = null;
        private List<string> items_tables = null;
        private BackgroundWorker back_bases_read = null;
        private BackgroundWorker back_tables_read = null;
        private string connection_string = null;
        private string base_name = "";
        
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

       
     
        private void btnCreateConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM " + cmbTableName.Text, getCurrentConnectionString());
                adapter.Fill(table);
                TableInfoSingleton.getInstance().DataBaseName = base_name;
                TableInfoSingleton.getInstance().TableName = cmbTableName.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Попытка подключиться завершилась неудачей " + ex.Message, "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAcceptServer_Click(object out_sender, RoutedEventArgs out_e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(getCurrentConnectionString());
                connection.Open();
                MessageBox.Show("Подключение успешно выполняется", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                connection.Close();

                back_bases_read = new BackgroundWorker();
                back_bases_read.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    string query = "SELECT name FROM sys.databases WHERE database_id > 4";
                    DataTable tables_list = new DataTable("Dbs");

                    using (SqlConnection con = new SqlConnection(connection_string))
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        adapter.Fill(tables_list);
                        con.Close();
                    }

                    items_bases = new List<string>();
                    for (int i = 0; i < tables_list.Rows.Count; i++)
                    {
                        items_bases.Add(tables_list.Rows[i][0].ToString());
                    }
                };
                back_bases_read.RunWorkerCompleted += InitItemsSourceBasesCompleted;
                txt_loading.Text = "Загрузка...";
                base_name = cmbBDName.Text;
                connection_string = getCurrentConnectionString();
                back_bases_read.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Попытка подключиться завершилась неудачей " + ex.Message, "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        void InitItemsSourceBasesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbBDName.ItemsSource = items_bases;
            txt_loading.Text = null;
        }

        void InitItemsSourceTablesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbTableName.ItemsSource = items_tables;
            txt_loading.Text = null;
        }


        private void cmbBDName_SelectionChanged(object out_sender, SelectionChangedEventArgs out_e)
        {
            try
            {
                back_tables_read = new BackgroundWorker();
                base_name = out_e.AddedItems[0].ToString();
                back_tables_read.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    using (SqlConnection con = new SqlConnection(connection_string))
                    {
                        items_tables = getListTables(con);
                    }
                };
                back_tables_read.RunWorkerCompleted += InitItemsSourceTablesCompleted;
                txt_loading.Text = "Загрузка таблиц...";
                connection_string = getCurrentConnectionString();
                back_tables_read.RunWorkerAsync();                
            }
            catch (Exception ex)
            {
                // sorry...
            }
        }

        public List<string> getListTables(SqlConnection _connection)
        {
            _connection.Open();
            List<string> tables = new List<string>();
            DataTable dt = _connection.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            _connection.Close();
            return tables;
        }


        public DataSet getDBStruct(string DBname, string connection_string)
        {
            if (DBname != null && DBname != "")
            {
                DataSet respond = new DataSet(DBname);

                try
                {
                    string query = string.Format("USE {0};", DBname);
                    query += "select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'BASE TABLE' and TABLE_NAME != 'sysdiagrams'";
                    DataTable tables = new DataTable();

                    using (SqlConnection con = new SqlConnection(connection_string))
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        adapter.Fill(tables);
                        con.Close();
                    }

                    query = string.Format("USE {0};", DBname);

                    foreach (DataRow row in tables.Rows)
                    {
                        query += string.Format("select TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH, CHARACTER_SET_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{0}'; ", row["TABLE_NAME"]);
                    }

                    using (SqlConnection con = new SqlConnection(connection_string))
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        adapter.Fill(respond);
                        con.Close();
                    }
                    return respond;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        private string getCurrentConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = cmbDataSource.Text;
            builder.InitialCatalog = base_name;
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
                
            return builder.ConnectionString;
        }
     
    }
}
