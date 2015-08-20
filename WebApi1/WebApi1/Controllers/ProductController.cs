using ClassLibrary1;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi1.Controllers
{
    public class ProductController:ApiController
    {
        [Route("urunler/tumu")]
        public List<Product> GetAll()
        {
            return new List<Product>() {

                    new Product() {Id=1,Title="Buzdolabı",Description="Nofrost",Price=100  },
                    new Product() {Id=2,Title="Televizyon",Description="42' LED",Price=300  },
                    new Product() {Id=3,Title="Cep Telefonu",Description="Dokunmatik Ekran",Price=600  }
            };
        }
    }
}
