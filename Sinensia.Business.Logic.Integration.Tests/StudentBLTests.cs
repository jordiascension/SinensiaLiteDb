using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sinensia.Business.Logic;
using Sinensia.Transversal.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinensia.Business.Logic.Tests
{
    [TestClass()]
    public class StudentBLTests
    {
        ICrudBL crud = new StudentBL();

        [TestMethod()]
        public void AddTest()
        {
            Student student = new Student();
            student.Name = "Test";
            student.Surname = "Test";
            student.Age = 1;

            Student studentInserted = crud.Add(student);

            Assert.IsTrue(studentInserted._id > 0);

            Assert.IsTrue(studentInserted.Fullname == "Test Test");
        }
    }
}