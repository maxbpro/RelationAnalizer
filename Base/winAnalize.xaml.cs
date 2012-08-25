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
using System.Data;

namespace Base
{
 
    public partial class winAnalize : Window
    {
        private Analizer analizer = null;

        public winAnalize(DataTable table)
        {
            InitializeComponent();
            analizer = new Analizer(table);
        }

        #region Первая НФ

        private void chForm1_Click(object sender, RoutedEventArgs e)
        {
            if (chform1.IsChecked != true)
                txtform1.Content = "Не находится в 1 НФ";
            else
                txtform1.Content = "Находится в 1 НФ";
        }

        #endregion

        private void chform2_Click(object sender, RoutedEventArgs e)
        {
            if (chform2.IsChecked != true)
            {
                stForm2.IsEnabled = true;
                txtform2.Content = "Проверить?";
                txtform2.MouseLeftButtonDown += txtform2_MouseLeftButtonDown;
                txtform2.Cursor = Cursors.Hand;

                stThreeForm.IsEnabled = false;
                //txtform3.MouseLeftButtonDown -= txtform3_MouseLeftButtonDown;
                //txtform3.Cursor = Cursors.Arrow;
                //txtform3.Content = "";
            }
            else
            {
                stForm2.IsEnabled = false;
                txtform2.Content = "Находится во 2 НФ";
                txtform2.MouseLeftButtonDown -= txtform2_MouseLeftButtonDown;
                txtform2.Cursor = Cursors.Arrow;

                stThreeForm.IsEnabled = true;
                txtform3.MouseLeftButtonDown += txtform3_MouseLeftButtonDown;
                txtform3.Cursor = Cursors.Hand;
                txtform3.Content = "Проверить?";
            }
        }

        #region Вторая НФ

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            if(!list.Items.Contains(cmbIndex.Text) && cmbIndex.Text!="")
               list.Items.Add(cmbIndex.Text);
        }

        private void txtform2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (list.Items.Count >= 2)
            {               
                List<int> listInt = new List<int>();
                for (int i = 0; i < list.Items.Count; i++)
                    listInt.Add(int.Parse(list.Items[i].ToString()));

                if (analizer.IsTwoForm(listInt))
                    txtform2.Content = "Находится во 2 НФ";
                else
                    txtform2.Content = "Не находится во 2 НФ";
            }
            else
            {
                txtform2.Content = "Ключ неверный!";
            }
        }
        #endregion

        #region Третья НФ

        private void txtform3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (stThreeForm.IsEnabled)
            {
                int indexPrimaryKey = 0;
                if (int.TryParse(cmbIndexPrimaryKey.Text, out indexPrimaryKey))
                {
                    if (analizer.IsThreeForm(indexPrimaryKey))
                        txtform3.Content = "Находится в 3 НФ";
                    else
                        txtform3.Content = "Не находится в 3 НФ";
                }
                else
                    txtform3.Content = "Ключ неверный!";
            }
            else
            {
                if (list.Items.Count >= 2)
                {
                    List<int> listInt = new List<int>();
                    for (int i = 0; i < list.Items.Count; i++)
                        listInt.Add(int.Parse(list.Items[i].ToString()));
                    if (analizer.IsThreeForm(listInt))
                        txtform3.Content = "Находится в 3 НФ";
                    else
                        txtform3.Content = "Не находится в 3 НФ";
                }
                else
                    txtform3.Content = "Ключ неверный!";
            }
        }

        #endregion

        #region НФ Бойса-Кодда
        private void chform4_Click(object sender, RoutedEventArgs e)
        {
            if (chform4.IsChecked == true)
            {
                stForBoise.IsEnabled = true;
                txtform4.Content = "Проверить?";
                txtform4.Cursor = Cursors.Hand;
                txtform4.MouseLeftButtonDown += txtform4_MouseLeftButtonDown;
            }
            else
            {
                stForBoise.IsEnabled = false;
                txtform4.Content = "Находится в НФ Бойса-Кодда";
                txtform4.Cursor = Cursors.Arrow;
                txtform4.MouseLeftButtonDown -= txtform4_MouseLeftButtonDown;
            }
        }

  

        private void btnAddToListForOne_Click(object sender, RoutedEventArgs e)
        {
            listOneFOreBoise.Items.Add(cmbIndexOneKey.Text);
        }

        private void btnAddToListForTwo_Click(object sender, RoutedEventArgs e)
        {
            listTwoFOreBoise.Items.Add(cmbIndexTwoKey.Text);
        }

        private void txtform4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<int> key1 = new List<int>();
            List<int> key2 = new List<int>();
            for (int i = 0; i < listOneFOreBoise.Items.Count; i++)
                key1.Add(int.Parse(listOneFOreBoise.Items[i].ToString()));
            for (int i = 0; i < listTwoFOreBoise.Items.Count; i++)
                key2.Add(int.Parse(listTwoFOreBoise.Items[i].ToString()));
            if (key1.Count == 2 && key2.Count == 2)
            {
                if (key1[0]==key2[0])
                {
                    if (analizer.IsBoiseForm(key1[1], key2[1], key1[0]))
                        txtform4.Content = "Находится в НФ Бойса-Кодда";
                    else
                        txtform4.Content = " Не находится в НФ Бойса-Кодда";
                }
                else
                {
                    if (key1[0] == key2[1])
                    {
                        if (analizer.IsBoiseForm(key1[1], key2[0], key2[1]))
                            txtform4.Content = "Находится в НФ Бойса-Кодда";
                        else
                            txtform4.Content = " Не находится в НФ Бойса-Кодда";
                    }
                    else
                    {
                        if (key1[1] == key2[0])
                        {
                            if (analizer.IsBoiseForm(key1[0], key2[1], key2[0]))
                                txtform4.Content = "Находится в НФ Бойса-Кодда";
                            else
                                txtform4.Content = " Не находится в НФ Бойса-Кодда";
                        }
                        else
                        {
                            if (key1[1] == key2[1])
                            {
                                if (analizer.IsBoiseForm(key1[0], key2[0], key2[1]))
                                    txtform4.Content = "Находится в НФ Бойса-Кодда";
                                else
                                    txtform4.Content = " Не находится в НФ Бойса-Кодда";
                            }
                            else
                                txtform4.Content = "Ключи неверные!";
                        }
                        
                    }

                        
                }
               
            }
            else
                txtform4.Content = "Ключи неверные!";
        }

        #endregion


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


    }
}
