using System.Xml;

namespace MarriageParticipant.Forms
{
    partial class DEBUGFORM : Form
    {
        delegate void d_Output(string msg);

        readonly string msg = "NOT MSG COMPLIANT";

        public DEBUGFORM()
        {
            InitializeComponent();
        }

        public DEBUGFORM(string message)
        {
            InitializeComponent();
            msg = message;
        }

        void DEBUGFORM_Load(object sender, EventArgs e)
        {
            Output(msg);
        }

        public void Output(string message)
        {
            if (msgBox.InvokeRequired)
            {
                d_Output d = new(Output);
                Invoke(d, [message]);
                return;
            }

            msgBox.Text = message;
        }

    }
}
