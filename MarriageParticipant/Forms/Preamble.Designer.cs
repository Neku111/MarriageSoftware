using System;

namespace MarriageParticipant
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
            components = new System.ComponentModel.Container();
            Label welcomeLabel;
            GroupBox youBox;
            TableLayoutPanel youLayout;
            Label nameLabel;
            Label colorLabel;
            nameBox = new TextBox();
            colorBox = new Button();
            loginLeft = new Button();
            loginRight = new Button();
            colorPrompt = new ColorDialog();
            didYouKnowTip = new ToolTip(components);
            toolTip = new ToolTip(components);
            aboutBtn = new Button();
            marP = new TextBox();
            welcomeLabel = new Label();
            youBox = new GroupBox();
            youLayout = new TableLayoutPanel();
            nameLabel = new Label();
            colorLabel = new Label();
            youBox.SuspendLayout();
            youLayout.SuspendLayout();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.Top;
            welcomeLabel.AutoSize = true;
            welcomeLabel.FlatStyle = FlatStyle.Flat;
            welcomeLabel.Font = new Font("Microsoft Sans Serif", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeLabel.Location = new Point(62, 11);
            welcomeLabel.Margin = new Padding(4, 0, 4, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(449, 48);
            welcomeLabel.TabIndex = 1;
            welcomeLabel.Text = "Welcome to Marriage!";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            didYouKnowTip.SetToolTip(welcomeLabel, "maryry");
            // 
            // youBox
            // 
            youBox.Controls.Add(youLayout);
            youBox.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            youBox.Location = new Point(76, 99);
            youBox.Margin = new Padding(4);
            youBox.Name = "youBox";
            youBox.Padding = new Padding(4);
            youBox.Size = new Size(497, 107);
            youBox.TabIndex = 6;
            youBox.TabStop = false;
            youBox.Text = "you";
            // 
            // youLayout
            // 
            youLayout.ColumnCount = 2;
            youLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 67F));
            youLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 422F));
            youLayout.Controls.Add(nameBox, 1, 0);
            youLayout.Controls.Add(nameLabel, 0, 0);
            youLayout.Controls.Add(colorLabel, 0, 1);
            youLayout.Controls.Add(colorBox, 1, 1);
            youLayout.Dock = DockStyle.Fill;
            youLayout.Location = new Point(4, 25);
            youLayout.Margin = new Padding(4);
            youLayout.Name = "youLayout";
            youLayout.RowCount = 2;
            youLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            youLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            youLayout.Size = new Size(489, 78);
            youLayout.TabIndex = 0;
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nameBox.Cursor = Cursors.SizeAll;
            nameBox.Location = new Point(71, 4);
            nameBox.Margin = new Padding(4);
            nameBox.MaxLength = 64;
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(414, 28);
            nameBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(4, 0);
            nameLabel.Margin = new Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(59, 40);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "name";
            nameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // colorLabel
            // 
            colorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorLabel.AutoSize = true;
            colorLabel.Location = new Point(4, 40);
            colorLabel.Margin = new Padding(4, 0, 4, 0);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(59, 40);
            colorLabel.TabIndex = 2;
            colorLabel.Text = "color";
            colorLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // colorBox
            // 
            colorBox.BackColor = Color.Chartreuse;
            colorBox.Cursor = Cursors.SizeAll;
            colorBox.Dock = DockStyle.Fill;
            colorBox.FlatStyle = FlatStyle.Popup;
            colorBox.ForeColor = SystemColors.Control;
            colorBox.Location = new Point(71, 44);
            colorBox.Margin = new Padding(4);
            colorBox.Name = "colorBox";
            colorBox.Size = new Size(414, 32);
            colorBox.TabIndex = 3;
            colorBox.UseVisualStyleBackColor = false;
            colorBox.Click += colorBox_Click;
            // 
            // loginLeft
            // 
            loginLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loginLeft.Cursor = Cursors.SizeAll;
            loginLeft.FlatStyle = FlatStyle.Popup;
            loginLeft.Location = new Point(14, 308);
            loginLeft.Margin = new Padding(4);
            loginLeft.Name = "loginLeft";
            loginLeft.Size = new Size(163, 38);
            loginLeft.TabIndex = 3;
            loginLeft.Text = "Login";
            loginLeft.UseVisualStyleBackColor = true;
            loginLeft.Click += loginLeft_Click;
            // 
            // loginRight
            // 
            loginRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            loginRight.Cursor = Cursors.SizeAll;
            loginRight.FlatStyle = FlatStyle.Popup;
            loginRight.Location = new Point(467, 308);
            loginRight.Margin = new Padding(4);
            loginRight.Name = "loginRight";
            loginRight.Size = new Size(163, 38);
            loginRight.TabIndex = 5;
            loginRight.Text = "Login";
            loginRight.UseVisualStyleBackColor = true;
            loginRight.Click += loginRight_Click;
            // 
            // colorPrompt
            // 
            colorPrompt.FullOpen = true;
            colorPrompt.SolidColorOnly = true;
            // 
            // didYouKnowTip
            // 
            didYouKnowTip.IsBalloon = true;
            didYouKnowTip.ToolTipIcon = ToolTipIcon.Info;
            didYouKnowTip.ToolTipTitle = "Did you know?";
            // 
            // aboutBtn
            // 
            aboutBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            aboutBtn.Cursor = Cursors.SizeAll;
            aboutBtn.FlatAppearance.BorderSize = 20;
            aboutBtn.FlatStyle = FlatStyle.Popup;
            aboutBtn.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            aboutBtn.Location = new Point(295, 325);
            aboutBtn.Margin = new Padding(4);
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Size = new Size(77, 22);
            aboutBtn.TabIndex = 3;
            aboutBtn.Text = "education";
            toolTip.SetToolTip(aboutBtn, "Center Education");
            aboutBtn.UseVisualStyleBackColor = true;
            aboutBtn.Click += learn_Click;
            // 
            // marP
            // 
            marP.Cursor = Cursors.SizeAll;
            marP.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            marP.Location = new Point(202, 308);
            marP.MaxLength = 32;
            marP.Name = "marP";
            marP.PlaceholderText = "Marage Protocall - this DEFAULT";
            marP.Size = new Size(237, 22);
            marP.TabIndex = 7;
            // 
            // Preamble
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.Control;
            ClientSize = new Size(653, 360);
            Controls.Add(marP);
            Controls.Add(youBox);
            Controls.Add(loginRight);
            Controls.Add(aboutBtn);
            Controls.Add(loginLeft);
            Controls.Add(welcomeLabel);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Preamble";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marriage";
            TopMost = true;
            Load += Preamble_Load;
            youBox.ResumeLayout(false);
            youLayout.ResumeLayout(false);
            youLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loginLeft;
        private System.Windows.Forms.Button loginRight;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ColorDialog colorPrompt;
        private System.Windows.Forms.Button colorBox;
        private System.Windows.Forms.ToolTip didYouKnowTip;
        private System.Windows.Forms.ToolTip toolTip;
        private Button aboutBtn;
        private TextBox marP;
    }
}

