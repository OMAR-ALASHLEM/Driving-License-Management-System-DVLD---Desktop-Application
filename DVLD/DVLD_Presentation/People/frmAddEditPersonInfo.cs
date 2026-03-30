using DVLD_Business;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.People
{
    public partial class frmAddEditPersonInfo : Form
    {
        public delegate void DataBackEventHandler(object sendor, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 1, Update = 0 };
        private enMode _Mode = enMode.AddNew;
        private int _PersonID = -1;
        public clsPerson _Person;
        public frmAddEditPersonInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditPersonInfo(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;

        }

        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _ResetDefualtVlues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _LoadData()
        {


            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblTitle.Text = "Update Person Info";

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

            if (_Person.ImagePath != null || _Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
            lbRemoveImage.Visible = (_Person.ImagePath != null || _Person.ImagePath != "");
            cbCountries.SelectedIndex = cbCountries.FindString(clsCountries.GetCountryName(_Person.NationalityCountryID));

        }
        private void _ResetDefualtVlues()
        {

            _FillCountriesInComboBox();
            if (_Mode == enMode.Update)
            {
                lblTitle.Text = "Update Person Info";
                return;

            }

            lblTitle.Text = "Add New Person";
            _Person = new clsPerson();
            dtpDateOfBirth.MinDate = new DateTime(1900, 1, 1);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            lbRemoveImage.Visible = (pbPersonImage.Location != null);
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            rdMale.Checked = true;


        }
        private void _FillCountriesInComboBox()
        {

            DataTable dtCountries = clsCountries.GetAllCountries();


            cbCountries.DataSource = dtCountries;


            cbCountries.DisplayMember = "CountryName";
            cbCountries.ValueMember = "CountryID";
            cbCountries.SelectedIndex = cbCountries.FindString("Jordan");
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
        public bool Save()
        {

            int NationalityCountryID = clsCountries.GetCountryIDByName(cbCountries.Text);

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

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage())
                return;

            if (Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person Info";
                DataBack?.Invoke(this,_Person.PersonID);

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rdMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            lbRemoveImage.Visible = false;
        }

        private void lbSetImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                lbRemoveImage.Visible = true;

            }
        }

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath == pbPersonImage.ImageLocation)
                return true;

            
            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                try
                {
                  
                    File.Delete(_Person.ImagePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not delete old image: " + ex.Message);
                }
            }

            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                string sourceImageFile = pbPersonImage.ImageLocation;

                if (clsUtil.CopyImageToProjectImagesFolder(ref sourceImageFile))
                {
                    pbPersonImage.ImageLocation = sourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            
            return true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Phone Should have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Address Should have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
            }
        }
    }
}
