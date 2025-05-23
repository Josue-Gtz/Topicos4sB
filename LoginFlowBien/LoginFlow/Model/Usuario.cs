using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LoginFlow.Model
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string? NombreUsuario { get; set; }

        public string? Contrasena { get; set; }

        public string? CorreoElectronico { get; set; }

        public bool Activo { get; set; }
    }
}
