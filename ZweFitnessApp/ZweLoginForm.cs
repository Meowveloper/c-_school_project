using ZweFitnessTrackingAPP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZweFitnessTrackingAPP
{
    public partial class ZweLoginForm : Form
    {
        
        public ZweLoginForm()
        {
            InitializeComponent();
            
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginAndShowFitnessForm();
        }

        //auto focusing input fields and enter navigation for user experience
        private void ZweLoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            linkHelp.Links.Add(64, 69, "https://meow28922.github.io/ZweFitnessHelp/");
        }

        

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter )
            {
                loginAndShowFitnessForm();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }



        

        
        //hiding placeholders of the input fields.
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblPassword.Visible = false;
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblUsername.Visible = false;
        }
        
        //navigating to the register form
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ZweRegistrationForm reg = new ZweRegistrationForm(this);
            reg.Show();
            this.WindowState = FormWindowState.Minimized;

        }


        //login function
        private void loginAndShowFitnessForm()
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Try again");
                return;
            }
            Customer c = new Customer();
            if (c.Login(txtUsername.Text, txtPassword.Text) == true)
            {
                MessageBox.Show("Login Success");
                GlobalData._Username = txtUsername.Text;
                ZweFitnessTrackingForm tracking = new ZweFitnessTrackingForm(this);
                tracking.Show();
                this.WindowState = FormWindowState.Minimized;
            }

            else
                MessageBox.Show("Login Failure");

        }

        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
