using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3con
{
    public class InputValor
    {
        
        public bool Numeros(string texto)
        {
            //regresa true si es numero
            return Regex.IsMatch(texto, @"^\d+$");


        }
        public bool Letras(string texto)
        {
            //regresa true si es negativo
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

    }


}
