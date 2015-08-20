using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalApp1.Libraries
{
    public class GenericResponse<T>
    {
        public int StatusCode{ get; set; }

        public string Mesagge { get; set; }

        public int IsSuccess{ get; set; }

        public T Data{ get; set; }

    }
}
