using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;

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
                String sql = "delete from usuarios where cedula='" + this.cedula + "';";
                new NpgsqlCommand(sql, conectar.getcone()).ExecuteNonQuery();
                return "Datos Eliminados :(" + sql;
            }
            catch (Exception E)
            {
                return "Error, verificar( o verificar la arquitectura)" + E;
            }

        }

        public String buscar(Conexion conectar)
        {
            String Mensaje = "";
            try
            {
                String sql = "select * from usuarios where cedula='" + this.cedula + "';";
                var reader = new NpgsqlCommand(sql, conectar.getcone()).ExecuteReader();
                while (reader.Read())
                {
                    this.cedula = reader.GetString(1);
                    this.nombre = reader.GetString(2);
                    this.edad = reader.GetInt32(3);
                }
                var Json = JsonConvert.SerializeObject(new { ced = this.cedula, nombre = this.nombre, edad = this.edad });
                reader.Close();
                return Json;
            }
            catch (Exception E)
            {
                Mensaje = "Error" + E;
            }
            return Mensaje;
        }


        public String listar(Conexion conectar)
        {

            String Mensaje = "";
            try
            {
                conectar.conectarbd();
                NpgsqlCommand cmd = new NpgsqlCommand();

                String sql = "select * from usuarios ";
                if (this.cedula != "")
                    sql = "select * from usuarios where cedula='" + this.cedula + "';";


                var reader = new NpgsqlCommand(sql, conectar.getcone()).ExecuteReader();
                var todoslosusers = new List<dynamic>();

                while (reader.Read())
                {
                    dynamic usuarios = new ExpandoObject();

                    usuarios.cedula = reader.GetString(0);
                    usuarios.nombre = reader.GetString(1);
                    usuarios.edad = reader.GetInt32(2);

                    todoslosusers.Add(usuarios);

                }
                string Json = JsonConvert.SerializeObject(todoslosusers);
                reader.Close();
                return Json;

            }
            catch (Exception E)
            {
                Mensaje = "Error" + E;
            }
            return Mensaje;

        }



    }
}
