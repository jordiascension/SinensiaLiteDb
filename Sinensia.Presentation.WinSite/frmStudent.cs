using Sinensia.Business.Logic;
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

namespace Sinensia.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        ICrudBL icrud = new StudentBL();

        public frmStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            else { 
                 studentInserted  = icrud.Add(student);
                MessageBox.Show("The student " + studentInserted.Fullname +
               " is inserted");
            }

            loadStudents();

            
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            loadStudents();
        }

        private void loadStudents()
        {
            dgvStudents.DataSource = icrud.FindAll().ToList();
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStudents.SelectedRows)
            {
                lblId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtSurname.Text = row.Cells[2].Value.ToString();
                txtAge.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            icrud.Delete(id);
            loadStudents();
        }
    }
}
