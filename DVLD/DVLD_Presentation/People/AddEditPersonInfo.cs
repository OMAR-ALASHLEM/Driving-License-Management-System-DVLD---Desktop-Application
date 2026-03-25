using DVLD_Business;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsPerson;

namespace DVLD_Presentation.People
{
    public partial class AddEditPersonInfo : UserControl
    {
        public enum enMode { AddNew = 1, Update = 0 };
        private enMode _Mode = enMode.AddNew;
        private int _PersonID = -1;
        public clsPerson _Person;
        public AddEditPersonInfo()
        {
            InitializeComponent();
        }




        public bool Save()
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int NationalityCountryID = clsCountries.GetCountryIDByName(comboBox1.Text);

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = NationalityCountryID;
            _Person.Gendor = (byte)(rdMale.Checked ? 0 : 1);
            _Person.ImagePath = pbPersonImage.ImageLocation ?? "";

            if (_Person.Save())
            {
                lbPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {

        }

     

        public void LoadPersonInfo(int PersonID, int Mode)
        {
            _ResetDate(Mode);
            FillPersonInfo(PersonID);
        }
        public void LoadPersonInfo(int Mode)
        {

            _ResetDate(Mode);

        }
        private void FillPersonInfo(int PersonID)
        {


            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblTitle.Text = "Update Person Info";
            _PersonID = PersonID;
            lbPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
                rdMale.Checked = true;
            else
                rdFemale.Checked = true;

            comboBox1.SelectedIndex = comboBox1.FindString(clsCountries.GetCountryName(_Person.NationalityCountryID));

        }
        private void _ResetDate(int Mode )
        {
            if (Mode == 0)
            {
                _Mode = enMode.Update;
            }
            _FillCountriesInComboBox();
            if (_Mode == enMode.Update)
            {
                lblTitle.Text = "Update Person Info";
                return;

            }

            lblTitle.Text = "Add New Person";
            _Person = new clsPerson();
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            rdMale.Checked = true;
            dtpDateOfBirth.MinDate = new DateTime(1900, 1, 1);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);


        }
        private void _FillCountriesInComboBox()
        {

            DataTable dtCountries = clsCountries.GetAllCountries();


            comboBox1.DataSource = dtCountries;


            comboBox1.DisplayMember = "CountryName";
            comboBox1.ValueMember = "CountryID";
            comboBox1.SelectedIndex = comboBox1.FindString("Jordan");
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "First Name Should have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSecondName.Text))
            {
                e.Cancel = true;
                txtSecondName.Focus();
                errorProvider1.SetError(txtSecondName, "Second Name Should have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSecondName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Last Name Should have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true; 
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }

            
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true; 
                errorProvider1.SetError(txtNationalNo, "National Number is already used by another person!");
            }
            else
            {
             
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateDefaultImage();
        }
        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateDefaultImage();
        }
        private void _UpdateDefaultImage()
        {

            if (pbPersonImage.ImageLocation == null)
            {
                if (rdMale.Checked)
                    pbPersonImage.Image = Resources.Male_512;
                else
                    pbPersonImage.Image = Resources.Female_512;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person Info";

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
                return;
            }

          
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Invalid Email Format! Example: user@domain.com");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }
    }
}
