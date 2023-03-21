using Sinensia.Transversal.Model.CustomExceptions;
using Sinensia.Transversal.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sinensia.Business.Logic;

namespace Sinensia.Presentation.WinSite
{
    public partial class frmAddStudent : Form
    {
        public event StudentAddHandler AddStudent;

        
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ICrudBL icrud = new StudentBL();
                Student student = new Student();
                student.Name = txtName.Text;
                student.Surname = txtSurname.Text;
                student.Age = Convert.ToInt32(txtAge.Text);
                Student studentInserted = null;
               
                studentInserted = icrud.Add(student);
                OnAddStudentInserted();
                MessageBox.Show("The student " + studentInserted.Fullname +
                   " is inserted");
                
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected virtual void OnAddStudentInserted()
        {
            if (AddStudent != null)
            {
                Console.WriteLine("Event fired!");
                AddStudent();
            }
            else
            {
                Console.WriteLine("No Event fired!");
            }
        }
    }
}
