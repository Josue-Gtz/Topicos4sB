using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Practica_5_arreglado.Model;
namespace Practica_5_arreglado.ViewModel
{
    internal class ContactoMostrador
    {
         public static ObservableCollection<Contacto> Contactos { get; } = new ObservableCollection<Contacto>();
        
    }
}
