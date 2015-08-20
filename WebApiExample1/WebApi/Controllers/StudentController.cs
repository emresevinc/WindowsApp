using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService1;
using WebService1.Services;

namespace WebApi.Controllers
{
    public class StudentController : ApiController
    {
        IStudentService studentService = new StudentService();

        public IEnumerable<Student> Get()
        {
            return studentService.getStudents();
        }

        public Student Get(int id )
        {
            return studentService.getStudent(id);
        }
    }
}
