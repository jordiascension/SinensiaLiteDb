using Sinensia.Transversal.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinensia.DataAccess.Repository
{
    public interface ICrud
    {
        Student Add(Student student);
        IEnumerable<Student> FindAll();
        bool Delete(int id);
        bool Update(Student student);
    }
}
