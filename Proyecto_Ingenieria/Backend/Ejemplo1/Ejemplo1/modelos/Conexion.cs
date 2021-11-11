using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
namespace Ejemplo1.modelos
{
    public class Conexion
    {
        NpgsqlConnection cone;
        public void conectarbd()
        {
            this.cone = new NpgsqlConnection("Server= 127.0.0.1;User Id=grupojueves;Password=1111;Database=bdnoche ");
            this.cone.Open();
        }
        public NpgsqlConnection getcone()
        {
            return cone;
        }
    }
}
