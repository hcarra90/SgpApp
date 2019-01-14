using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Functions
{
    public static class Utilities
    {
        ///<summary>
        ///Calcula el total de páginas
        ///</summary>
        ///<param name="numberOfRecords"></param>
        ///<param name="pageSize"></param>
        ///<returns></returns>
        public static int CalculaTotalPaginas(long numberOfRecords, Int32 pageSize)
        {
            long result;
            int totalPages;

            Math.DivRem(numberOfRecords, pageSize, out result);
            if (result > 0)
            {
                totalPages = (int)((numberOfRecords / pageSize)) + 1;
            }
            else
            {
                totalPages = (int)((numberOfRecords / pageSize));
            }

            return totalPages;
        }

        ///<summary>
        ///Genera número al azar
        ///</summary>
        ///<returns></returns>
        public static int GeneraNumeroAzar(int max)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(max);
            return randomNumber;
        }

        ///<summary>
        ///Fold first letter of every word to uppercase
        ///</summary>
        ///<param name="s"></param>
        ///<returns></returns>
        public static string UppercaseFirstLetter(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder();
            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                char[] a = word.ToCharArray();
                a[0] = char.ToUpper(a[0]);
                string b = new string(a);
                output.Append(b + " ");
            }

            return output.ToString().Trim();
        }

    }
}
