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

namespace DVLD_Presentation.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicesnseApplications : Form
    {
        DataTable _dtList_L_D_A = new DataTable();

        public frmListLocalDrivingLicesnseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _dtList_L_D_A = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dvgListLocalDrivangApplication.DataSource = _dtList_L_D_A.DefaultView;
            lbRecords.Text = dvgListLocalDrivangApplication.Rows.Count.ToString();
            if (dvgListLocalDrivangApplication.Rows.Count > 0)
            {

                dvgListLocalDrivangApplication.Columns[0].HeaderText = "L.D.L.AppID";
                dvgListLocalDrivangApplication.Columns[0].Width = 120;

                dvgListLocalDrivangApplication.Columns[1].HeaderText = "Driving Class";
                dvgListLocalDrivangApplication.Columns[1].Width = 300;

                dvgListLocalDrivangApplication.Columns[2].HeaderText = "National No.";
                dvgListLocalDrivangApplication.Columns[2].Width = 150;

                dvgListLocalDrivangApplication.Columns[3].HeaderText = "Full Name";
                dvgListLocalDrivangApplication.Columns[3].Width = 350;

                dvgListLocalDrivangApplication.Columns[4].HeaderText = "Application Date";
                dvgListLocalDrivangApplication.Columns[4].Width = 170;

                dvgListLocalDrivangApplication.Columns[5].HeaderText = "Passed Tests";
                dvgListLocalDrivangApplication.Columns[5].Width = 150;
            }
            cmbFilters.SelectedIndex = 0;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
            _LoadData();
        }
        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilters.Text == "None")
            {
                txtFilter.Visible = false;

                if (_dtList_L_D_A != null)
                {
                    _dtList_L_D_A.DefaultView.RowFilter = "";
                    lbRecords.Text = dvgListLocalDrivangApplication.Rows.Count.ToString();
                }
            }
            else
            {
                txtFilter.Visible = true;
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cmbFilters.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtList_L_D_A.DefaultView.RowFilter = "";
                lbRecords.Text = dvgListLocalDrivangApplication.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                _dtList_L_D_A.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else if (FilterColumn == "NationalNo")
            {
                _dtList_L_D_A.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _dtList_L_D_A.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            }

       
            lbRecords.Text = dvgListLocalDrivangApplication.Rows.Count.ToString();
        }
        private void txtFilter_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cmbFilters.Text == "L.D.L.AppID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dvgListLocalDrivangApplication.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                    frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
                if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int LocalDrivingLicenseApplicationID = (int)dvgListLocalDrivangApplication.CurrentRow.Cells[0].Value;

                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Delete())
                    {
                        MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                        frmListLocalDrivingLicesnseApplications_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }
    }
}
