using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marriage
{
    public partial class Preamble : Form
    {
        public Preamble()
        {
            InitializeComponent();
        }

        private void Preamble_Load(object sender, EventArgs e)
        {
            #region Tooltips
            toolTip.SetToolTip(colorBox, "Center Color");

            toolTip.SetToolTip(loginLeft, "Left Login");
            toolTip.SetToolTip(loginRight, "Right Login");
            #endregion
        }

        private void colorBox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                colorBox.BackColor = cd.Color;
            }
        }

        private void loginRight_Click(object sender, EventArgs e)
        {
            TryLogin();
        }

        private void loginLeft_Click(object sender, EventArgs e)
        {
            TryLogin();
        }

        private void TryLogin()
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("ENTER NAME", "MARRIAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ParticipantInfo.Name = nameBox.Text;
            ParticipantInfo.Color = colorBox.BackColor;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}