using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace DVLD_Presentation.People.Controls
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
       
        public event Action<int> OnPersonSelected;
  
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return personInfo2.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return personInfo2.SelectedPersonInfo; }
        }

        public void LoadPersonInfo(int PersonID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterBy.Text.Trim())
            {
               
                case "Person ID":

                    personInfo2.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;

                case "National No.":
                    personInfo2.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                OnPersonSelected(personInfo2.PersonID);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

   
        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
            

        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

       

        private void DataBackEvent(object sender, int PersonID)
        {
           
            
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            personInfo2.LoadPersonInfo(PersonID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

        
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);



        }

        private void gbFilters_Enter(object sender, EventArgs e)
        {

        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm1 = new frmAddEditPersonInfo();
            frm1.DataBack += DataBackEvent; 
            frm1.ShowDialog();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                btnFind.PerformClick();
            }
        }
    }
}

