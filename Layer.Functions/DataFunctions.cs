using System.Web;

namespace Layer.Functions
{
    public static class DataFunctions
    { 
        public static string PreparaStringPeso(string cadena,int tipo)
        {
            string peso = "";
            string caracter = "";
            long number1 = 0;
            bool canConvert = false;

            if (cadena == "\u001d" || cadena == "\u001d+" || cadena == "*\u001d+" || cadena == "*\u001d")
            {
                cadena = "";
                return cadena;
            }

            if (cadena.Length > 1)
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    caracter = cadena.Substring(i, 1);

                    canConvert = long.TryParse(caracter, out number1);
                    if ((canConvert == true || caracter =="," || caracter==".") && tipo == 2)
                    {
                        peso += caracter;
                    }
                    else if (canConvert == true && tipo ==1)
                    {
                        peso += caracter;
                    }
                        
                }

                if (tipo == 1)
                {
                    peso = decimal.Parse(peso).ToString();
                }
                else if (tipo ==2)
                {
                    peso = peso.Replace('.', ',');
                }
                
            }

            return peso;
        }
    }
}
