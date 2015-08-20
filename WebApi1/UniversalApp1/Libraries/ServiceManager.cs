using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace UniversalApp1.Libraries
{
    class ServiceManager
    {
        private HttpClient client = new HttpClient();

        public GenericResponse<List<Product>> TumUrunler()
        {
            var result = new GenericResponse<List<Product>>();

            var postData = new List<KeyValuePair<string, string>>();
            //postData.Add(new KeyValuePair<string, string>("userId", "5"));  // servise geçirmek istediğimiz parametreleri bu sekilde ekliyoruz
            //postData.Add(new KeyValuePair<string, string>("keyword", "engin"));
            //postData.Add(new KeyValuePair<string, string>("count", "15"));

            var parameters = new HttpFormUrlEncodedContent(postData);

            client.PostAsync(new Uri("http://yazokulu2015webservice.azurewebsites.net/urunler/tumu"), parameters)
                .AsTask().ContinueWith(response =>
                {
                    result = JsonConvert.DeserilizeObject<GenericResponse<List<Product>>>(response.Result);
                }
                ).Wait();
            return result;
        }

    }
}
