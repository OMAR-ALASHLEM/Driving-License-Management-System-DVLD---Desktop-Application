using DVLD_Business;
using DVLD_Presentation.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class ManagePeople : Form
    {
        private DataTable _dtAllPeople = clsPerson.GetAllPeople();
        public ManagePeople()
        {
            InitializeComponent();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _LoadData()
        {
            dvgListPeople.DataSource = _dtAllPeople.DefaultView;
            cmbFilters.SelectedIndex = 0;
            lbRecords.Text=dvgListPeople.Rows.Count.ToString();
            dvgListPeople.Columns["PersonID"].HeaderText = "Person ID";
            dvgListPeople.Columns["FirstName"].HeaderText = "First Name";
            dvgListPeople.Columns["SecondName"].HeaderText = "Second Name";
            dvgListPeople.Columns["ThirdName"].HeaderText = "Third Name";
            dvgListPeople.Columns["LastName"].HeaderText = "Last Name";
            dvgListPeople.Columns["NationalNo"].HeaderText = "National No";
            dvgListPeople.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            dvgListPeople.Columns["CountryName"].HeaderText = "Nationality";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cmbFilters.Text != "None");
            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
           
            if (_dtAllPeople == null || _dtAllPeople.Rows.Count == 0)
                return;

            string FilterColumn = "";

         
            switch (cmbFilters.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National NO":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "CountryName";
                    break;
                case "Gendor":
                    FilterColumn = "Gendor";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                lbRecords.Text = _dtAllPeople.DefaultView.Count.ToString();
                return;
            }

            try
            {
                if (FilterColumn == "PersonID")
                {
             
                    _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
                }
                else
                {

                    _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim().Replace("'", "''"));
                }
            }
            catch (Exception )
            {
           
                _dtAllPeople.DefaultView.RowFilter = "";
            }

            lbRecords.Text = _dtAllPeople.DefaultView.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilters.Text == "Person ID")
            { 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void _AddNewPerson()
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo();
            frm.ShowDialog();
            RefreshListPeople();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedPersonID = (int)dvgListPeople.CurrentRow.Cells[0].Value;
            PersonDetails frm = new PersonDetails(SelectedPersonID);
            frm.ShowDialog();
        }


        private void RefreshListPeople()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _LoadData();
        }
        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedPersonID = (int)dvgListPeople.CurrentRow.Cells[0].Value;
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(SelectedPersonID);
            frm.ShowDialog();

            RefreshListPeople();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedPersonID = (int)dvgListPeople.CurrentRow.Cells[0].Value;
        
            clsPerson _Person = clsPerson.Find(SelectedPersonID);
            if (clsPerson.DeletePerson(SelectedPersonID))
            {
                MessageBox.Show("Data Deleted Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_Person.ImagePath != "")
                    System.IO.File.Delete(_Person.ImagePath);
                RefreshListPeople();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Deleted Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

