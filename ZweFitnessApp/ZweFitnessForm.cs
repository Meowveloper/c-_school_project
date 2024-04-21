using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using ZweFitnessTrackingAPP;
using System.Xml.Linq;

namespace ZweFitnessTrackingAPP
{
    public partial class ZweFitnessTrackingForm : Form
    {
        int iRowIndex;
        OleDbCommand mycmd;
        OleDbDataReader myreader;
        OleDbConnection conn;
        DataTable table;
        OleDbDataAdapter dataadapter;
        ListBoxManager listBoxManager = new ListBoxManager();
        Validator validator = new Validator();

        DialogResult response;
        string constr = "";
        float m1, m2, m3, curCal;
        int mid, uid, aid;
        string activity;
        Form loginOrRegForm;

        
        public ZweFitnessTrackingForm(Form form)
        {
            InitializeComponent();
            uid = GlobalData._UserId;
            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\FitnessDB.mdb";

            conn = new OleDbConnection();
            conn.ConnectionString = constr;
            loginOrRegForm = form;// to control login or register form
            
          
        }


        //closing fitness form
        private void button1_Click(object sender, EventArgs e)
        {
            
            //frmReview fr = new frmReview();
            //fr.Show();
            this.Close();
        }

      
        //listening to the clicking event on the data grid view and data binding of the clicked row
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                iRowIndex = dataGridView1.CurrentRow.Index;
                databind();
            }
            catch(Exception ex) { MessageBox.Show("No record to select"); }
            
        }
        void databind()
        {
            //to  update data to dbtable
            mid = int.Parse(dataGridView1[0, iRowIndex].Value.ToString());
            aid = int.Parse(dataGridView1[2, iRowIndex].Value.ToString());

            lstActivities.SelectedIndex = aid - 1;

            string query = "SELECT * FROM userActMatric WHERE mid= " + mid + " AND aid=" + aid + " AND uid=" + uid;
            conn = new OleDbConnection(constr);
            conn.Open();
            mycmd = new OleDbCommand(query, conn);
            OleDbDataReader myreader;
            myreader = mycmd.ExecuteReader();

            while (myreader.Read())
            {
                mid = int.Parse(myreader.GetValue(0).ToString());
                txtMetric1.Text = myreader.GetValue(3).ToString(); txtMetric1.Text = myreader.GetValue(3).ToString();
                txtMetric2.Text = myreader.GetValue(4).ToString();
                txtMetric3.Text = myreader.GetValue(5).ToString();

            }
            myreader.Close();
            conn.Close();

        }

        //preparing the form for rendering data
        private void ZweFitnessTrackingForm_Load(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            List<string> lst = new List<string>();
            lst = db.getActivities();
            lstActivities.DataSource = lst;
            lstActivities.Show();
            lblUserName.Text += GlobalData._Username;
            lblTargetCal.Text += GlobalData._targetCalorie;

            FitnessClass ft = new FitnessClass();
            curCal = (float)ft.CurrentTotalCalories(uid);
            lblCurrentCalorie.Text += curCal;
            listBoxMetric4.Visible = false;
            lblMetric4.Visible = false;
            configuringPositions();


        }

        //for reconfiguring positions of text boxes and labels
        private void configuringPositions ()
        {
            txtMetric1.Visible = true;
            txtMetric2.Visible = true;
            txtMetric3.Visible = true;
            listBoxMetric4.Visible = false;
            lblMetric4.Visible = false;
            lblMetric4.Text = "";
            listBoxMetric4.Location = new Point(259, 311);
        }

        //listening to the closing event of the form
        private void ZweFitnessTrackingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginOrRegForm.WindowState = FormWindowState.Normal;
        }

        //navigating to the UserAndActivity form
        private void lblAllActivities_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserAndActivity userAndActivity = new UserAndActivity(this);
            userAndActivity.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        //listening to the changing data value of the activity list box
        private void lstActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            uid = GlobalData._UserId;
            aid = lstActivities.SelectedIndex + 1;
            dataGridView1.DataSource = db.getTable(uid,aid);
            dataGridView1.DataMember = "UserActivityMatricTable";
            activity = lstActivities.SelectedItem.ToString();
            configuringPositions();

            if (activity=="swimming")
            {
                
                lblMatric1.Text = "MET Value( 2 to 13)";
                lblMetric2.Text = "Time taken (minutes)";
                lblMetric3.Text = "Weight (pounds)";
                picActivity.Image = Properties.Resources.swimming;

            }
            else if (activity=="walking")
            {
               
                lblMatric1.Text = "Height(cm)";
                lblMetric2.Text = "Weight (kg)";
                lblMetric3.Text = "Steps";
                picActivity.Image = Properties.Resources.walkingPic;
                
            }
            else if ( activity== "cycling")
            {
                
                lblMatric1.Text = "Distance(miles)";
                lblMetric2.Text = "Duration(minutes)";
                lblMetric3.Text = "Weight(kg)";

                txtMetric1.Visible = true;

                lblMetric4.Text = "Select your cycling terrain\nto calculate proper MET";
                lblMetric4.Location = new Point(23, 311);
                lblMetric4.Visible = true;

                listBoxManager.RerenderItems(listBoxMetric4, "hill", "not hill");
                listBoxMetric4.Visible = true;
                picActivity.Image = Properties.Resources.cyclingPic;
            }
            else if (activity == "running")
            {
                
                listBoxMetric4.Location = txtMetric1.Location;
                listBoxManager.RerenderItems(listBoxMetric4, "moderate", "fast", "very fast");
                listBoxMetric4.Visible = true;
                txtMetric1.Visible = false;

                lblMatric1.Text = "Choose Your Running Speed\n to calculate proper MET";
                lblMetric2.Text = "Duration(minutes)";
                lblMetric3.Text = "Weight(kg)";
                picActivity.Image = Properties.Resources.runningPic;

            }
            else if (activity == "rope skipping")
            {
                
                listBoxMetric4.Location = txtMetric1.Location;
                listBoxManager.RerenderItems(listBoxMetric4, "slow", "fast");
                listBoxMetric4.Visible = true;
                txtMetric1.Visible = false;

                lblMatric1.Text = "Choose Your Rope Jumping \nSpeed to Estimate MET";
                lblMetric2.Text = "Duration(minutes)";
                lblMetric3.Text = "Weight(kg)";
                picActivity.Image = Properties.Resources.ropeJumpingPic;

            }
            else if (activity == "aerobic")
            {
                
                listBoxMetric4.Location = txtMetric1.Location;
                listBoxManager.RerenderItems(
                    listBoxMetric4, 
                    "step:high impact", 
                    "step:low impact", 
                    "high impact", 
                    "low impact", 
                    "water");
                listBoxMetric4.Visible = true;
                txtMetric1.Visible = false;

                lblMatric1.Text = "Choose Your Aerobic Type \nto Estimate MET";
                lblMetric2.Text = "Duration(minutes)";
                lblMetric3.Text = "Weight(kg)";
                picActivity.Image = Properties.Resources.aerobicPic_removeBg_;

            }



        }

        //listening to the clicking event of the delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            response = MessageBox.Show("Delete?", "Information", MessageBoxButtons.YesNo);
            if (response == DialogResult.No) return;

            if (activity == "swimming")
            {
                SwimmingClass sc = new SwimmingClass(m1, m2, m3);
                sc.DeleteSwimmingActivity(mid, uid, aid);
                lblCalorieBurn.Text = "Success";


            }


            else if (activity == "walking")
            {
                WalkingClass wc = new WalkingClass(m1, m2, m3);
                wc.DeleteWalkingActivity(mid, uid, aid);
                lblCalorieBurn.Text = "Success";


            }

            else if (activity == "cycling")
            {
                string m4 = "";
                CyclingClass cyc = new CyclingClass(m1, m2, m3, m4);
                cyc.DeleteCyclingActivity(mid, uid, aid);
                lblCalorieBurn.Text = "Success";


            }
            else if (activity == "running")
            {

                RunningClass rc = new RunningClass(m1, m2, m3);
                rc.DeleteRunningActivity(mid, uid, aid);
                lblCalorieBurn.Text = "Success";


            }
            else if (activity == "rope skipping")
            {

                RopeSkippingClass rkc = new RopeSkippingClass(m1, m2, m3);
                rkc.DeleteRopeSkippingActivity(mid, uid, aid);
                lblCalorieBurn.Text = "Success";


            }
            else if (activity == "aerobic")
            {
                AerobicClass ac = new AerobicClass(m1, m2, m3);
                ac.DeleteAerobicActivity(mid, uid, aid);
                lblCalorieBurn.Text = "Success";
            }
            //------------------------


            FitnessClass ft = new FitnessClass();
            curCal = (float)ft.CurrentTotalCalories(uid);
            lblCurrentCalorie.Text = "Current Calorie=" + curCal;
            refresher();


        }


        //listening to the click event of the add new button
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            
            response = MessageBox.Show("Add new?", "Information", MessageBoxButtons.YesNo);
            if (response == DialogResult.No) return;

            if (activity == "swimming")
            {
                //checking validation
                if (validator.checkValidationForAll(txtMetric1, txtMetric2, txtMetric3))
                {
                    MessageBox.Show("Please enter all fields with numbers.Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                {
                    MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (validator.checkingIfInsideRange(txtMetric1, 2f, 13f))
                {
                    MessageBox.Show("Please enter the MET value correctly.\nIt should only be between 2 and 13", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //checking validation__________________

                m1 = float.Parse(txtMetric1.Text);
                m2 = float.Parse(txtMetric2.Text);
                m3 = float.Parse(txtMetric3.Text);

                SwimmingClass sc = new SwimmingClass(m1, m2, m3);
                curCal = sc.SwimmingActivity();
               
                int tarCal = GlobalData._targetCalorie;
                if (curCal >= tarCal)
                 MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                
                sc.InsertSwimmingActivity(uid, aid, m1, m2, m3, curCal);
                lblCalorieBurn.Text = "Success";

            }
            else if (activity == "walking")
            {
                //checking validation
                if (validator.checkValidationForAll(txtMetric1, txtMetric2, txtMetric3))
                {
                    MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (validator.checkingIfInsideRange(txtMetric2, 30f, 200f))
                {
                    MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(validator.checkingIfInsideRange(txtMetric1, 130f, 220f))
                {
                    MessageBox.Show("Please enter the height value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //checking validation___________________________

                m1 = float.Parse(txtMetric1.Text);
                m2 = float.Parse(txtMetric2.Text);
                m3 = float.Parse(txtMetric3.Text);

                WalkingClass wc = new WalkingClass(m1, m2, m3);
                curCal = wc.WalkingActivity();

                int tarCal = GlobalData._targetCalorie;
                if (curCal >= tarCal)
                    MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                wc.InsertWalkingActivity(uid, aid, m1, m2, m3, curCal);
                lblCalorieBurn.Text = "Success";
            }

            else if (activity == "cycling")
            {
                //checking validation
                if (validator.checkValidationForAll(txtMetric1, txtMetric2, txtMetric3))
                {
                    MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                {
                    MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //checking validation_______________________________

                m1 = float.Parse(txtMetric1.Text);
                m2 = float.Parse(txtMetric2.Text);
                m3 = float.Parse(txtMetric3.Text);
                
                string m4 = listBoxMetric4.SelectedItem.ToString();


                CyclingClass cyc = new CyclingClass(m1, m2, m3, m4);
                curCal = cyc.CyclingActivity();

                int tarCal = GlobalData._targetCalorie;
                if (curCal >= tarCal)
                    MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                cyc.InsertCyclingActivity(uid, aid, m1, m2, m3, curCal);
                lblCalorieBurn.Text = "Success";
                
                
                
                
            }

            else if (activity == "running")
            {
                //checking validation
                if (validator.checkValidationForAll(txtMetric2, txtMetric3))
                {
                    MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                {
                    MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //checking validation________________

                string speed = listBoxMetric4.SelectedItem.ToString();


                if (speed == "moderate")//calculating MET or m1 value according to the speed
                {
                    m1 = 9.8f;
                }
                else if (speed == "fast")
                {
                    m1 = 12.2f;
                }
                else if (speed == "very fast")
                {
                    m1 = 15.21f;
                }
                m2 = float.Parse(txtMetric2.Text);
                m3 = float.Parse(txtMetric3.Text);


                RunningClass rc = new RunningClass(m1, m2, m3);
                curCal = rc.RunningActivity();

                int tarCal = GlobalData._targetCalorie;
                if (curCal >= tarCal)
                    MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                rc.InsertRunningActivity(uid, aid, m1, m2, m3, curCal);
                lblCalorieBurn.Text = "Success";

            }
            else if (activity == "rope skipping")
            {
                //checking validation
                if (validator.checkValidationForAll(txtMetric2, txtMetric3))
                {
                    MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                {
                    MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //checking validation________________
                string speed = listBoxMetric4.SelectedItem.ToString();


                if (speed == "slow")//calculating MET or m1 according to the speed
                {
                    m1 = 7.6f;
                }
                else if (speed == "fast")
                {
                    m1 = 11.4f;
                }
                
                m2 = float.Parse(txtMetric2.Text);
                m3 = float.Parse(txtMetric3.Text);


                RopeSkippingClass rkc = new RopeSkippingClass(m1, m2, m3);
                curCal = rkc.RopeSkippingActivity();

                int tarCal = GlobalData._targetCalorie;
                if (curCal >= tarCal)
                    MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                rkc.InsertRopeSkippingActivity(uid, aid, m1, m2, m3, curCal);
                lblCalorieBurn.Text = "Success";

            } 
            else if (activity == "aerobic")
            {
                //checking validation
                if (validator.checkValidationForAll(txtMetric2, txtMetric3))
                {
                    MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                {
                    MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //checking validation__________________

                string aerobicType = listBoxMetric4.SelectedItem.ToString();
                if(aerobicType == "step:high impact")//calculating MET or m1 according to the aerobic type
                {
                    m1 = 9.7f;
                }
                else if (aerobicType == "step:low impact")
                {
                    m1 = 6.9f;
                }
                else if (aerobicType == "high impact")
                {
                    m1 = 6.9f;
                }
                else if (aerobicType == "low impact")
                {
                    m1 = 5.4f;
                }
                else if (aerobicType == "water")
                {
                    m1 = 4f;
                }

                m2 = float.Parse(txtMetric2.Text);
                m3 = float.Parse(txtMetric3.Text);

                AerobicClass ac = new AerobicClass(m1, m2, m3);
                curCal = ac.AerobicActivity();

                int tarCal = GlobalData._targetCalorie;
                if(curCal >= tarCal)
                {
                    MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);
                }

                ac.InsertAerobicActivity(uid, aid, m1, m2, m3, curCal);
                lblCalorieBurn.Text = "Success";
            }

            // ------------


            FitnessClass ft = new FitnessClass();
            curCal = (float)ft.CurrentTotalCalories(uid);
            lblCurrentCalorie.Text = "Current Calorie=" + curCal;
            refresher();
        }

   

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            response = MessageBox.Show("Update?", "Information", MessageBoxButtons.YesNo);
            if (response == DialogResult.No) return;


            try
            {

                DialogResult dr = MessageBox.Show("Are you certain that you really want to update this row ? ", "Update Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) 
                {
                    if (activity == "swimming")
                    {
                        //checking validation
                        if (validator.checkValidationForAll(txtMetric1, txtMetric2, txtMetric3))
                        {
                            MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                        {
                            MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric1, 2f, 13f))
                        {
                            MessageBox.Show("Please enter the MET value correctly.\nIt should only be between 2 and 13", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //checking validation____________________
                        m1 = float.Parse(txtMetric1.Text);
                        m2 = float.Parse(txtMetric2.Text);
                        m3 = float.Parse(txtMetric3.Text);

                        SwimmingClass sc = new SwimmingClass(m1, m2, m3);
                        curCal = sc.SwimmingActivity();

                        int tarCal = GlobalData._targetCalorie;
                        if (curCal >= tarCal)
                        {
                            MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                        }
                        
                        sc.UpdateSwimmingActivity(mid, uid, aid, m1, m2, m3, curCal);
                        lblCalorieBurn.Text = "Success";

                    }
                    else if (activity == "walking")
                    {
                        //checking validation
                        if (validator.checkValidationForAll(txtMetric1, txtMetric2, txtMetric3))
                        {
                            MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric2, 30f, 200f))
                        {
                            MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric1, 130f, 220f))
                        {
                            MessageBox.Show("Please enter the height value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //checking validation____________________

                        m1 = float.Parse(txtMetric1.Text);
                        m2 = float.Parse(txtMetric2.Text);
                        m3 = float.Parse(txtMetric3.Text);

                        WalkingClass wc = new WalkingClass(m1, m2, m3);
                        curCal = wc.WalkingActivity();

                        int tarCal = GlobalData._targetCalorie;
                        if (curCal >= tarCal)
                        {
                            MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                        }
                        wc.UpdateWalkingActivity(mid, uid, aid, m1, m2, m3, curCal);
                        lblCalorieBurn.Text = "Success";
                    }
                    else if (activity == "cycling")
                    {
                        //checking validation
                        if (validator.checkValidationForAll(txtMetric1, txtMetric2, txtMetric3))
                        {
                            MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                        {
                            MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //checking validation_____________________________

                        m1 = float.Parse(txtMetric1.Text);
                        m2 = float.Parse(txtMetric2.Text);
                        m3 = float.Parse(txtMetric3.Text);
                        string m4 = listBoxMetric4.SelectedItem.ToString();

                        CyclingClass cyc = new CyclingClass(m1, m2, m3, m4);
                        curCal = cyc.CyclingActivity();

                        int tarCal = GlobalData._targetCalorie;
                        if (curCal >= tarCal)
                            MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                        cyc.UpdateCyclingActivity(mid, uid, aid, m1, m2, m3, curCal);
                        lblCalorieBurn.Text = "Success";
                    }
                    else if (activity == "running")
                    {
                        //checking validation
                        if (validator.checkValidationForAll(txtMetric2, txtMetric3))
                        {
                            MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                        {
                            MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //checking validation__________________

                        string speed = listBoxMetric4.SelectedItem.ToString();

                        if (speed == "moderate")//calculating m1 according to the speed
                        {
                            m1 = 9.8f;
                        }
                        else if (speed == "fast")
                        {
                            m1 = 12.2f;
                        }
                        else if (speed == "very fast")
                        {
                            m1 = 15.21f;
                        }
                        m2 = float.Parse(txtMetric2.Text);
                        m3 = float.Parse(txtMetric3.Text);
                        

                        RunningClass rc = new RunningClass(m1, m2, m3);
                        curCal = rc.RunningActivity();

                        int tarCal = GlobalData._targetCalorie;
                        if (curCal >= tarCal)
                            MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                        rc.UpdateRunningActivity(mid, uid, aid, m1, m2, m3, curCal);
                        lblCalorieBurn.Text = "Success";
                    }
                    else if (activity == "rope skipping")
                    {
                        //checking validation
                        if (validator.checkValidationForAll(txtMetric2, txtMetric3))
                        {
                            MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                        {
                            MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //checking validation________________

                        string speed = listBoxMetric4.SelectedItem.ToString();

                        if (speed == "slow")//calculating m1 according to speed
                        {
                            m1 = 7.6f;
                        }
                        else if (speed == "fast")
                        {
                            m1 = 11.4f;
                        }

                        m2 = float.Parse(txtMetric2.Text);
                        m3 = float.Parse(txtMetric3.Text);


                        RopeSkippingClass rkc = new RopeSkippingClass(m1, m2, m3);
                        curCal = rkc.RopeSkippingActivity();

                        int tarCal = GlobalData._targetCalorie;
                        if (curCal >= tarCal)
                            MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);

                        rkc.UpdateRopeSkippingActivity(mid, uid, aid, m1, m2, m3, curCal);
                        lblCalorieBurn.Text = "Success";

                    }
                    else if (activity == "aerobic")
                    {
                        //checking validation
                        if (validator.checkValidationForAll(txtMetric2, txtMetric3))
                        {
                            MessageBox.Show("Please enter all fields with numbers..Only numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (validator.checkingIfInsideRange(txtMetric3, 30f, 200f))
                        {
                            MessageBox.Show("Please enter the weight value within possible ranges.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //checking validation_________________

                        string aerobicType = listBoxMetric4.SelectedItem.ToString();
                        if (aerobicType == "step:high impact")//calculating m1 according to aerobic type
                        {
                            m1 = 9.7f;
                        }
                        else if (aerobicType == "step:low impact")
                        {
                            m1 = 6.9f;
                        }
                        else if (aerobicType == "high impact")
                        {
                            m1 = 6.9f;
                        }
                        else if (aerobicType == "low impact")
                        {
                            m1 = 5.4f;
                        }
                        else if (aerobicType == "water")
                        {
                            m1 = 4f;
                        }

                        m2 = float.Parse(txtMetric2.Text);
                        m3 = float.Parse(txtMetric3.Text);

                        AerobicClass ac = new AerobicClass(m1, m2, m3);
                        curCal = ac.AerobicActivity();

                        int tarCal = GlobalData._targetCalorie;
                        if (curCal >= tarCal)
                        {
                            MessageBox.Show("Congratulations, your target calorie has been reached but you should carry on exercising.", "Good Job!!", MessageBoxButtons.OK);
                        }

                        ac.UpdateAerobicActivity(mid, uid, aid, m1, m2, m3, curCal);
                        lblCalorieBurn.Text = "Success";
                    }

                    //write other activities






                }
            }
            catch (Exception ee) { conn.Close(); };

            conn.Close();
           
            FitnessClass ft = new FitnessClass();
            curCal = (float)ft.CurrentTotalCalories(uid);
            lblCurrentCalorie.Text = "Current Calorie=" + curCal;
            refresher();

        }

        //function for refreshing the page
        private void refresher()
        {
            DBClass db = new DBClass();
            uid = GlobalData._UserId;
            int index = lstActivities.SelectedIndex + 1;
            dataGridView1.DataSource = db.getTable(uid, index);
            dataGridView1.DataMember = "UserActivityMatricTable";
        }

        
     }
 }

