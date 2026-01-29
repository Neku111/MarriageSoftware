using System;

namespace Marriage
{
    partial class Preamble
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label welcomeLabel;
            System.Windows.Forms.GroupBox youBox;
            System.Windows.Forms.TableLayoutPanel youLayout;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label colorLabel;
            this.nameBox = new System.Windows.Forms.TextBox();
            this.colorBox = new System.Windows.Forms.Button();
            this.loginLeft = new System.Windows.Forms.Button();
            this.notification = new System.Windows.Forms.NotifyIcon(this.components);
            this.loginRight = new System.Windows.Forms.Button();
            this.colorPrompt = new System.Windows.Forms.ColorDialog();
            this.didYouKnowTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            welcomeLabel = new System.Windows.Forms.Label();
            youBox = new System.Windows.Forms.GroupBox();
            youLayout = new System.Windows.Forms.TableLayoutPanel();
            nameLabel = new System.Windows.Forms.Label();
            colorLabel = new System.Windows.Forms.Label();
            youBox.SuspendLayout();
            youLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            welcomeLabel.AutoSize = true;
            welcomeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            welcomeLabel.Location = new System.Drawing.Point(52, 9);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new System.Drawing.Size(449, 48);
            welcomeLabel.TabIndex = 1;
            welcomeLabel.Text = "Welcome to Marriage!";
            welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.didYouKnowTip.SetToolTip(welcomeLabel, "maryry");
            // 
            // youBox
            // 
            youBox.Controls.Add(youLayout);
            youBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            youBox.Location = new System.Drawing.Point(63, 79);
            youBox.Name = "youBox";
            youBox.Size = new System.Drawing.Size(414, 101);
            youBox.TabIndex = 6;
            youBox.TabStop = false;
            youBox.Text = "you";
            // 
            // youLayout
            // 
            youLayout.ColumnCount = 2;
            youLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            youLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 352F));
            youLayout.Controls.Add(this.nameBox, 1, 0);
            youLayout.Controls.Add(nameLabel, 0, 0);
            youLayout.Controls.Add(colorLabel, 0, 1);
            youLayout.Controls.Add(this.colorBox, 1, 1);
            youLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            youLayout.Location = new System.Drawing.Point(3, 23);
            youLayout.Name = "youLayout";
            youLayout.RowCount = 2;
            youLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            youLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            youLayout.Size = new System.Drawing.Size(408, 75);
            youLayout.TabIndex = 0;
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(59, 3);
            this.nameBox.MaxLength = 64;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(346, 27);
            this.nameBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(3, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(50, 32);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "name";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorLabel
            // 
            colorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            colorLabel.AutoSize = true;
            colorLabel.Location = new System.Drawing.Point(3, 32);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new System.Drawing.Size(50, 43);
            colorLabel.TabIndex = 2;
            colorLabel.Text = "color";
            colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorBox
            // 
            this.colorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorBox.BackColor = System.Drawing.Color.Chartreuse;
            this.colorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colorBox.ForeColor = System.Drawing.SystemColors.Control;
            this.colorBox.Location = new System.Drawing.Point(59, 35);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(346, 37);
            this.colorBox.TabIndex = 3;
            this.colorBox.UseVisualStyleBackColor = false;
            this.colorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // loginLeft
            // 
            this.loginLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loginLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLeft.Location = new System.Drawing.Point(12, 246);
            this.loginLeft.Name = "loginLeft";
            this.loginLeft.Size = new System.Drawing.Size(136, 30);
            this.loginLeft.TabIndex = 3;
            this.loginLeft.Text = "Login";
            this.loginLeft.UseVisualStyleBackColor = true;
            this.loginLeft.Click += new System.EventHandler(this.loginLeft_Click);
            // 
            // notification
            // 
            this.notification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notification.BalloonTipText = "YOU HAVE BEEN MARRIED";
            this.notification.BalloonTipTitle = "MARRIAGE ALERT";
            this.notification.Text = "MARRIAGE MARRIAGE MARRIAGE";
            this.notification.Visible = true;
            // 
            // loginRight
            // 
            this.loginRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loginRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginRight.Location = new System.Drawing.Point(389, 246);
            this.loginRight.Name = "loginRight";
            this.loginRight.Size = new System.Drawing.Size(136, 30);
            this.loginRight.TabIndex = 5;
            this.loginRight.Text = "Login";
            this.loginRight.UseVisualStyleBackColor = true;
            this.loginRight.Click += new System.EventHandler(this.loginRight_Click);
            // 
            // colorPrompt
            // 
            this.colorPrompt.FullOpen = true;
            this.colorPrompt.SolidColorOnly = true;
            // 
            // didYouKnowTip
            // 
            this.didYouKnowTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.didYouKnowTip.ToolTipTitle = "Did you know?";
            // 
            // Preamble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(544, 288);
            this.Controls.Add(youBox);
            this.Controls.Add(this.loginRight);
            this.Controls.Add(this.loginLeft);
            this.Controls.Add(welcomeLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Preamble";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marriage";
            this.Load += new System.EventHandler(this.Preamble_Load);
            youBox.ResumeLayout(false);
            youLayout.ResumeLayout(false);
            youLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loginLeft;
        private System.Windows.Forms.NotifyIcon notification;
        private System.Windows.Forms.Button loginRight;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ColorDialog colorPrompt;
        private System.Windows.Forms.Button colorBox;
        private System.Windows.Forms.ToolTip didYouKnowTip;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

