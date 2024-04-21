using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ZweFitnessTrackingAPP;

namespace ZweFitnessTrackingAPP
{
    public partial class ZweRegistrationForm : Form
    {
        Form formLogin;
        public ZweRegistrationForm(Form loginForm)
        {
            InitializeComponent();
            formLogin = loginForm;//to manage login form
        }

      
     
        //listening to the click event of the register button
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if ( txtName.Text=="" ||   txtPassword.Text == "" || txtEmail.Text == "" || txtCalorie.Text=="")
            {
                MessageBox.Show("Please, you need to input all fields.", "Warning");
                return;
            }

            Customer c = new Customer();
            c.UserName = txtName.Text;
            int plength=txtPassword.Text.Length;  
            //check password format between 8 and 16
        if (plength < 8 || plength> 16)
          {
        	MessageBox.Show("Password Length must be BETWEEN 8 characters and 16 characters.","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                	  return;
          }
          if (!Regex.IsMatch(txtPassword.Text, "[A-Z]") || !Regex.IsMatch(txtPassword.Text, "[a-z]"))
           {
            	  MessageBox.Show("Password must contain one capital letter.");
                	  return;
                	 
            }
                      
         
             c.Password = txtPassword.Text;
             c.Email = txtEmail.Text;
             c.TargetCal =int.Parse(txtCalorie.Text);

             bool result=c.Register(c);
            if (result == true)
            {
                MessageBox.Show("Registration success");
                //GlobalData._Username = txtName.Text;
                //ZweFitnessTrackingForm fitnessForm = new ZweFitnessTrackingForm(this);
                //fitnessForm.Show();
                //this.WindowState = FormWindowState.Minimized;
                Customer lc = new Customer();
                if (lc.Login(txtName.Text, txtPassword.Text) == true)
                {
                    GlobalData._Username = txtName.Text;
                    ZweFitnessTrackingForm fitnessForm = new ZweFitnessTrackingForm(this);
                    fitnessForm.Show();
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                MessageBox.Show("Cannot register, the username has been taken.");
            }




        }

        //navigating to the login form 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            formLogin.WindowState = FormWindowState.Normal;
            this.Close();
        }

        //focusing input fields for User experience
        private void ZweRegistrationForm_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblName.Visible = false;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            lblEmail.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblPassword.Visible = false;
        }

        private void txtCalorie_TextChanged(object sender, EventArgs e)
        {
            lblCalorie.Visible = false;
        }

        private void ZweRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            formLogin.WindowState = FormWindowState.Normal;
        }
    }
}
