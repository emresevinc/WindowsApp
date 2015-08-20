using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService1.Services
{
    public class StudentService : IStudentService
    {
        private DataDBDataContext context = new DataDBDataContext();

        public List<Student> getStudents()
        {
            return context.Students.ToList() ;
        }
        
        public Student getStudent(int id)
        {
            var st = (from s in context.Students
                      where s.id == id
                      select s
                    ).FirstOrDefault();
            return st != null ? st : null;
            // context.Students.Where(s => s.id == id).First();
        }
    }
}
