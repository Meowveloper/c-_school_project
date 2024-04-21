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
    public partial class frmZweStart : Form
    {
        public frmZweStart()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
           
            ZweLoginForm loginForm = new ZweLoginForm();
            this.Hide();            
            loginForm.ShowDialog();
            this.Close();
            


        }


    }
}
