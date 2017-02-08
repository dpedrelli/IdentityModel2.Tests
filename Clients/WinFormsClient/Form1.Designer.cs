namespace WinFormsClient
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtScope = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRedirectUri = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthority = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtBaseAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.lblAccessToken = new System.Windows.Forms.Label();
            this.lblRefreshToken = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCallResult = new System.Windows.Forms.TextBox();
            this.cboDefaultSettings = new System.Windows.Forms.ComboBox();
            this.cboBrowsers = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cboEndpoint = new System.Windows.Forms.ComboBox();
            this.rbGet = new System.Windows.Forms.RadioButton();
            this.rbPost = new System.Windows.Forms.RadioButton();
            this.lblIdentityToken = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboBrowsers);
            this.groupBox1.Controls.Add(this.cboDefaultSettings);
            this.groupBox1.Controls.Add(this.txtScope);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRedirectUri);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtClientSecret);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtClientId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAuthority);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 240);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  OidcClient Options  ";
            // 
            // txtScope
            // 
            this.txtScope.Location = new System.Drawing.Point(79, 98);
            this.txtScope.Name = "txtScope";
            this.txtScope.Size = new System.Drawing.Size(194, 20);
            this.txtScope.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Scope:";
            // 
            // txtRedirectUri
            // 
            this.txtRedirectUri.Location = new System.Drawing.Point(79, 126);
            this.txtRedirectUri.Name = "txtRedirectUri";
            this.txtRedirectUri.Size = new System.Drawing.Size(194, 20);
            this.txtRedirectUri.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Redirect Uri:";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Location = new System.Drawing.Point(79, 72);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.Size = new System.Drawing.Size(194, 20);
            this.txtClientSecret.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Client Secret:";
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(79, 46);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(194, 20);
            this.txtClientId.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Client Id:";
            // 
            // txtAuthority
            // 
            this.txtAuthority.Location = new System.Drawing.Point(79, 19);
            this.txtAuthority.Name = "txtAuthority";
            this.txtAuthority.Size = new System.Drawing.Size(194, 20);
            this.txtAuthority.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Authority:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPost);
            this.groupBox2.Controls.Add(this.rbGet);
            this.groupBox2.Controls.Add(this.cboEndpoint);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.txtBaseAddress);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(310, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 240);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "  Resource  ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(211, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Call";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtBaseAddress
            // 
            this.txtBaseAddress.Location = new System.Drawing.Point(96, 19);
            this.txtBaseAddress.Name = "txtBaseAddress";
            this.txtBaseAddress.Size = new System.Drawing.Size(190, 20);
            this.txtBaseAddress.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Base Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Endpoint:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblIdentityToken);
            this.groupBox3.Controls.Add(this.txtCallResult);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblRefreshToken);
            this.groupBox3.Controls.Add(this.lblAccessToken);
            this.groupBox3.Controls.Add(this.lblLoginStatus);
            this.groupBox3.Location = new System.Drawing.Point(12, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(594, 332);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "  Status  ";
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Location = new System.Drawing.Point(6, 18);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(95, 13);
            this.lblLoginStatus.TabIndex = 0;
            this.lblLoginStatus.Text = "Login Status:  N/A";
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Location = new System.Drawing.Point(6, 40);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(79, 13);
            this.lblAccessToken.TabIndex = 1;
            this.lblAccessToken.Text = "Access Token:";
            // 
            // lblRefreshToken
            // 
            this.lblRefreshToken.AutoSize = true;
            this.lblRefreshToken.Location = new System.Drawing.Point(4, 76);
            this.lblRefreshToken.Name = "lblRefreshToken";
            this.lblRefreshToken.Size = new System.Drawing.Size(81, 13);
            this.lblRefreshToken.TabIndex = 2;
            this.lblRefreshToken.Text = "Refresh Token:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Call Result:";
            // 
            // txtCallResult
            // 
            this.txtCallResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCallResult.Location = new System.Drawing.Point(79, 104);
            this.txtCallResult.Multiline = true;
            this.txtCallResult.Name = "txtCallResult";
            this.txtCallResult.ReadOnly = true;
            this.txtCallResult.Size = new System.Drawing.Size(505, 222);
            this.txtCallResult.TabIndex = 8;
            // 
            // cboDefaultSettings
            // 
            this.cboDefaultSettings.FormattingEnabled = true;
            this.cboDefaultSettings.Location = new System.Drawing.Point(79, 153);
            this.cboDefaultSettings.Name = "cboDefaultSettings";
            this.cboDefaultSettings.Size = new System.Drawing.Size(194, 21);
            this.cboDefaultSettings.TabIndex = 24;
            this.cboDefaultSettings.SelectedIndexChanged += new System.EventHandler(this.cboDefaultSettings_SelectedIndexChanged);
            // 
            // cboBrowsers
            // 
            this.cboBrowsers.FormattingEnabled = true;
            this.cboBrowsers.Location = new System.Drawing.Point(79, 180);
            this.cboBrowsers.Name = "cboBrowsers";
            this.cboBrowsers.Size = new System.Drawing.Size(194, 21);
            this.cboBrowsers.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Default:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Browser:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(198, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboEndpoint
            // 
            this.cboEndpoint.FormattingEnabled = true;
            this.cboEndpoint.Location = new System.Drawing.Point(96, 43);
            this.cboEndpoint.Name = "cboEndpoint";
            this.cboEndpoint.Size = new System.Drawing.Size(190, 21);
            this.cboEndpoint.TabIndex = 21;
            this.cboEndpoint.SelectedIndexChanged += new System.EventHandler(this.cboEndpoint_SelectedIndexChanged);
            // 
            // rbGet
            // 
            this.rbGet.AutoSize = true;
            this.rbGet.Checked = true;
            this.rbGet.Location = new System.Drawing.Point(96, 71);
            this.rbGet.Name = "rbGet";
            this.rbGet.Size = new System.Drawing.Size(42, 17);
            this.rbGet.TabIndex = 22;
            this.rbGet.TabStop = true;
            this.rbGet.Text = "Get";
            this.rbGet.UseVisualStyleBackColor = true;
            // 
            // rbPost
            // 
            this.rbPost.AutoSize = true;
            this.rbPost.Location = new System.Drawing.Point(144, 71);
            this.rbPost.Name = "rbPost";
            this.rbPost.Size = new System.Drawing.Size(46, 17);
            this.rbPost.TabIndex = 23;
            this.rbPost.Text = "Post";
            this.rbPost.UseVisualStyleBackColor = true;
            // 
            // lblIdentityToken
            // 
            this.lblIdentityToken.AutoSize = true;
            this.lblIdentityToken.Location = new System.Drawing.Point(5, 59);
            this.lblIdentityToken.Name = "lblIdentityToken";
            this.lblIdentityToken.Size = new System.Drawing.Size(78, 13);
            this.lblIdentityToken.TabIndex = 9;
            this.lblIdentityToken.Text = "Identity Token:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 594);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRedirectUri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtScope;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBaseAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblRefreshToken;
        private System.Windows.Forms.Label lblAccessToken;
        private System.Windows.Forms.TextBox txtCallResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDefaultSettings;
        private System.Windows.Forms.ComboBox cboBrowsers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboEndpoint;
        private System.Windows.Forms.RadioButton rbPost;
        private System.Windows.Forms.RadioButton rbGet;
        private System.Windows.Forms.Label lblIdentityToken;
    }
}

