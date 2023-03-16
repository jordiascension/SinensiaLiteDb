using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sinensia.DataAccess.Repository;
using Sinensia.Transversal.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinensia.DataAccess.Repository.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        ICrud icrud = new StudentRepository();

        [TestMethod()]
        public void AddTest()
        {
            Student student = new Student();
            student.Name= "Test";
            student.Surname = "Test";
            student.Fullname= "Test Test";
            student.Age = 1;

            Student studentInserted = icrud.Add(student);

            Assert.IsTrue(studentInserted._id > 0);
        }
    }
}