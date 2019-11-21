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
    public partial class FStudent : Form
    {
        private StudentManagement business;
        public FStudent()
        {
            InitializeComponent();
            this.business = new StudentManagement();
            this.Load += FStudent_Load;
            this.aDDTool.Click += aDDTool_Click;
            this.dELETETool.Click += dELETETool_Click;
            this.dataGridView1.DoubleClick += dataGridView1_DoubleClick;
        }

        void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                var UpdateStudent = (PM14034)this.dataGridView1.SelectedRows[0].DataBoundItem;

                var updateForm = new FUpdate(UpdateStudent.id);
                updateForm.ShowDialog();
                this.loadStudent();
            }
        }
        private void loadStudent()
        {
            var AllStudent = this.business.GetAllStudent();
            this.dataGridView1.DataSource = AllStudent;
            if (dataGridView1.CurrentRow.Cells("gender").Value = 1)
            {
                
            }
        }

        void dELETETool_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this?", "Comfirm"
                    , MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var DelStudent = (PM14034)this.dataGridView1.SelectedRows[0].DataBoundItem;
                    this.business.DeleteStudent(DelStudent.id);
                    MessageBox.Show("Delete succesfully");
                    this.loadStudent();
                }
            }
        }

        void aDDTool_Click(object sender, EventArgs e)
        {
            var CreateForm = new FCreate();
            CreateForm.ShowDialog();
            this.loadStudent();
        }

        void FStudent_Load(object sender, EventArgs e)
        {
            this.loadStudent();
        }
    }
}
