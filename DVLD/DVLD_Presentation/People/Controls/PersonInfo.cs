using DVLD_Business;
using DVLD_Presentation.People;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class PersonInfo : UserControl
    {
        public event Action<int> WherePersonIDNotFound;
        public event Action RefreshListPeople;
        private int _PersonID = -1;
        clsPerson _Person;
        public PersonInfo()
        {
            InitializeComponent();
        }

        public PersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _FillPersonInfo();

        }
        public int PersonID { get { return _PersonID; } }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        private void PersonInfo_Load(object sender, EventArgs e)
        {


        }
        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID  = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WherePersonIDNotFound?.Invoke(PersonID);

                return;

            }

            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WherePersonIDNotFound?.Invoke(_PersonID);

                return;

            }
            _FillPersonInfo();
        }
        private void _FillPersonInfo()
        {
           

            lbPersonID.Text =_Person.PersonID.ToString();
            lbAddress.Text = _Person.Address;
            lbCountry.Text = _Person.CountryName;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lbEmail.Text = _Person.Email;
            lbName.Text = _Person.FullName();
            lbNationalNo.Text = _Person.NationalNo;
            lbPhone.Text = _Person.Phone;
            lbGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                    pbxPicturePerson.ImageLocation = (_Person.ImagePath);
                else
                    MessageBox.Show("Could not found this Image ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void gbPersonInformation_Enter(object sender, EventArgs e)
        {

        }

        private void lbEdit_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
            RefreshListPeople?.Invoke();
        }

        private void gbPersonInformation_Enter_1(object sender, EventArgs e)
        {

        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lbPersonID.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbName.Text = "[????]";

            lbGendor.Text = "[????]";
            lbEmail.Text = "[????]";
            lbPhone.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbCountry.Text = "[????]";
            lbAddress.Text = "[????]";
            pbxPicturePerson.Image = Resources.Male_512;

        }
    }
}
