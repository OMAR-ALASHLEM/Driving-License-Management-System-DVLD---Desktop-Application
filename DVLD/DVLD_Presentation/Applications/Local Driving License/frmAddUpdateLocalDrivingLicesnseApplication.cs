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
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
        }
        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void lblApplicationDate_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (ctrlPersonInfoWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tabApplicaionInfo.Enabled = true;
                tabLocalDrivingLicense.SelectedIndex = 1;
            }
            else
            {

                MessageBox.Show("Please Select a Person First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfoWithFilter1.FilterFocus();

            }
        }
        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();

        }
        private bool _Validating()
        {
            int ActiveApplicationID = clsLocalDrivingLicenseApplication.GetActiveApplicationIDForLicenseClass(ctrlPersonInfoWithFilter1.PersonID, clsApplication.enApplicationType.NewDrivingLicense, (int)cbLicenseClass.SelectedValue);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another license class, the selected person already has an active application for the same class with ID = " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int LiceneseID = clsLicenses.GetActiveLicenseIDByPersonID(ctrlPersonInfoWithFilter1.PersonID, (int)cbLicenseClass.SelectedValue);
            if (LiceneseID != -1)
            {
                MessageBox.Show("The selected person has an active application for New driving license, please complete or cancel it before creating a new application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void _LoadData()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

            ctrlPersonInfoWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);

            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();

            lblCreatedByUser.Text = _LocalDrivingLicenseApplication.CreatedByUserID.ToString();

            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();

            cbLicenseClass.SelectedValue = _LocalDrivingLicenseApplication.LicenseClassID;

            cbLicenseClass.Enabled = false;
            ctrlPersonInfoWithFilter1.Enabled = false;

        }
        private void _FillLicensesClass()
        {

            DataTable dtCountries = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DataSource = dtCountries;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            cbLicenseClass.SelectedIndex = 2;
            cbLicenseClass.Focus();
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
    
            if (_Mode == enMode.AddNew && !_Validating()) return;

            if (_Mode == enMode.AddNew)
            {
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.User_ID;

            }
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonInfoWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.LicenseClassID = (int)cbLicenseClass.SelectedValue;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            if (_LocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblLocalDrivingLicebseApplicationID.Text=_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();   
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("Failed to save the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void _ResetDefualtValues()
        {


                _FillLicensesClass();
            lblFees.Text=clsApplicationType.GetApplicationTypeByID(1).Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text=clsGlobal.CurrentUser.User_ID.ToString();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Local Driving License Application";
                this.Text = "New Local Driving License Application";
                tabApplicaionInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlPersonInfoWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                ctrlPersonInfoWithFilter1.FilterEnabled = false;
                tabLocalDrivingLicense.SelectedIndex = 1;
                cbLicenseClass.Enabled = false;
                ctrlPersonInfoWithFilter1.Enabled = false;
                tabApplicaionInfo.Enabled = true;
                btnSave.Enabled = true;


            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
