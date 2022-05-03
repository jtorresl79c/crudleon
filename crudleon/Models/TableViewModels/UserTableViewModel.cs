using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crudleon.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; } // Si en la db la columna acepta Nulls y es de tipo int, entonces esa columna en c# no es un
        //int al menos no al 100%, es un int?, si fuera un string que acepta nulls, seria un string?, etc.
    }
}