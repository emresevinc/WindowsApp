using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace UniversalApp1.Libraries
{
    public class JsonConvert
    {
        public static T DeserilizeObject<T>(HttpResponseMessage response) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            var content = response.Content.ReadAsStringAsync().GetResults();

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                var result = serializer.ReadObject(ms) as T;
                return result;
            }
        }
    }
}
