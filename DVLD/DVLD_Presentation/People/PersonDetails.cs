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
    public partial class PersonDetails : Form
    {
        public event Action RefreshListPeople;
        private int _PersonID;
        public PersonDetails()
        {
            InitializeComponent();
        }
        public PersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID=PersonID;
        }
        private void CloseFormWherePersonIDNotFound(int _PersonID)
        {
            MessageBox.Show($"Person With ID: ({_PersonID}), Is Not Found", "Not Found");
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {

            personInfo1.WherePersonIDNotFound += CloseFormWherePersonIDNotFound;
            personInfo1.LoadPersonInfo(_PersonID);
        }

        private void lbEdit_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_PersonID, 0);
            frm.ShowDialog();
            RefreshListPeople?.Invoke();


        }
    }
}
