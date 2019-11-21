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
    public partial class FCreate : Form
    {
        private StudentManagement business;
        public FCreate()
        {
            InitializeComponent();
            this.business = new StudentManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        { 
            this.Close();
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
            this.business.CreateStudent(code, name, gender, hometown);
            MessageBox.Show("Add New Successfully");
            this.Close();
        }
    }
}
