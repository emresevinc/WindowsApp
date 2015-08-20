using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiConsole1
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:53377";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/Api/Student/1");
                if (response.IsSuccessStatusCode)
                {
                    string stu = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(stu);
                    Console.ReadKey();
                }
            }
        }
        class Student
        {
            public int id { get; set; }
            public String Ad{ get; set; }
            public int Numara{ get; set; }
        }
    }
}
