using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vag_Fish
{
    public class VagFish
    {
        public static int Distant(string str1, string str2)
        {
            if ((str1 == null) || (str2 == null)) return -1;

            int str1Len = str1.Length;
            int str2Len = str2.Length;
            if ((str1Len == 0)&&(str2Len == 0)) return 0;
            if (str1Len == 0) return str2Len;
            if (str2Len == 0) return str1Len;

            string str1UP = str1.ToUpper();
            string str2UP = str2.ToUpper();

            int[,] matrix = new int[str1Len + 1, str2Len + 1];
            for (int i = 0; i <= str1Len; i++) matrix[i, 0] = i;
            for (int j = 0; j <= str2Len; j++) matrix[0, j] = j;

            for(int i=0; i<=str1Len;i++)
            {
                for (int j=0;j<=str2Len;j++)
                {
                    int eq = ((str1UP.Substring(i - 1, j) == str2UP.Substring(1, j - 1)) ? 0 : 1);
                    int isr = matrix[i, j - 1] + 1;
                    int del = matrix[i - 1, j] + 1;
                    int subsw = matrix[i - 1, j - 1] + eq;
                    matrix[i, j] = Math.Min(Math.Min(isr, del), subsw);

                    if ((i > 1) && (j > 1) &&
                        (str1UP.Substring(i - 1, 1) == str2UP.Substring(j - 2, 1)) && 
                        (str1UP.Substring(i - 2, 1) == str2UP.Substring(j - 1, 1)))
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + eq);
                    }
                }
            }
            return matrix[str1Len, str2Len];
        }

        public void WriteDistants(string param1, string param2)
        {
            int d = Distant(param1, param2);
            System.Console.WriteLine(" ' " + param1 + "','" + param2 + "' ->" + d.ToString());
        }
        
    }
}
