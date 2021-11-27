using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        BaseData db = new BaseData(); 
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            string sql = "SELECT * FROM usuarios";
            DataTable dt = db.getTable(sql);
            List<Usuarios> usersList = new List<Usuarios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                             idusuario = Convert.ToInt32(dr["idUsuarios"]),
                             nombre = dr["nombre"].ToString(),
                             apellidos = dr["apellidos"].ToString(),
                             //fechaNacimiento = dr["fechaNacimiento"].ToString(),//jhon 
                             telefono = dr["telefono"].ToString(),
                             email = dr["email"].ToString(),
                             contraseña = dr["contraseña"].ToString(),
                             estado = dr["estado"].ToString(),
                             departamento = Convert.ToInt32(dr["iddepartamento"]),
                             municipio = Convert.ToInt32(dr["municipio"])

                         }).ToList();

            return usersList;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
