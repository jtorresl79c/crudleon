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

        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new primeEntitiesDB())
            {
                user oUser = db.users.Find(id);
                model.Id = oUser.id;
                model.Email = oUser.email;
                model.Edad = (int) oUser.edad; // La propiedad oUser.edad en la base de datos es un int nulleable,
                // en C# un int nulleable != int, EditUserViewModel.Edad es de tipo int, un int nulleable en
                // C# = int?, es posible castear un int? a int, por eso se puso el (int), un int NO NULLEABLE = int
                // por lo que en la base de datos hay que ponerlo de esa forma para evitar este tipo de cosas.
            }

            // Nuestro view Edit.cshtml tiene otros campos aparte de Email y Edad, como Password y Confirm Password, sin embargo
            // no lo estamos pasando, en Laravel si no pasamos algo que estamos usando en el View pues va a tronar, pero aqui en
            // Razor eso no pasa porque usamos Html Helpers, si no pasamos la informacion simeplemente el Helper lo deja vacio
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (primeEntitiesDB db = new primeEntitiesDB())
            {
                user oUser = db.users.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;

                if (model.Password!=null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (primeEntitiesDB db = new primeEntitiesDB())
            {
                user oUser = db.users.Find(Id);
                oUser.idState = 3;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }



    }
}