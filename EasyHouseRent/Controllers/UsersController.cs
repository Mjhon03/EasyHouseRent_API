using EasyHouseRent.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Controllers
{
    public class UsersController : Controller
    {
        BaseData db = new BaseData();

        // GET: ClientController
        public ActionResult Index()
        {
            return View();
        }


        //Mostrar todos los clientes de la base de datos
        public IEnumerable<Users> AllUsers()
        {
            string sql = "SELECT idUsuarios,nombre,apellidos,fechaNacimiento,telefono,email,estado,iddepartamento FROM usuarios";
            DataTable dt = db.getTable(sql);
            List<Users> usersList = new List<Users>();
            usersList = (from DataRow dr in dt.Rows
                          select new Users()
                          {
                              idUsuarios = Convert.ToInt32(dr["idUsuarios"]),
                              nombres = dr["nombre"].ToString(),
                              apellidos = dr["apellidos"].ToString(),
                              fecNacimiento = dr["fechaNacimiento"].ToString(),
                              telefono = Convert.ToInt32(dr["telefono"]),
                              email = dr["email"].ToString(),
                              //contraseña = dr["contraseña"].ToString(),
                              estado = dr["estado"].ToString(),
                              iddepartamento = Convert.ToInt32(dr["iddepartamento"])

                          }).ToList();

            return usersList;
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
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

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
    }
}
