namespace Marriage
{
    partial class Ceremony
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
            System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
            this.marryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.marryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marriageBtn = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.addBtn = new System.Windows.Forms.Button();
            toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.marryContextMenu.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // marryContextMenu
            // 
            this.marryContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.marryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripTextBox1,
            this.toolStripSeparator1,
            this.marryToolStripMenuItem});
            this.marryContextMenu.Name = "marryContextMenu";
            this.marryContextMenu.Size = new System.Drawing.Size(211, 63);
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new System.Drawing.Size(150, 27);
            toolStripTextBox1.Text = "Below are option for you";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // marryToolStripMenuItem
            // 
            this.marryToolStripMenuItem.Name = "marryToolStripMenuItem";
            this.marryToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.marryToolStripMenuItem.Text = "Marry";
            // 
            // marriageBtn
            // 
            this.marriageBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.marriageBtn.ContextMenuStrip = this.marryContextMenu;
            this.marriageBtn.Location = new System.Drawing.Point(13, 13);
            this.marriageBtn.Name = "marriageBtn";
            this.marriageBtn.Size = new System.Drawing.Size(246, 41);
            this.marriageBtn.TabIndex = 0;
            this.marriageBtn.Text = "button1";
            this.marriageBtn.UseVisualStyleBackColor = true;
            this.marriageBtn.Visible = false;
            // 
            // panel
            // 
            this.panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel.AutoScroll = true;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.Controls.Add(this.marriageBtn);
            this.panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel.Location = new System.Drawing.Point(147, 42);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(10);
            this.panel.Size = new System.Drawing.Size(272, 67);
            this.panel.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addBtn.Location = new System.Drawing.Point(358, 798);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(246, 41);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Visible = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // Ceremony
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 851);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.panel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Ceremony";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ceremony";
            this.marryContextMenu.ResumeLayout(false);
            this.marryContextMenu.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip marryContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem marryToolStripMenuItem;
        private System.Windows.Forms.Button marriageBtn;
        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.Button addBtn;
    }
}