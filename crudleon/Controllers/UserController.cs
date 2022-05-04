using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudleon.Models.Entity.Prime;
using crudleon.Models.TableViewModels;
using crudleon.Models.ViewModels;

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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            // Con esto comprobamos las validaciones de los Data Anotations, en caso de que falle,
            // se regresa el mismo View pero con el model
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (primeEntitiesDB db = new primeEntitiesDB())
            {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.users.Add(oUser);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
    }
}