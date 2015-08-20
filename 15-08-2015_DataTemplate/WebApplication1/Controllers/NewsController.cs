using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;



namespace WebApplication1.Controllers
{
    public class NewsController : Controller   // class mutlaka public olmalı
    {
        public JsonResult GetList()
        {
            var model = new List<Category>();
            model.Add(new Category {id=1, Name="Ali" });
            model.Add(new Category { id = 1, Name = "Mehmet" });
            return Json(model,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetails(int haberId)
        {
            return Json(null);
        }
    }
}
