using LiteDB;

using Sinensia.Transversal.Model;
using Sinensia.Transversal.Model.CustomExceptions;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(@"C:\Temp\School.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Student>("student");

                return col.Delete(id);
            }
        }

        public IEnumerable<Student> FindAll()
        {
            using (var db = new LiteDatabase(@"C:\Temp\School.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var studentEnumerable = db.GetCollection<Student>("student").
                    FindAll().ToList();
                
                return studentEnumerable;
            }
        }

        public bool Update(Student student)
        {
            using (var db = new LiteDatabase(@"C:\Temp\School.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Student>("student");

                var studentUpdated = col.FindById(student._id);

                if(studentUpdated == null) {
                    throw new StudentNotFoundException("Student with id " + student._id 
                        + " not found");
                }

                studentUpdated.Name = student.Name;
                studentUpdated.Surname = student.Surname;
                studentUpdated.Fullname = student.Fullname;
                studentUpdated.Age = student.Age;

                return col.Update(studentUpdated);   
            }
            
        }
    }
}
