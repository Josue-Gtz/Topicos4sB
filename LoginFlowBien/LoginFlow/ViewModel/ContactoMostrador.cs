using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginFlow.Model;

namespace LoginFlow.ViewModel
{
    public class ContactoMostrador
    {
        public static ObservableCollection<Contacto> Contactos { get; } = new ObservableCollection<Contacto>();

    }
}
