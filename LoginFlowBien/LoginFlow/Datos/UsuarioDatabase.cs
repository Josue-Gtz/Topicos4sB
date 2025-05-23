using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginFlow.Model;
using SQLite;

namespace LoginFlow.Datos
{
    internal class UsuarioDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public UsuarioDatabase()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "agenda.db3");
            _db = new SQLiteAsyncConnection(path);
            _db.CreateTableAsync<Usuario>().Wait();

            // Insertar usuario por defecto si es la primera vez
            //InicializarUsuarioPorDefecto().Wait();
        }

        private async Task InicializarUsuarioPorDefecto()
        {
            var usuarios = await _db.Table<Usuario>().ToListAsync();
            if (!usuarios.Any())
            {
                var admin = new Usuario
                {
                    NombreUsuario = "admin",
                    Contrasena = "admin123",
                    CorreoElectronico = "admin@agenda.com",
                    Activo = true
                };
                await _db.InsertAsync(admin);
            }

        }
        public Task<Usuario> ValidarUsuarioAsync(string usuario, string contrasena)
        {
            return _db.Table<Usuario>()
                     .Where(u => u.NombreUsuario == usuario && u.Contrasena == contrasena && u.Activo)
                     .FirstOrDefaultAsync();
        }

        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            if (usuario.Id != 0)
                return _db.UpdateAsync(usuario);
            else
                return _db.InsertAsync(usuario);
        }


        public Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return _db.Table<Usuario>().ToListAsync();
        }

        public Task<bool> UsuarioExisteAsync(string nombre)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.NombreUsuario == nombre)
                      .FirstOrDefaultAsync()
                      .ContinueWith(t => t.Result != null);
        }
        public Task<Usuario?> ObtenerUsuarioPorNombreAsync(string nombre)
        {
            return _db.Table<Usuario>()
              .Where(u => u.NombreUsuario == nombre)
              .FirstOrDefaultAsync();
        }
    }
}
