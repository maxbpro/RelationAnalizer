using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Base
{
    class Analizer
    {
        private DataTable dTable = null;
        //"массив" для нахождения ФЗ
        private List<List<String>> Ar = null;
        private int rowNum = -1;
        private int columnNum = -1;

        public Analizer(DataTable dTable)
        {
            this.dTable = dTable;
            Ar = new List<List<string>>();
            for (int i = 0; i < dTable.Columns.Count; i++)
            {
                List<String> column = new List<string>();
                for (int j = 0; j < dTable.Rows.Count; j++)
                {
                    column.Add(dTable.Rows[j][i].ToString());
                }
                Ar.Add(column);
            }
            rowNum = Ar[0].Count;
            columnNum = dTable.Columns.Count;
        }

        #region Проверка на вторую форму
        public bool IsTwoForm(List<int> keys)
        {
            bool flag = true;
            List<string> keysName = new List<string>();
            for (int j = 0; j < keys.Count; j++)
            {
                keysName.Add(dTable.Columns[keys[j]].ToString());
            }

            for (int i = 0; i < columnNum; i++)
            {
   
                Queue<int> result = ComparePrimaryWithColumn(keys, i);
                if (result != null)
                {
                    while (result.Count != 0)
                    {
                        int currentKey = result.Dequeue();
                        winReplace win = new winReplace(keysName, dTable.Columns[i].ColumnName, dTable.Columns[currentKey].ColumnName);
                        win.ShowDialog();
                        flag = false;
                    }
                }


                
            }
            if (flag)
                return true;
            else
                return false;
        }

        // возвращает индекс ключа, от которого зависит столбец (который выносим в новое отношение с этим ключом)
        // в случае неполной зависимости от составного ключа
        private Queue<int> ComparePrimaryWithColumn(List<int> keys, int indexY)
        {
            if (keys.Contains(indexY))
                return null;
            List<int> list = new List<int>();
            // Находим независимость
            for (int i = 0; i < keys.Count; i++)
            {
                if (!IsFunctialDepended(keys[i], indexY))
                    list.Add(i);
            }
            if (list.Count == 0)
                return null;
            else
            {
                // Находим зависимые
                Queue<int> result = new Queue<int>();
                for (int i = 0; i < keys.Count; i++)
                {
                    if (!list.Contains(keys[i]))
                        result.Enqueue(keys[i]);
                }
                return result;
            }
        }

        #endregion

        #region Проверка на третью форму
        // Key is simple
        public bool IsThreeForm(int indexPrimaryKey)
        {
            bool flag = true;

            for (int i = 0; i < columnNum; i++)
            {
                if (i == indexPrimaryKey)
                    continue;

                for (int j = 0; j < columnNum; j++)
                {
                    if (j != i && j != indexPrimaryKey) // пропускаем сравнение с самим собой и id
                    {
                        if (IsFunctialDepended(i, j))
                        {
                            flag = false;
                            winReplace win = new winReplace(dTable.Columns[indexPrimaryKey].ColumnName,
                                dTable.Columns[i].ColumnName, dTable.Columns[j].ColumnName);
                            win.ShowDialog();
                        }
                    }
                }
            }
            if (flag)
                return true;
            else
                return false;
        }
        //Key is complex
        public bool IsThreeForm(List<int> keys)
        {
            bool flag = true;
            List<string> keysName = new List<string>();
            for (int j = 0; j < keys.Count; j++)
            {
                keysName.Add(dTable.Columns[keys[j]].ToString());
            }
            for (int i = 0; i < columnNum; i++)
            {
                if(keys.Contains(i))
                    continue;

                for (int j = 0; j < columnNum; j++)
                {
                    if (j != i && !keys.Contains(j)) // пропускаем сравнение с самим собой и частями составного ключа
                    {
                        if (IsFunctialDepended(i, j))
                        {
                            flag = false;
                            winReplace win = new winReplace(keysName,
                                dTable.Columns[i].ColumnName, dTable.Columns[j].ColumnName, null);
                            win.ShowDialog();
                        }
                    }
                }
            }
            if (flag)
                return true;
            else
                return false;
        }
        #endregion

        #region Проверка на НФ Бойса-кодда
        public bool IsBoiseForm(int key1, int key2, int keyTotal)
        {
            bool flag = true;
            if (IsFunctialDepended(key1, key2))
            {
                flag = false;
                winReplace win = new winReplace(dTable.Columns[keyTotal].ColumnName,
                    dTable.Columns[key1].ColumnName, dTable.Columns[key2].ColumnName, null);
                win.ShowDialog();
            }
            if (IsFunctialDepended(key2, key1))
            {
                flag = false;
                winReplace win = new winReplace(dTable.Columns[keyTotal].ColumnName,
                    dTable.Columns[key2].ColumnName, dTable.Columns[key1].ColumnName, null);
                win.ShowDialog();
            }

            return flag;
        }

        #endregion

        private bool IsFunctialDepended(int indexX, int indexY)
        {
            int counter = 0;
            for (int i = 0; i < rowNum; i++)
            {
                string X = Ar[indexX][i];
                bool Has = false;
                for (int j = 0; j < rowNum; j++)
                {
                    if (i!=j && Ar[indexX][j] == X)
                        Has = true;
                }

                if (Has)
                {
                    string Y = Ar[indexY][i];
                    for (int j = 0; j < rowNum; j++)
                    {
                        if (Ar[indexX][j] == X && Ar[indexY][j] != Y)
                            return false;
                    }
                }
                else
                    counter++;
            }

            if (counter == rowNum)
                return false;
            else
                return true;
        }
    }
}
