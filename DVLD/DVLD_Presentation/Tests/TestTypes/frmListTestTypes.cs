using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests.TestTypes
{
    public partial class frmListTestTypes : Form
    {

        DataTable _dtTestTypes = new DataTable();

        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadData()
        {
            _dtTestTypes = clsTestTypes.GetAllTetTypes();
            dvgListTestTypes.DataSource = _dtTestTypes.DefaultView;
            if (dvgListTestTypes.Rows.Count > 0)
            {

                dvgListTestTypes.Columns["TestTypeID"].HeaderText = "Application Type ID";
                dvgListTestTypes.Columns["TestTypeID"].Width = 100;
                dvgListTestTypes.Columns["TestTypeTitle"].HeaderText = "Title";
                dvgListTestTypes.Columns["TestTypeTitle"].Width = 130;
                dvgListTestTypes.Columns["TestTypeDescription"].HeaderText = "Description";
                dvgListTestTypes.Columns["TestTypeDescription"].Width = 500;
                dvgListTestTypes.Columns["TestTypeFees"].HeaderText = "Fees";
                dvgListTestTypes.Columns["TestTypeFees"].Width = 100;
            }
            lbRecords.Text = dvgListTestTypes.Rows.Count.ToString() + " Record(s) Found.";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frm=new frmUpdateTestTypes((int)dvgListTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
