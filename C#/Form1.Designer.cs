namespace CSharpDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.SearchDeviceButton = new System.Windows.Forms.Button();
            this.DeviceIDTextBox = new System.Windows.Forms.TextBox();
            this.CreateDeviceButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.IPaddressTextBox = new System.Windows.Forms.TextBox();
            this.GetTimeButton = new System.Windows.Forms.Button();
            this.GetStorageStatusButton = new System.Windows.Forms.Button();
            this.GetNetStatusButton = new System.Windows.Forms.Button();
            this.GetBaseSettingButton = new System.Windows.Forms.Button();
            this.RemoteLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.CreateHeartbeatThreadButton = new System.Windows.Forms.Button();
            this.GetPlayBackFileListButton = new System.Windows.Forms.Button();
            this.GetChannelSettingButton = new System.Windows.Forms.Button();
            this.GetKeyControlSettingButton = new System.Windows.Forms.Button();
            this.GetNetSettingButton = new System.Windows.Forms.Button();
            this.GetSMDRSettingButton = new System.Windows.Forms.Button();
            this.GetUserListButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.UploadFileButton = new System.Windows.Forms.Button();
            this.DownloadFileButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(466, 12);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(445, 305);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.Text = "";
            // 
            // SearchDeviceButton
            // 
            this.SearchDeviceButton.Location = new System.Drawing.Point(10, 10);
            this.SearchDeviceButton.Name = "SearchDeviceButton";
            this.SearchDeviceButton.Size = new System.Drawing.Size(450, 23);
            this.SearchDeviceButton.TabIndex = 1;
            this.SearchDeviceButton.Text = "1、Search Device";
            this.SearchDeviceButton.UseVisualStyleBackColor = true;
            this.SearchDeviceButton.Click += new System.EventHandler(this.SearchDeviceButton_Click);
            // 
            // DeviceIDTextBox
            // 
            this.DeviceIDTextBox.Location = new System.Drawing.Point(100, 39);
            this.DeviceIDTextBox.Name = "DeviceIDTextBox";
            this.DeviceIDTextBox.Size = new System.Drawing.Size(214, 21);
            this.DeviceIDTextBox.TabIndex = 2;
            // 
            // CreateDeviceButton
            // 
            this.CreateDeviceButton.Location = new System.Drawing.Point(320, 39);
            this.CreateDeviceButton.Name = "CreateDeviceButton";
            this.CreateDeviceButton.Size = new System.Drawing.Size(140, 23);
            this.CreateDeviceButton.TabIndex = 3;
            this.CreateDeviceButton.Text = "3、Create Device";
            this.CreateDeviceButton.UseVisualStyleBackColor = true;
            this.CreateDeviceButton.Click += new System.EventHandler(this.CreateDeviceButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(78, 120);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(152, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "8、Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(100, 93);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(140, 21);
            this.UserNameTextBox.TabIndex = 5;
            this.UserNameTextBox.Text = "admin";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(320, 93);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(140, 21);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "2、Device ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "6、UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "7、Password";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(240, 120);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(220, 23);
            this.LogoutButton.TabIndex = 10;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "5、Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "4、IPaddress";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(320, 66);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(140, 21);
            this.PortTextBox.TabIndex = 12;
            // 
            // IPaddressTextBox
            // 
            this.IPaddressTextBox.Location = new System.Drawing.Point(100, 66);
            this.IPaddressTextBox.Name = "IPaddressTextBox";
            this.IPaddressTextBox.Size = new System.Drawing.Size(140, 21);
            this.IPaddressTextBox.TabIndex = 11;
            // 
            // GetTimeButton
            // 
            this.GetTimeButton.Location = new System.Drawing.Point(240, 178);
            this.GetTimeButton.Name = "GetTimeButton";
            this.GetTimeButton.Size = new System.Drawing.Size(220, 23);
            this.GetTimeButton.TabIndex = 15;
            this.GetTimeButton.Text = "Get Device Time";
            this.GetTimeButton.UseVisualStyleBackColor = true;
            this.GetTimeButton.Click += new System.EventHandler(this.GetTimeButton_Click);
            // 
            // GetStorageStatusButton
            // 
            this.GetStorageStatusButton.Location = new System.Drawing.Point(240, 149);
            this.GetStorageStatusButton.Name = "GetStorageStatusButton";
            this.GetStorageStatusButton.Size = new System.Drawing.Size(220, 23);
            this.GetStorageStatusButton.TabIndex = 16;
            this.GetStorageStatusButton.Text = "Get Storage Status";
            this.GetStorageStatusButton.UseVisualStyleBackColor = true;
            this.GetStorageStatusButton.Click += new System.EventHandler(this.GetStorageStatusButton_Click);
            // 
            // GetNetStatusButton
            // 
            this.GetNetStatusButton.Location = new System.Drawing.Point(10, 178);
            this.GetNetStatusButton.Name = "GetNetStatusButton";
            this.GetNetStatusButton.Size = new System.Drawing.Size(220, 23);
            this.GetNetStatusButton.TabIndex = 17;
            this.GetNetStatusButton.Text = "Get Net Status";
            this.GetNetStatusButton.UseVisualStyleBackColor = true;
            this.GetNetStatusButton.Click += new System.EventHandler(this.GetNetStatusButton_Click);
            // 
            // GetBaseSettingButton
            // 
            this.GetBaseSettingButton.Location = new System.Drawing.Point(240, 207);
            this.GetBaseSettingButton.Name = "GetBaseSettingButton";
            this.GetBaseSettingButton.Size = new System.Drawing.Size(220, 23);
            this.GetBaseSettingButton.TabIndex = 18;
            this.GetBaseSettingButton.Text = "Get Base Setting";
            this.GetBaseSettingButton.UseVisualStyleBackColor = true;
            this.GetBaseSettingButton.Click += new System.EventHandler(this.GetBaseSettingButton_Click);
            // 
            // RemoteLoginCheckBox
            // 
            this.RemoteLoginCheckBox.AutoSize = true;
            this.RemoteLoginCheckBox.Location = new System.Drawing.Point(12, 124);
            this.RemoteLoginCheckBox.Name = "RemoteLoginCheckBox";
            this.RemoteLoginCheckBox.Size = new System.Drawing.Size(60, 16);
            this.RemoteLoginCheckBox.TabIndex = 19;
            this.RemoteLoginCheckBox.Text = "Remote";
            this.RemoteLoginCheckBox.UseVisualStyleBackColor = true;
            this.RemoteLoginCheckBox.CheckedChanged += new System.EventHandler(this.RemoteLoginCheckBox_CheckedChanged);
            // 
            // CreateHeartbeatThreadButton
            // 
            this.CreateHeartbeatThreadButton.Location = new System.Drawing.Point(10, 149);
            this.CreateHeartbeatThreadButton.Name = "CreateHeartbeatThreadButton";
            this.CreateHeartbeatThreadButton.Size = new System.Drawing.Size(220, 23);
            this.CreateHeartbeatThreadButton.TabIndex = 20;
            this.CreateHeartbeatThreadButton.Text = "9、Create Heartbeat Thread";
            this.CreateHeartbeatThreadButton.UseVisualStyleBackColor = true;
            this.CreateHeartbeatThreadButton.Click += new System.EventHandler(this.CreateHeartbeatThreadButton_Click);
            // 
            // GetPlayBackFileListButton
            // 
            this.GetPlayBackFileListButton.Location = new System.Drawing.Point(10, 207);
            this.GetPlayBackFileListButton.Name = "GetPlayBackFileListButton";
            this.GetPlayBackFileListButton.Size = new System.Drawing.Size(220, 23);
            this.GetPlayBackFileListButton.TabIndex = 21;
            this.GetPlayBackFileListButton.Text = "Get Playback File List";
            this.GetPlayBackFileListButton.UseVisualStyleBackColor = true;
            this.GetPlayBackFileListButton.Click += new System.EventHandler(this.GetPlayBackFileListButton_Click);
            // 
            // GetChannelSettingButton
            // 
            this.GetChannelSettingButton.Location = new System.Drawing.Point(10, 236);
            this.GetChannelSettingButton.Name = "GetChannelSettingButton";
            this.GetChannelSettingButton.Size = new System.Drawing.Size(220, 23);
            this.GetChannelSettingButton.TabIndex = 22;
            this.GetChannelSettingButton.Text = "Get Channel Setting";
            this.GetChannelSettingButton.UseVisualStyleBackColor = true;
            this.GetChannelSettingButton.Click += new System.EventHandler(this.GetChannelSettingButton_Click);
            // 
            // GetKeyControlSettingButton
            // 
            this.GetKeyControlSettingButton.Location = new System.Drawing.Point(240, 236);
            this.GetKeyControlSettingButton.Name = "GetKeyControlSettingButton";
            this.GetKeyControlSettingButton.Size = new System.Drawing.Size(220, 23);
            this.GetKeyControlSettingButton.TabIndex = 23;
            this.GetKeyControlSettingButton.Text = "Get Key Control Setting";
            this.GetKeyControlSettingButton.UseVisualStyleBackColor = true;
            this.GetKeyControlSettingButton.Click += new System.EventHandler(this.GetKeyControlSettingButton_Click);
            // 
            // GetNetSettingButton
            // 
            this.GetNetSettingButton.Location = new System.Drawing.Point(10, 265);
            this.GetNetSettingButton.Name = "GetNetSettingButton";
            this.GetNetSettingButton.Size = new System.Drawing.Size(220, 23);
            this.GetNetSettingButton.TabIndex = 24;
            this.GetNetSettingButton.Text = "Get Net Setting";
            this.GetNetSettingButton.UseVisualStyleBackColor = true;
            this.GetNetSettingButton.Click += new System.EventHandler(this.GetNetSettingButton_Click);
            // 
            // GetSMDRSettingButton
            // 
            this.GetSMDRSettingButton.Location = new System.Drawing.Point(240, 265);
            this.GetSMDRSettingButton.Name = "GetSMDRSettingButton";
            this.GetSMDRSettingButton.Size = new System.Drawing.Size(220, 23);
            this.GetSMDRSettingButton.TabIndex = 25;
            this.GetSMDRSettingButton.Text = "Get SMDR Setting";
            this.GetSMDRSettingButton.UseVisualStyleBackColor = true;
            this.GetSMDRSettingButton.Click += new System.EventHandler(this.GetSMDRSettingButton_Click);
            // 
            // GetUserListButton
            // 
            this.GetUserListButton.Location = new System.Drawing.Point(10, 294);
            this.GetUserListButton.Name = "GetUserListButton";
            this.GetUserListButton.Size = new System.Drawing.Size(220, 23);
            this.GetUserListButton.TabIndex = 26;
            this.GetUserListButton.Text = "Get User List";
            this.GetUserListButton.UseVisualStyleBackColor = true;
            this.GetUserListButton.Click += new System.EventHandler(this.GetUserListButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(466, 323);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(445, 23);
            this.ProgressBar.TabIndex = 27;
            // 
            // UploadFileButton
            // 
            this.UploadFileButton.Location = new System.Drawing.Point(240, 294);
            this.UploadFileButton.Name = "UploadFileButton";
            this.UploadFileButton.Size = new System.Drawing.Size(220, 23);
            this.UploadFileButton.TabIndex = 28;
            this.UploadFileButton.Text = "Upload File To /PlayBackFiles";
            this.UploadFileButton.UseVisualStyleBackColor = true;
            this.UploadFileButton.Click += new System.EventHandler(this.UploadFileButton_Click);
            // 
            // DownloadFileButton
            // 
            this.DownloadFileButton.Location = new System.Drawing.Point(10, 323);
            this.DownloadFileButton.Name = "DownloadFileButton";
            this.DownloadFileButton.Size = new System.Drawing.Size(220, 23);
            this.DownloadFileButton.TabIndex = 29;
            this.DownloadFileButton.Text = "Download /1.txt To Memory";
            this.DownloadFileButton.UseVisualStyleBackColor = true;
            this.DownloadFileButton.Click += new System.EventHandler(this.DownloadFileButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Download /1.txt To Memory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DownloadFileButton);
            this.Controls.Add(this.UploadFileButton);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.GetUserListButton);
            this.Controls.Add(this.GetSMDRSettingButton);
            this.Controls.Add(this.GetNetSettingButton);
            this.Controls.Add(this.GetKeyControlSettingButton);
            this.Controls.Add(this.GetChannelSettingButton);
            this.Controls.Add(this.GetPlayBackFileListButton);
            this.Controls.Add(this.CreateHeartbeatThreadButton);
            this.Controls.Add(this.RemoteLoginCheckBox);
            this.Controls.Add(this.GetBaseSettingButton);
            this.Controls.Add(this.GetNetStatusButton);
            this.Controls.Add(this.GetStorageStatusButton);
            this.Controls.Add(this.GetTimeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.IPaddressTextBox);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.CreateDeviceButton);
            this.Controls.Add(this.DeviceIDTextBox);
            this.Controls.Add(this.SearchDeviceButton);
            this.Controls.Add(this.LogTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.Button SearchDeviceButton;
        private System.Windows.Forms.TextBox DeviceIDTextBox;
        private System.Windows.Forms.Button CreateDeviceButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox IPaddressTextBox;
        private System.Windows.Forms.Button GetTimeButton;
        private System.Windows.Forms.Button GetStorageStatusButton;
        private System.Windows.Forms.Button GetNetStatusButton;
        private System.Windows.Forms.Button GetBaseSettingButton;
        private System.Windows.Forms.CheckBox RemoteLoginCheckBox;
        private System.Windows.Forms.Button CreateHeartbeatThreadButton;
        private System.Windows.Forms.Button GetPlayBackFileListButton;
        private System.Windows.Forms.Button GetChannelSettingButton;
        private System.Windows.Forms.Button GetKeyControlSettingButton;
        private System.Windows.Forms.Button GetNetSettingButton;
        private System.Windows.Forms.Button GetSMDRSettingButton;
        private System.Windows.Forms.Button GetUserListButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button UploadFileButton;
        private System.Windows.Forms.Button DownloadFileButton;
        private System.Windows.Forms.Button button1;
    }
}

