using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Users
{
    public partial class frmUserInfo : Form
    {
        private int  _UserID;
        public frmUserInfo(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.WhereUserIDNotFound += CloseFormWherePersonIDNotFound;
            ctrlUserCard1.LoadUserInfo(_UserID);
        }
        private void CloseFormWherePersonIDNotFound(int UserID)
        {
            MessageBox.Show("No User with UserID = " + _UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
