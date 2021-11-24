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
    public class UsersController : Controller
    {
        BaseData db = new BaseData();

        // GET: ClientController
        public ActionResult Index()
        {
            return View();
        }


        //Mostrar todos los clientes de la base de datos
        public IEnumerable<Usuarios> AllUsers()
        {
            string sql = "SELECT * FROM usuarios";
            DataTable dt = db.getTable(sql);
            List<Usuarios> usersList = new List<Usuarios>();
            usersList = (from DataRow dr in dt.Rows
                          select new Usuarios()
                          {
                              idUsuarios = Convert.ToInt32(dr["idUsuarios"]),
                              nombre = dr["nombre"].ToString(),
                              apellidos = dr["apellidos"].ToString(),
                              fechaNacimiento = dr["fechaNacimiento"].ToString(),
                              telefono = Convert.ToInt32(dr["telefono"]),
                              email = dr["email"].ToString(),
                              contraseña = dr["contraseña"].ToString(),
                              estado = dr["estado"].ToString(),
                              idDepartamento = Convert.ToInt32(dr["iddepartamento"])

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
