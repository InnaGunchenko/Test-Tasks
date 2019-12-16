namespace AppCountJobs
{
    partial class MainForm
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
            this.btCalculateJobs = new System.Windows.Forms.Button();
            this.tbJobsInput = new System.Windows.Forms.TextBox();
            this.cbCountrys = new System.Windows.Forms.ComboBox();
            this.cbLanguages = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCalculateJobs
            // 
            this.btCalculateJobs.Location = new System.Drawing.Point(106, 137);
            this.btCalculateJobs.Name = "btCalculateJobs";
            this.btCalculateJobs.Size = new System.Drawing.Size(112, 23);
            this.btCalculateJobs.TabIndex = 0;
            this.btCalculateJobs.Text = "Calculate jobs";
            this.btCalculateJobs.UseVisualStyleBackColor = true;
            this.btCalculateJobs.Click += new System.EventHandler(this.btCalculateJobs_Click);
            // 
            // tbJobsInput
            // 
            this.tbJobsInput.Location = new System.Drawing.Point(85, 88);
            this.tbJobsInput.Name = "tbJobsInput";
            this.tbJobsInput.Size = new System.Drawing.Size(59, 20);
            this.tbJobsInput.TabIndex = 1;
            this.tbJobsInput.MaxLength = 4;
            this.tbJobsInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbJobsInput_KeyPress);
            // 
            // cbCountrys
            // 
            this.cbCountrys.FormattingEnabled = true;
            this.cbCountrys.Location = new System.Drawing.Point(12, 52);
            this.cbCountrys.Name = "cbCountrys";
            this.cbCountrys.Size = new System.Drawing.Size(132, 21);
            this.cbCountrys.TabIndex = 2;
            // 
            // cbLanguages
            // 
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.Location = new System.Drawing.Point(185, 52);
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.Size = new System.Drawing.Size(121, 21);
            this.cbLanguages.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jobs input:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Countrys:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Languages:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 182);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLanguages);
            this.Controls.Add(this.cbCountrys);
            this.Controls.Add(this.tbJobsInput);
            this.Controls.Add(this.btCalculateJobs);
            this.Name = "MainForm";
            this.Text = "https://careers.veeam.com/";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCalculateJobs;
        private System.Windows.Forms.TextBox tbJobsInput;
        private System.Windows.Forms.ComboBox cbCountrys;
        private System.Windows.Forms.ComboBox cbLanguages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

