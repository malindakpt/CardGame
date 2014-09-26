namespace Card_Game
{
    partial class JoinGame
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
            this.cmbGames = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmbGames
            // 
            this.cmbGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGames.FormattingEnabled = true;
            this.cmbGames.Items.AddRange(new object[] {
            "--SELECT A GAME--"});
            this.cmbGames.Location = new System.Drawing.Point(12, 15);
            this.cmbGames.Name = "cmbGames";
            this.cmbGames.Size = new System.Drawing.Size(340, 24);
            this.cmbGames.TabIndex = 0;
            this.cmbGames.SelectedIndexChanged += new System.EventHandler(this.cmbGames_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(373, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "JOIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 50);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(158, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "Type Your Email";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(176, 50);
            this.txtName.MaxLength = 10;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "Your Name";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.ForeColor = System.Drawing.Color.DarkRed;
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(424, 9);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(94, 13);
            this.linkLabel2.TabIndex = 102;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Create New Game";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // JoinGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(533, 86);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbGames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JoinGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JoinGame";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.JoinGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGames;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}