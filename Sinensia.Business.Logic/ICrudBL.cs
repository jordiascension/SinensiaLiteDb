using Sinensia.Transversal.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinensia.Business.Logic
{
    public interface ICrudBL
    {
        Student Add(Student student);
        IEnumerable<Student> FindAll();
        bool Delete(int id);
        bool Update(Student student);
    }
}
