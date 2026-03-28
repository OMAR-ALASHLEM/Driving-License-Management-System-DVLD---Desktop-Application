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

namespace DVLD_Presentation.Users
{
    public partial class ctrlUserCard : UserControl
    {
        public event Action<int> WhereUserIDNotFound;
        public clsUser _User;
        
        public int UserID
        {
            get { return _User.User_ID; }
        }
        public ctrlUserCard()
        {

            InitializeComponent(); 
        }
    

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }
        public void LoadUserInfo(int UserID=1)
        {
            _User = clsUser.Find(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                WhereUserIDNotFound?.Invoke(UserID);
              
                return;
            }
            _FillUserInfo();

        }
        private void _FillUserInfo()
        {

            personInfo1.LoadPersonInfo(_User.Person_ID);
            lblUserID.Text = _User.User_ID.ToString();
            lblUserName.Text = _User.Username.ToString();

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }
        private void _ResetPersonInfo()
        {

            personInfo1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }

    }

}
