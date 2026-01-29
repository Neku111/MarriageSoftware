namespace MarriageParticipant.Extra
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            Label title;
            Label label1;
            kBtn = new Button();
            title = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title.Location = new Point(4, -7);
            title.Name = "title";
            title.Size = new Size(155, 46);
            title.TabIndex = 0;
            title.Text = "Marriage";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 39);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 0;
            label1.Text = "Cake!";
            // 
            // kBtn
            // 
            kBtn.Cursor = Cursors.WaitCursor;
            kBtn.FlatStyle = FlatStyle.Popup;
            kBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kBtn.Location = new Point(73, 33);
            kBtn.Name = "kBtn";
            kBtn.Size = new Size(74, 29);
            kBtn.TabIndex = 1;
            kBtn.Text = "k";
            kBtn.UseVisualStyleBackColor = true;
            // 
            // About
            // 
            AcceptButton = kBtn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = kBtn;
            ClientSize = new Size(146, 65);
            Controls.Add(kBtn);
            Controls.Add(label1);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            FormScreenCaptureMode = ScreenCaptureMode.HideContent;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            Padding = new Padding(12, 14, 12, 14);
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About me";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button kBtn;
    }
}
