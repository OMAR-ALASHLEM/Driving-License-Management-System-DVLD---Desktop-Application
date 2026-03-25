using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.People
{
    public partial class frmAddEditPersonInfo : Form
    {
        private int _PersonID;
        public frmAddEditPersonInfo()
        {
            InitializeComponent();
        }
        public frmAddEditPersonInfo(int Mode)
        {
            InitializeComponent();

            addEditPersonInfo1.LoadPersonInfo( Mode);
        }
        public frmAddEditPersonInfo(int PersonID,int Mode)
        {
            InitializeComponent();
            addEditPersonInfo1.LoadPersonInfo(PersonID, Mode);
            _PersonID = PersonID;
        }

        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
