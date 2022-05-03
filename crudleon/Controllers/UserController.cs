using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudleon.Models.Entity.Prime;
using crudleon.Models.TableViewModels;

namespace crudleon.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> list = null;
            using(primeEntitiesDB db = new primeEntitiesDB())
            {
                list = (from u in db.users
                        where u.idState == 1
                        orderby u.email
                        select new UserTableViewModel // Aqui podemos ver que el 'select n' es como el return
                        // aqui le estamos diciendo que regrese un objeto User (y le pasamos la info)
                        // y cada elemento del list contiene un obj User
                        {
                            Email = u.email,
                            Id = u.id,
                            Edad = u.edad
                        }).ToList();
            }
            return View(list);
        }
    }
}