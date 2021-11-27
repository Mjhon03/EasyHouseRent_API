using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Controllers
{
    public class UsersController : ControllerBase
    {
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
                                //fechaNacimiento = dr["fechaNacimiento"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                email = dr["email"].ToString(),
                                contraseña = dr["contraseña"].ToString(),
                                estado = dr["estado"].ToString(),

                            }).ToList();

            return usersList;
        }
    }
        
}
