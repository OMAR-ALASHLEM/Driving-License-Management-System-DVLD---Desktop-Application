using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Application_Types
{
    
    public partial class frmListApplicationTypes : Form
    {
        DataTable _dtApplicationTypes = new DataTable();
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _LoadData()
        {
            _dtApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dvgListApplicationTypes.DataSource = _dtApplicationTypes.DefaultView;
            if (dvgListApplicationTypes.Rows.Count > 0)
            {
                dvgListApplicationTypes.Columns["ApplicationTypeID"].HeaderText = "Application Type ID";
                dvgListApplicationTypes.Columns["ApplicationTypeID"].Width = 150;
                dvgListApplicationTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";
                dvgListApplicationTypes.Columns["ApplicationTypeTitle"].Width = 350;
                dvgListApplicationTypes.Columns["ApplicationFees"].HeaderText = "Fees";
                dvgListApplicationTypes.Columns["ApplicationFees"].Width = 150;
            }
            lbRecords.Text = dvgListApplicationTypes.Rows.Count.ToString() + " Record(s) Found.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
