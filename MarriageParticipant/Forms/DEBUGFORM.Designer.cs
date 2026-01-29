namespace MarriageParticipant.Forms
{
    partial class DEBUGFORM
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
            msgBox = new RichTextBox();
            SuspendLayout();
            // 
            // msgBox
            // 
            msgBox.Dock = DockStyle.Fill;
            msgBox.Location = new Point(15, 14);
            msgBox.Name = "msgBox";
            msgBox.Size = new Size(458, 501);
            msgBox.TabIndex = 0;
            msgBox.Text = "";
            // 
            // DEBUGFORM
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 529);
            Controls.Add(msgBox);
            Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DEBUGFORM";
            Padding = new Padding(15, 14, 15, 14);
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterParent;
            Text = "BUG";
            TopMost = true;
            Load += DEBUGFORM_Load;
            ResumeLayout(false);

        }

        #endregion

        private RichTextBox msgBox;
    }
}
