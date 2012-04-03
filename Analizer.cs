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
