using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practica3con
{
    public class ValiRFC
    {

        //metodo que valida
        public bool EsRFCValido(string texto)
        {
            //mira si esta vacio
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }
            //define como es
            string rfc = @"^[A-Z]{4}\d{6}[A-Z0-9]{3}$";
            //regresa los valores si es que coinciden
            return Regex.IsMatch(texto, rfc);
        }
        //Corrige rfc
        public string CorregirRFC(string texto)
        {
            //mira si esta vacio

            if (string.IsNullOrWhiteSpace(texto))
            {
                return texto;
            }
            //las minusculas las hace mayusculas
            texto = texto.ToUpper();
            return texto;
        }
    }
}