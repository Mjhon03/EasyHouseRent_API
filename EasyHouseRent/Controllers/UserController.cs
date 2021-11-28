using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;

namespace EasyHouseRent.Controllers
{
    public class UserController : Controller
    {

        BaseData db = new BaseData();
        private string result;

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }


        //Mostrar todos los clientes de la base de datos
        //public IEnumerable<Usuarios> AllUsers()
        //{{-

        //    string sql = "SELECT * FROM usuarios";
        //    DataTable dt = db.getTable(sql);
        //    List<Usuarios> usersList = new List<Usuarios>();
        //    usersList = (from DataRow dr in dt.Rows
        //                 select new Usuarios()
        //                 {
        //                     idUsuarios = Convert.ToInt32(dr["idUsuarios"]),
        //                     nombre = dr["nombre"].ToString(),
        //                     apellidos = dr["apellidos"].ToString(),
        //                     fechaNacimiento = dr["fechaNacimiento"].ToString(),
        //                     telefono = Convert.ToInt32(dr["telefono"]),
        //                     email = dr["email"].ToString(),
        //                     contraseña = dr["contraseña"].ToString(),
        //                     estado = dr["estado"].ToString(),
        //                     idDepartamento = Convert.ToInt32(dr["iddepartamento"])

        //                 }).ToList();

        //    return usersList;
        //}

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //INGRESAR CLIENTES A LA BASE DE DATOS

        public string ingresarDepartamento([FromBody] departamento model)
        {
            string sql = "insert into departamento ( iddepartamento,nombre) values(" + model.iddepartamento + ",'" + model.nombre + ");";

            string result = db.executeSql(sql);

            return result;   
        }

        public string IngresarCliente([FromBody] usuarios userr)
        {
            string sql = "insert into usuarios (nombre,apellidos,fechaNacimiento,telefono,email,contraseña,estado) values('" + userr.nombre + "','" + userr.apellidos + "'," + userr.fechaNacimiento + "," + userr.telefono + ",'" + userr.email + "','" + userr.contraseña + "','" + userr.estado + ");";

            sql += "select @@identity as identity as ID" + Environment.NewLine;
            string result = db.executeSql(sql);

            return result;
        
        }
    }
}
