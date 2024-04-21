
namespace ZweFitnessTrackingAPP
{
    partial class ZweFitnessTrackingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZweFitnessTrackingForm));
            this.lstActivities = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTargetCal = new System.Windows.Forms.Label();
            this.lblMatric1 = new System.Windows.Forms.Label();
            this.txtMetric1 = new System.Windows.Forms.TextBox();
            this.lblMetric2 = new System.Windows.Forms.Label();
            this.lblMetric3 = new System.Windows.Forms.Label();
            this.txtMetric2 = new System.Windows.Forms.TextBox();
            this.txtMetric3 = new System.Windows.Forms.TextBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCalorieBurn = new System.Windows.Forms.Label();
            this.lblCurrentCalorie = new System.Windows.Forms.Label();
            this.listBoxMetric4 = new System.Windows.Forms.ListBox();
            this.lblMetric4 = new System.Windows.Forms.Label();
            this.picActivity = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAllActivities = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picActivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstActivities
            // 
            this.lstActivities.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstActivities.FormattingEnabled = true;
            this.lstActivities.ItemHeight = 21;
            this.lstActivities.Location = new System.Drawing.Point(259, 58);
            this.lstActivities.Name = "lstActivities";
            this.lstActivities.Size = new System.Drawing.Size(170, 46);
            this.lstActivities.TabIndex = 0;
            this.lstActivities.SelectedIndexChanged += new System.EventHandler(this.lstActivities_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose an Activity";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblUserName.Location = new System.Drawing.Point(23, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(99, 21);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "User Name=";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(871, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTargetCal
            // 
            this.lblTargetCal.AutoSize = true;
            this.lblTargetCal.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetCal.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTargetCal.Location = new System.Drawing.Point(402, 16);
            this.lblTargetCal.Name = "lblTargetCal";
            this.lblTargetCal.Size = new System.Drawing.Size(116, 21);
            this.lblTargetCal.TabIndex = 21;
            this.lblTargetCal.Text = "Target Calorie=";
            // 
            // lblMatric1
            // 
            this.lblMatric1.AutoSize = true;
            this.lblMatric1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatric1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblMatric1.Location = new System.Drawing.Point(23, 140);
            this.lblMatric1.Name = "lblMatric1";
            this.lblMatric1.Size = new System.Drawing.Size(63, 21);
            this.lblMatric1.TabIndex = 22;
            this.lblMatric1.Text = "Matric1";
            // 
            // txtMetric1
            // 
            this.txtMetric1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetric1.Location = new System.Drawing.Point(259, 140);
            this.txtMetric1.Name = "txtMetric1";
            this.txtMetric1.Size = new System.Drawing.Size(170, 29);
            this.txtMetric1.TabIndex = 23;
            // 
            // lblMetric2
            // 
            this.lblMetric2.AutoSize = true;
            this.lblMetric2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblMetric2.Location = new System.Drawing.Point(23, 196);
            this.lblMetric2.Name = "lblMetric2";
            this.lblMetric2.Size = new System.Drawing.Size(63, 21);
            this.lblMetric2.TabIndex = 24;
            this.lblMetric2.Text = "Metric2";
            // 
            // lblMetric3
            // 
            this.lblMetric3.AutoSize = true;
            this.lblMetric3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblMetric3.Location = new System.Drawing.Point(23, 253);
            this.lblMetric3.Name = "lblMetric3";
            this.lblMetric3.Size = new System.Drawing.Size(63, 21);
            this.lblMetric3.TabIndex = 25;
            this.lblMetric3.Text = "Metric3";
            // 
            // txtMetric2
            // 
            this.txtMetric2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetric2.Location = new System.Drawing.Point(259, 193);
            this.txtMetric2.Name = "txtMetric2";
            this.txtMetric2.Size = new System.Drawing.Size(170, 29);
            this.txtMetric2.TabIndex = 26;
            // 
            // txtMetric3
            // 
            this.txtMetric3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetric3.Location = new System.Drawing.Point(259, 245);
            this.txtMetric3.Name = "txtMetric3";
            this.txtMetric3.Size = new System.Drawing.Size(170, 29);
            this.txtMetric3.TabIndex = 27;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnAddNew.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNew.Location = new System.Drawing.Point(12, 406);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 40);
            this.btnAddNew.TabIndex = 28;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Location = new System.Drawing.Point(167, 406);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Location = new System.Drawing.Point(329, 406);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCalorieBurn
            // 
            this.lblCalorieBurn.AutoSize = true;
            this.lblCalorieBurn.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalorieBurn.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCalorieBurn.Location = new System.Drawing.Point(896, 16);
            this.lblCalorieBurn.Name = "lblCalorieBurn";
            this.lblCalorieBurn.Size = new System.Drawing.Size(107, 21);
            this.lblCalorieBurn.TabIndex = 36;
            this.lblCalorieBurn.Text = "Calorie Burn=";
            // 
            // lblCurrentCalorie
            // 
            this.lblCurrentCalorie.AutoSize = true;
            this.lblCurrentCalorie.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCalorie.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCurrentCalorie.Location = new System.Drawing.Point(643, 16);
            this.lblCurrentCalorie.Name = "lblCurrentCalorie";
            this.lblCurrentCalorie.Size = new System.Drawing.Size(127, 21);
            this.lblCurrentCalorie.TabIndex = 37;
            this.lblCurrentCalorie.Text = "Current Calorie=";
            // 
            // listBoxMetric4
            // 
            this.listBoxMetric4.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMetric4.FormattingEnabled = true;
            this.listBoxMetric4.ItemHeight = 21;
            this.listBoxMetric4.Location = new System.Drawing.Point(259, 311);
            this.listBoxMetric4.MaximumSize = new System.Drawing.Size(170, 25);
            this.listBoxMetric4.Name = "listBoxMetric4";
            this.listBoxMetric4.Size = new System.Drawing.Size(170, 25);
            this.listBoxMetric4.TabIndex = 38;
            // 
            // lblMetric4
            // 
            this.lblMetric4.AutoSize = true;
            this.lblMetric4.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMetric4.Location = new System.Drawing.Point(23, 283);
            this.lblMetric4.Name = "lblMetric4";
            this.lblMetric4.Size = new System.Drawing.Size(0, 21);
            this.lblMetric4.TabIndex = 39;
            // 
            // picActivity
            // 
            this.picActivity.Image = global::ZweFitnessTrackingAPP.Properties.Resources.swimming;
            this.picActivity.Location = new System.Drawing.Point(519, 268);
            this.picActivity.Name = "picActivity";
            this.picActivity.Size = new System.Drawing.Size(305, 244);
            this.picActivity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picActivity.TabIndex = 40;
            this.picActivity.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(519, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(710, 195);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // lblAllActivities
            // 
            this.lblAllActivities.AutoSize = true;
            this.lblAllActivities.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllActivities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblAllActivities.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblAllActivities.Location = new System.Drawing.Point(17, 463);
            this.lblAllActivities.Name = "lblAllActivities";
            this.lblAllActivities.Size = new System.Drawing.Size(138, 27);
            this.lblAllActivities.TabIndex = 42;
            this.lblAllActivities.TabStop = true;
            this.lblAllActivities.Text = "Watch All Activities";
            this.lblAllActivities.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAllActivities_LinkClicked);
            // 
            // ZweFitnessTrackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1320, 505);
            this.Controls.Add(this.lblAllActivities);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblMetric4);
            this.Controls.Add(this.listBoxMetric4);
            this.Controls.Add(this.lblCurrentCalorie);
            this.Controls.Add(this.lblCalorieBurn);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtMetric3);
            this.Controls.Add(this.txtMetric2);
            this.Controls.Add(this.lblMetric3);
            this.Controls.Add(this.lblMetric2);
            this.Controls.Add(this.txtMetric1);
            this.Controls.Add(this.lblMatric1);
            this.Controls.Add(this.lblTargetCal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstActivities);
            this.Controls.Add(this.picActivity);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1336, 544);
            this.MinimumSize = new System.Drawing.Size(1336, 544);
            this.Name = "ZweFitnessTrackingForm";
            this.Text = "Fitness Activity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZweFitnessTrackingForm_FormClosing);
            this.Load += new System.EventHandler(this.ZweFitnessTrackingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picActivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstActivities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTargetCal;
        private System.Windows.Forms.Label lblMatric1;
        private System.Windows.Forms.TextBox txtMetric1;
        private System.Windows.Forms.Label lblMetric2;
        private System.Windows.Forms.Label lblMetric3;
        private System.Windows.Forms.TextBox txtMetric2;
        private System.Windows.Forms.TextBox txtMetric3;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCalorieBurn;
        private System.Windows.Forms.Label lblCurrentCalorie;
        private System.Windows.Forms.ListBox listBoxMetric4;
        private System.Windows.Forms.Label lblMetric4;
        private System.Windows.Forms.PictureBox picActivity;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lblAllActivities;
    }
}