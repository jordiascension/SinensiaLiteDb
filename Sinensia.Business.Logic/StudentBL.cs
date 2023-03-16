using Sinensia.DataAccess.Repository;
using Sinensia.Transversal.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinensia.Business.Logic
{
    public class StudentBL : ICrudBL
    {
        ICrud crud = new StudentRepository();

        public Student Add(Student student)
        {
            student.Fullname = student.Name + " " + student.Surname;
            return crud.Add(student);
        }

        public bool Delete(int id)
        {
            return crud.Delete(id);
        }

        public IEnumerable<Student> FindAll()
        {
            return crud.FindAll();
        }

        public bool Update(Student student)
        {
            student.Fullname = student.Name + " " + student.Surname;
            return crud.Update(student);
        }
    }
}
