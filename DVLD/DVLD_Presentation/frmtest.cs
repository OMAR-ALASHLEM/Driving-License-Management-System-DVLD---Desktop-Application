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
    public partial class frmtest : Form
    {
        public frmtest()
        {
            InitializeComponent();
        }
        private void CloseFormWherePersonIDNotFound(int _PersonID)
        {
            MessageBox.Show($"Person With ID: ({_PersonID}), Is Not Found", "Not Found");
            this.Close();   
        }
        private void frmtest_Load(object sender, EventArgs e)
        {

            personInfo1.WherePersonIDNotFound += CloseFormWherePersonIDNotFound;
            personInfo1.LoadPersonInfo(1);
        }
    }
}
