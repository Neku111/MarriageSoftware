using MarriageParticipant.Extra;
using System.Text;

namespace MarriageParticipant
{
    public partial class Preamble : Form
    {
        private void loginRight_Click(object sender, EventArgs e) => TryLogin();
        private void loginLeft_Click(object sender, EventArgs e) => TryLogin();

        public Preamble()
        {
            InitializeComponent();
        }

        private void Preamble_Load(object sender, EventArgs e)
        {
            #region Tooltips
            toolTip.SetToolTip(nameBox, "Center Name");
            toolTip.SetToolTip(colorBox, "Center Color");

            toolTip.SetToolTip(loginLeft, "Left Login");
            toolTip.SetToolTip(loginRight, "Right Login");
            toolTip.SetToolTip(marP, "I have no idea if this works");
            #endregion
        }

        private void colorBox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new();

            if (cd.ShowDialog() == DialogResult.OK)
                colorBox.BackColor = cd.Color;
        }

        private void TryLogin()
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("ENTER NAME", "MARRIAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (nameBox.Text.Contains(';') || nameBox.Text.Contains(','))
            {
                MessageBox.Show("NOOOOOOOO", "DO NOT USE ; OR ,", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StringBuilder sb = new(nameBox.Text);
                sb.Replace(";", string.Empty);
                sb.Replace(",", string.Empty);
                nameBox.Text = sb.ToString();
                return;
            }

            
            CeremonyInfo.self = new(nameBox.Text, colorBox.BackColor);

            if (string.IsNullOrEmpty(marP.Text))
                CeremonyInfo.ipPort = CeremonyInfo.DEFAULT_ipPort;
            else
                CeremonyInfo.ipPort = marP.Text + ":58008";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void learn_Click(object sender, EventArgs e)
        {
            About abt = new();
            abt.ShowDialog();
        }
    }
}