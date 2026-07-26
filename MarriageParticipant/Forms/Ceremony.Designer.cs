namespace MarriageParticipant
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
            components = new System.ComponentModel.Container();
            Panel panelScroller;
            StatusStrip bottomToolbar;
            panel = new TableLayoutPanel();
            participantCount = new ToolStripStatusLabel();
            spouseLabel = new ToolStripStatusLabel();
            infoText = new Label();
            didYouKnowTip = new ToolTip(components);
            debugText = new Label();
            overTip = new ToolTip(components);
            panelScroller = new Panel();
            bottomToolbar = new StatusStrip();
            panelScroller.SuspendLayout();
            bottomToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // panelScroller
            // 
            panelScroller.AutoScroll = true;
            panelScroller.BorderStyle = BorderStyle.Fixed3D;
            panelScroller.Controls.Add(panel);
            panelScroller.Location = new Point(12, 79);
            panelScroller.Name = "panelScroller";
            panelScroller.Size = new Size(450, 529);
            panelScroller.TabIndex = 3;
            // 
            // panel
            // 
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.ColumnCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.RowCount = 1;
            panel.RowStyles.Add(new RowStyle());
            panel.Size = new Size(446, 0);
            panel.TabIndex = 2;
            // 
            // bottomToolbar
            // 
            bottomToolbar.ImageScalingSize = new Size(20, 20);
            bottomToolbar.Items.AddRange(new ToolStripItem[] { participantCount, spouseLabel });
            bottomToolbar.Location = new Point(0, 620);
            bottomToolbar.Name = "bottomToolbar";
            bottomToolbar.RightToLeft = RightToLeft.No;
            bottomToolbar.Size = new Size(474, 26);
            bottomToolbar.SizingGrip = false;
            bottomToolbar.TabIndex = 4;
            bottomToolbar.Text = "This is a bar";
            // 
            // participantCount
            // 
            participantCount.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            participantCount.BorderStyle = Border3DStyle.Sunken;
            participantCount.Name = "participantCount";
            participantCount.Size = new Size(239, 20);
            participantCount.Text = "Participants Waiting For Your Love: 0 :(";
            participantCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // spouseLabel
            // 
            spouseLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            spouseLabel.BorderStyle = Border3DStyle.Sunken;
            spouseLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            spouseLabel.Name = "spouseLabel";
            spouseLabel.RightToLeft = RightToLeft.No;
            spouseLabel.Size = new Size(181, 20);
            spouseLabel.Spring = true;
            spouseLabel.Text = "Spouse = OH MY GOD OH MY GOD OH MY GOD OH MY GOD OH MY GOD OH MY GOD OH MY GOD OH MY GOD";
            spouseLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // infoText
            // 
            infoText.AutoSize = true;
            infoText.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoText.Location = new Point(139, 11);
            infoText.Name = "infoText";
            infoText.Size = new Size(138, 46);
            infoText.TabIndex = 1;
            infoText.Text = "Marry!";
            // 
            // didYouKnowTip
            // 
            didYouKnowTip.IsBalloon = true;
            didYouKnowTip.ToolTipIcon = ToolTipIcon.Info;
            didYouKnowTip.ToolTipTitle = "Did you know?";
            // 
            // debugText
            // 
            debugText.AutoSize = true;
            debugText.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            debugText.Location = new Point(21, 25);
            debugText.Name = "debugText";
            debugText.Size = new Size(0, 29);
            debugText.TabIndex = 1;
            // 
            // overTip
            // 
            overTip.IsBalloon = true;
            overTip.UseAnimation = false;
            overTip.UseFading = false;
            // 
            // Ceremony
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 646);
            Controls.Add(bottomToolbar);
            Controls.Add(debugText);
            Controls.Add(panelScroller);
            Controls.Add(infoText);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Ceremony";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ceremony";
            TopMost = true;
            Load += Ceremony_Load;
            KeyDown += Ceremony_KeyDown;
            panelScroller.ResumeLayout(false);
            panelScroller.PerformLayout();
            bottomToolbar.ResumeLayout(false);
            bottomToolbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label infoText;
        private TableLayoutPanel panel;
        private ToolTip didYouKnowTip;
        private Label debugText;
        private ToolStripStatusLabel participantCount;
        private ToolTip overTip;
        private ToolStripStatusLabel spouseLabel;
    }
}