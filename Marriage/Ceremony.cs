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
    public partial class Ceremony : Form
    {
        private static Ceremony instance;
        public static Ceremony Instance
        {
            get
            {
                if (instance == null) 
            }
        }

        public Ceremony()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Text = "gangreen";
            panel.Controls.Add(btn);
        }
    }
}
