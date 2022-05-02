using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudleon.Models.Entity.Prime;

namespace crudleon.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                // primeEntitiesDB es el nombre que se configuro en el asistente
                // de entity framework: 
                // EDMPrime es el Nombre del Entity Data Model
                // primeModelDB es el nombre que le pusimos a como se guarda esta variable en el WebConfig (esto se configuro en el instalador)
                // primeModel es el nombre que le pusimos al modelNamespace que nos pidio el asistente, pero no se en donde se usa
                using (primeEntitiesDB db = new primeEntitiesDB())
                {
                    // 'u' es un alias, por lo que puede ser cualquier cosa
                    // al final el 'select u' es como el 'select *' de sql y se tiene que poner si o si
                    var lst = from u in db.users where
                              u.email == user && 
                              u.password == password && 
                              u.idState == 1 
                              select u;

                    if (lst.Count() > 0)
                    {
                        // Hicimos un Entity Data Model, por cada tabla se crea un Entity, teniamos
                        // una tabla que se llamaba user, por eso se creo el entity user que esta en
                        // crudleon.Models.Entity.Prime
                        user oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido :c");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :c " + ex.Message);
            }
        }
    }
}