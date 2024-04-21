using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZweFitnessTrackingAPP
{
    public partial class UserAndActivity : Form
    {
        ZweFitnessTrackingForm fitnessForm;
        
        public UserAndActivity(ZweFitnessTrackingForm fitnessForm)
        {
            InitializeComponent();
            this.fitnessForm = fitnessForm;
            
        }

        //rendering data
        private void UserAndActivity_Load(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            int uid = GlobalData._UserId;
            //int index = lstActivities.SelectedIndex + 1;
            dataGridView1.DataSource = db.getUserAndActivityTable(uid);
            dataGridView1.DataMember = "GetUserAndActivityTable";
            lblUserName.Text = $"User Name - {GlobalData._Username}";
        }

        //form closing event
        private void UserAndActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
            fitnessForm.WindowState = FormWindowState.Normal;
        }

        //click event of back to fitness form button
        private void btnBackToFitnessForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
