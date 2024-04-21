namespace ZweFitnessTrackingAPP
{
    partial class UserAndActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAndActivity));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBackToFitnessForm = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(352, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(225, 136);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnBackToFitnessForm
            // 
            this.btnBackToFitnessForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnBackToFitnessForm.Font = new System.Drawing.Font("Microsoft Uighur", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToFitnessForm.Location = new System.Drawing.Point(352, 300);
            this.btnBackToFitnessForm.Name = "btnBackToFitnessForm";
            this.btnBackToFitnessForm.Size = new System.Drawing.Size(230, 48);
            this.btnBackToFitnessForm.TabIndex = 1;
            this.btnBackToFitnessForm.Text = "Back to Fitness Form";
            this.btnBackToFitnessForm.UseVisualStyleBackColor = false;
            this.btnBackToFitnessForm.Click += new System.EventHandler(this.btnBackToFitnessForm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZweFitnessTrackingAPP.Properties.Resources.Vector_push_up_removeBg;
            this.pictureBox1.Location = new System.Drawing.Point(35, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 314);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblUserName.Location = new System.Drawing.Point(349, 63);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(35, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "label1";
            // 
            // UserAndActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(654, 447);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnBackToFitnessForm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(670, 486);
            this.MinimumSize = new System.Drawing.Size(670, 486);
            this.Name = "UserAndActivity";
            this.Text = "User And Activity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserAndActivity_FormClosing);
            this.Load += new System.EventHandler(this.UserAndActivity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBackToFitnessForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserName;
    }
}