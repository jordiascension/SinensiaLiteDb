using Sinensia.Business.Logic;
using Sinensia.Transversal.Model;
using Sinensia.Transversal.Model.CustomExceptions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinensia.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        ICrudBL icrud = new StudentBL();
        frmAddStudent frmAddStudentform = new frmAddStudent();

        public frmStudent()
        {
            InitializeComponent();
            frmAddStudentform.AddStudent += FrmAddStudentform_AddStudent;
        }

        private void FrmAddStudentform_AddStudent()
        {
            loadStudents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                student.Name = txtName.Text;
                student.Surname = txtSurname.Text;
                student.Age = Convert.ToInt32(txtAge.Text);
                Student studentInserted = null;
                if (lblId.Text != "")
                {
                    student._id = Convert.ToInt32(lblId.Text);
                    icrud.Update(student);
                }
                else
                {
                    studentInserted = icrud.Add(student);
                    MessageBox.Show("The student " + studentInserted.Fullname +
                   " is inserted");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (StudentNotFoundException ex)
            {
                MessageBox.Show(ex.Message); 
            }

            loadStudents();
 
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            loadStudents();
        }

        private void loadStudents()
        {
            try
            {
                dgvStudents.DataSource = icrud.FindAll().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvStudents.SelectedRows)
                {
                    lblId.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtSurname.Text = row.Cells[2].Value.ToString();
                    txtAge.Text = row.Cells[4].Value.ToString();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(lblId.Text);
                icrud.Delete(id);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            loadStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            frmAddStudentform.ShowDialog();
        }
    }
}
