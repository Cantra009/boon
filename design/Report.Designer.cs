namespace design
{
    partial class Report
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
            this.btncomreport = new System.Windows.Forms.Button();
            this.btnprisonerreport = new System.Windows.Forms.Button();
            this.lblexit = new System.Windows.Forms.Label();
            this.btnfirreport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btncomreport
            // 
            this.btncomreport.BackColor = System.Drawing.Color.Fuchsia;
            this.btncomreport.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncomreport.ForeColor = System.Drawing.Color.White;
            this.btncomreport.Location = new System.Drawing.Point(12, 31);
            this.btncomreport.Name = "btncomreport";
            this.btncomreport.Size = new System.Drawing.Size(212, 55);
            this.btncomreport.TabIndex = 0;
            this.btncomreport.Text = "Complaint Report";
            this.btncomreport.UseVisualStyleBackColor = false;
            this.btncomreport.Click += new System.EventHandler(this.btncomreport_Click);
            // 
            // btnprisonerreport
            // 
            this.btnprisonerreport.BackColor = System.Drawing.Color.Fuchsia;
            this.btnprisonerreport.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprisonerreport.ForeColor = System.Drawing.Color.White;
            this.btnprisonerreport.Location = new System.Drawing.Point(240, 31);
            this.btnprisonerreport.Name = "btnprisonerreport";
            this.btnprisonerreport.Size = new System.Drawing.Size(212, 55);
            this.btnprisonerreport.TabIndex = 0;
            this.btnprisonerreport.Text = "Prisoner Report";
            this.btnprisonerreport.UseVisualStyleBackColor = false;
            this.btnprisonerreport.Click += new System.EventHandler(this.btnprisonerreport_Click);
            // 
            // lblexit
            // 
            this.lblexit.AutoSize = true;
            this.lblexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexit.ForeColor = System.Drawing.Color.Red;
            this.lblexit.Location = new System.Drawing.Point(484, 9);
            this.lblexit.Name = "lblexit";
            this.lblexit.Size = new System.Drawing.Size(39, 37);
            this.lblexit.TabIndex = 20;
            this.lblexit.Text = "X";
            this.lblexit.Click += new System.EventHandler(this.lblexit_Click);
            // 
            // btnfirreport
            // 
            this.btnfirreport.BackColor = System.Drawing.Color.Fuchsia;
            this.btnfirreport.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfirreport.ForeColor = System.Drawing.Color.White;
            this.btnfirreport.Location = new System.Drawing.Point(119, 110);
            this.btnfirreport.Name = "btnfirreport";
            this.btnfirreport.Size = new System.Drawing.Size(212, 55);
            this.btnfirreport.TabIndex = 0;
            this.btnfirreport.Text = "Fir Report";
            this.btnfirreport.UseVisualStyleBackColor = false;
            this.btnfirreport.Click += new System.EventHandler(this.btnfirreport_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(533, 230);
            this.Controls.Add(this.lblexit);
            this.Controls.Add(this.btnprisonerreport);
            this.Controls.Add(this.btnfirreport);
            this.Controls.Add(this.btncomreport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncomreport;
        private System.Windows.Forms.Button btnprisonerreport;
        private System.Windows.Forms.Label lblexit;
        private System.Windows.Forms.Button btnfirreport;
    }
}