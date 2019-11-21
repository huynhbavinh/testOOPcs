using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class FUpdate : Form
    {
        private int student_id;
        private StudentManagement business;
        public FUpdate(int id)
        {
            InitializeComponent();
            this.student_id = id;
            this.business = new StudentManagement();
            this.btnCancel.Click += btnCancel_Click;
            this.btnSave.Click += btnSave_Click;
            this.Load += FUpdate_Load;
           
        }

       
        void FUpdate_Load(object sender, EventArgs e)
        {
            var OldStudent = this.business.GetStudent(student_id);
            this.txtCode.Text = OldStudent.code;
            this.txtName.Text = OldStudent.name;
            this.txtHomeTown.Text = OldStudent.HomeTown;
            if (OldStudent.gender == true)
            {
                this.rdoMale.Checked = true;
            }
            else
            {
                this.rdoFemale.Checked = true;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var code = this.txtCode.Text;
            var hometown = this.txtHomeTown.Text;
            var gender = false;
            if (rdoMale.Checked == true)
            {
                gender = true;
            }
           
            this.business.UpdateStudent(this.student_id, code, name, gender, hometown);
            MessageBox.Show("Update succesfully");
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
