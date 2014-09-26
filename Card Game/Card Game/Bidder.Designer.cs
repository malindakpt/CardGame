namespace Card_Game
{
    partial class Bidder
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.P1 = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.Label();
            this.P3 = new System.Windows.Forms.Label();
            this.P4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(309, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "I WON\'T BID MORE....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.trackBar1.Location = new System.Drawing.Point(2, 25);
            this.trackBar1.Maximum = 304;
            this.trackBar1.Minimum = 160;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(550, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 160;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(255, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Blue;
            this.progressBar1.ForeColor = System.Drawing.Color.Aqua;
            this.progressBar1.Location = new System.Drawing.Point(2, 0);
            this.progressBar1.Maximum = 304;
            this.progressBar1.Minimum = 60;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(550, 111);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 60;
            // 
            // P1
            // 
            this.P1.AutoSize = true;
            this.P1.BackColor = System.Drawing.Color.Blue;
            this.P1.ForeColor = System.Drawing.Color.White;
            this.P1.Location = new System.Drawing.Point(12, 76);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(58, 13);
            this.P1.TabIndex = 7;
            this.P1.Text = "PLAYER 1";
            // 
            // P2
            // 
            this.P2.AutoSize = true;
            this.P2.BackColor = System.Drawing.Color.Blue;
            this.P2.ForeColor = System.Drawing.Color.White;
            this.P2.Location = new System.Drawing.Point(81, 76);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(55, 13);
            this.P2.TabIndex = 8;
            this.P2.Text = "PLAYER2";
            // 
            // P3
            // 
            this.P3.AutoSize = true;
            this.P3.BackColor = System.Drawing.Color.Blue;
            this.P3.ForeColor = System.Drawing.Color.White;
            this.P3.Location = new System.Drawing.Point(154, 76);
            this.P3.Name = "P3";
            this.P3.Size = new System.Drawing.Size(55, 13);
            this.P3.TabIndex = 9;
            this.P3.Text = "PLAYER3";
            // 
            // P4
            // 
            this.P4.AutoSize = true;
            this.P4.BackColor = System.Drawing.Color.Blue;
            this.P4.ForeColor = System.Drawing.Color.White;
            this.P4.Location = new System.Drawing.Point(226, 76);
            this.P4.Name = "P4";
            this.P4.Size = new System.Drawing.Size(55, 13);
            this.P4.TabIndex = 10;
            this.P4.Text = "PLAYER4";
            // 
            // Bidder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 110);
            this.Controls.Add(this.P4);
            this.Controls.Add(this.P3);
            this.Controls.Add(this.P2);
            this.Controls.Add(this.P1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bidder";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bidder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Bidder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label P1;
        public System.Windows.Forms.Label P2;
        public System.Windows.Forms.Label P3;
        public System.Windows.Forms.Label P4;

    }
}