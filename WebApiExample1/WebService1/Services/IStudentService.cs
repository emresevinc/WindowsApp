using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService1.Services
{
    public interface IStudentService
    {
        List<Student> getStudents();
        Student getStudent(int id);
    }
}
