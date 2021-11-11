using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;//libreria cor
using System.Text.Json;
using Ejemplo1.modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejemplo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//libreria cors
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public String Get()
        {
            return "Estoy utillizando get llegaste al back";
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public String Post( JsonElement carrito)
        {
            String cedula = carrito.GetProperty("cedula").ToString();
            String nombre = carrito.GetProperty("nombre").ToString();
            int edad = carrito.GetProperty("edad").GetInt32();

            Conexion conectar = new Conexion();
            //conectar.conectarbd();

            usuario u = new usuario(cedula, nombre, edad);
            String memsaje=u.ingresarU(conectar);
            return memsaje;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{cedula}")]
        public String Put(String cedula, [FromBody] JsonElement carrito)
        {
            String cedula1 = cedula;
            String nombre = carrito.GetProperty("nom").ToString();
            int edad = carrito.GetProperty("edad").GetInt32();
            return "Hiciste una llamdo al metodo put "+ cedula1;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{ced}")]
        public String Delete(string ced)
        {
            Conexion conectar = new Conexion();
            usuario u = new usuario(ced,"", 0);
            String memsaje = u.eliminarU(conectar);
            return memsaje;
            
        }
    }
}
