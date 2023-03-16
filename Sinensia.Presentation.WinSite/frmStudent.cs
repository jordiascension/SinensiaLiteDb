﻿using Sinensia.Business.Logic;
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

            ICrudBL icrud = new StudentBL();
            Student studentInserted  = icrud.Add(student);

            MessageBox.Show("The student " + studentInserted.Fullname +
                " is inserted");
        }
    }
}
