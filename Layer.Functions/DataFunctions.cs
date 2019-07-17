using Layer.Entity.Dto;
using System.Collections.Generic;
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

        public static List<ListaComboDto> GetTipoReserva()
        {
            List<ListaComboDto> lista = new List<ListaComboDto>();
            lista.Add(new ListaComboDto { Valor = 0, Nombre = "" });
            lista.Add(new ListaComboDto { Valor = 1, Nombre = "Aéreo" });
            lista.Add(new ListaComboDto { Valor = 2, Nombre = "Marítimo" });
            return lista;
        }

        public static List<ListaComboDto> GetCantidad()
        {
            List<ListaComboDto> lista = new List<ListaComboDto>
            {
                new ListaComboDto { Valor = 0, Nombre = "" }
            };

            for (int i = 1; i < 101; i++)
            {
                lista.Add(new ListaComboDto { Valor = i, Nombre = i.ToString() });
            }
            
            return lista;
        }

        public static List<ListaComboDto> GetTipoSag()
        {
            List<ListaComboDto> lista = new List<ListaComboDto>();
            lista.Add(new ListaComboDto { Valor = 0, Nombre = "" });
            lista.Add(new ListaComboDto { Valor = 1, Nombre = "CRD" });
            lista.Add(new ListaComboDto { Valor = 2, Nombre = "CVN" });
            lista.Add(new ListaComboDto { Valor = 3, Nombre = "SRD" });
            return lista;
        }

        public static List<ListaComboDto> GetTipoEnvase()
        {
            List<ListaComboDto> lista = new List<ListaComboDto>();
            lista.Add(new ListaComboDto { Valor = 0, Nombre = "" });
            lista.Add(new ListaComboDto { Valor = 1, Nombre = "PALLET" });
            lista.Add(new ListaComboDto { Valor = 2, Nombre = "JUMBO" });
            return lista;
        }
    }
}
