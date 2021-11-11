using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.modelos
{
    public class usuario
    {
        string cedula;
        string nombre;
        int edad;
     

        public usuario(string cedula, string nombre, int edad)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
        }

        public String ingresarU(Conexion conectar)
        {
            try
            {
                conectar.conectarbd();
                String sql = "INSERT INTO usuarios VALUES ('" + this.cedula + "','" + this.nombre + "'," + this.edad + ")";
                new NpgsqlCommand(sql,conectar.getcone()).ExecuteNonQuery();
                return "Datos Guardados :)";
            }
            catch (Exception E)
            {
                return "Error, verificar(si es llave duplicada,o si problemas en el campo edad, o verificar la arquitectura)" + E;
            }



        }

        public String eliminarU(Conexion conectar)
        {
            try
            {
                conectar.conectarbd();
                String sql = "delete from usuarios where cedula= '" + this.cedula + "';";
                new NpgsqlCommand(sql, conectar.getcone()).ExecuteNonQuery();
                return "Datos Eliminados :(";
            }
            catch (Exception E)
            {
                return "Error, verificar( o verificar la arquitectura)" + E;
            }



        }
    }
}
