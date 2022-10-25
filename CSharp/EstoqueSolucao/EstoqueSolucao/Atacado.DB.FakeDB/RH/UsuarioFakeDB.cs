using Atacado.Dominio.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.RH
{
    public static class UsuarioFakeDB
    {
        private static List<Usuario> usuarios;

        public static List<Usuario> Usuarios
        {
            get 
            {
                if(usuarios == null)
                {
                    usuarios = new List<Usuario>();
                    Carregar();
                }
                return usuarios;
            }
        }
        private static void Carregar()
        {
            usuarios.Add(new Usuario(1, "Marlon_Vic", "2314", "User"));
            usuarios.Add(new Usuario(2, "Bruno_Ba", "0091", "User"));
            usuarios.Add(new Usuario(3, "Thiago_Mar", "5243", "User"));
            usuarios.Add(new Usuario(4, "Rafael_Ge", "4121", "User"));
            usuarios.Add(new Usuario(5, "Akira_Ino", "3654", "User"));
        }
    }
}
