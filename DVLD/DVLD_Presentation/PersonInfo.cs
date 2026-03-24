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

namespace DVLD_Presentation
{
    public partial class PersonInfo : UserControl
    {
    public event Action<int> WherePersonIDNotFound;
        private int _PersonID=1 ;
   
        public PersonInfo()
        {
            InitializeComponent();
        }

        public PersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _LoadData(); 
       
        }

        private void PersonInfo_Load(object sender, EventArgs e)
        {
       

        }
        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _LoadData(); 
        }
        private void _LoadData()
        {
            clsPerson person = clsPerson.Find(_PersonID);
            if (person == null)
            {
                WherePersonIDNotFound(_PersonID);
                return;
            }
            lbAddress.Text = person.Address;
            lbCountry.Text = person.CountryName;
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbEmail.Text = person.Email;
            lbName.Text = person.FullName();
            lbNationalNo.Text = person.NationalNo;
            lbPersonID.Text = _PersonID.ToString();
            lbPhone.Text = person.Phone;
            lbGendor.Text = person.Gendor == 0 ? "Male" : "Female";
            if (person.ImagePath != "")
            {
                pbxPicturePerson.Load(person.ImagePath);
            }


        }

        private void gbPersonInformation_Enter(object sender, EventArgs e)
        {

        }
    }
}
