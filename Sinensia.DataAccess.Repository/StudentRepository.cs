using LiteDB;

using Sinensia.Transversal.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinensia.DataAccess.Repository
{
    public class StudentRepository : ICrud
    {
        public Student Add(Student student)
        {
            using (var db = new LiteDatabase(@"C:\Temp\School.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Student>("student");

                // Create your new customer instance
               

                // Insert new customer document (Id will be auto-incremented)
                int id = col.Insert(student);
                Console.WriteLine(student._id);

                return student;
            }
        }
    }
}
