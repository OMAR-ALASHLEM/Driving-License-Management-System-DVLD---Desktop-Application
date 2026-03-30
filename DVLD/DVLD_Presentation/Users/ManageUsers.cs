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

namespace DVLD_Presentation.Users
{
    public partial class ManageUsers : Form
    {
        private DataTable _dtAllUsers = clsUser.GetAllUsers();

        public ManageUsers()
        {
            InitializeComponent();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUserInfo frm = new frmUserInfo((int)dvgListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _LoadData()
        {
            dvgListUsers.DataSource = _dtAllUsers.DefaultView;
            cmbFilters.SelectedIndex = 0;
            lbRecords.Text = dvgListUsers.Rows.Count.ToString();
            if (dvgListUsers.Rows.Count > 0)
            {


                dvgListUsers.Columns["UserID"].HeaderText = "User ID";
                dvgListUsers.Columns["UserID"].Width = 110;

                dvgListUsers.Columns["PersonID"].HeaderText = "Person ID";
                dvgListUsers.Columns["PersonID"].Width = 120;

                dvgListUsers.Columns["FullName"].HeaderText = "Full Name";
                dvgListUsers.Columns["FullName"].Width = 350;

                dvgListUsers.Columns["UserName"].HeaderText = "UserName";
                dvgListUsers.Columns["UserName"].Width = 120;

                dvgListUsers.Columns["IsActive"].HeaderText = "Is Active";
                dvgListUsers.Columns["IsActive"].Width = 120;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbFilters.Text == "Is Active")
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }

            else

            {

                txtFilter.Visible = (cmbFilters.Text != "None");
                cbIsActive.Visible = false;

                if (cmbFilters.Text == "None")
                {
                    txtFilter.Enabled = false;
                }
                else
                    txtFilter.Enabled = true;

                txtFilter.Text = "";
                txtFilter.Focus();
            }

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers == null || _dtAllUsers.Rows.Count == 0)
                return;

            string FilterColumn = "";

            switch (cmbFilters.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lbRecords.Text = _dtAllUsers.DefaultView.Count.ToString();
                return;
            }

            try
            {
                if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                {

                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
                }
                else
                {

                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim().Replace("'", "''"));
                }
            }
            catch (Exception)
            {

                _dtAllUsers.DefaultView.RowFilter = "";
            }

            lbRecords.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilters.Text == "Person ID" || cmbFilters.Text == "UserID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lbRecords.Text = _dtAllUsers.Rows.Count.ToString();

        }

        private void dvgListUsers_DoubleClick(object sender, EventArgs e)
        {

            frmUserInfo frm = new frmUserInfo((int)dvgListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dvgListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void _RefreshListUsers()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            _LoadData();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            _RefreshListUsers();

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            _RefreshListUsers();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dvgListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshListUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsUser.DeleteUser((int)dvgListUsers.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshListUsers();
            }
            else
            {
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}