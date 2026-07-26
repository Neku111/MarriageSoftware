using MarriageParticipant.Extra;
using System.Diagnostics;
using System.Text;
using SuperSimpleTcp;
using MarriageParticipant.Forms;

namespace MarriageParticipant
{
    public partial class Ceremony : Form
    {
        private static Ceremony? instance;
        public static Ceremony Instance
        {
            get
            {
                instance ??= new();
                return instance;
            }
        }


        private string[] quarrels = [];
        private bool buggin = false;

        private bool ceremonyValid = false;

        private bool recievedNumber = false;
        private bool recievedList = false;
        private bool canMarry = false;

        private SimpleTcpClient client;
        private List<Button> buttonMap = [];

        delegate void d_UpdateButton(Button btn, Participant p);
        delegate void d_RemoveButton(Button btn);

        delegate void d_AddToPanel(Button btn);
        delegate void d_RemoveFromPanel(Button btn);

        delegate void d_SetInfoText(string text);
        delegate void d_SetDebugText(string text);

        delegate void d_LeaveCeremony();


        public Ceremony()
        {
            InitializeComponent();

            try
            {
                client = new(CeremonyInfo.ipPort);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Cannot connect to marriage: No Seremony with IP: [{CeremonyInfo.ipPort}]");
                Debug.WriteLine(e.Message);

                SetInfoText("NO SEREMONYFOUND");
                SetDebugText("THE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\n");
                SetStatusText("gungry for lovw");
                SetSpouseLabel("TERROR", Color.Red);
                ceremonyValid = false;
                return;
            }

            Debug.WriteLine($"Found Seremony with IP: [{CeremonyInfo.ipPort}]");
            ceremonyValid = true;
        }

        private void CreateButton(Participant p)
        {
            Button btn = new();
            btn.Size = new(1000, 50);
            btn.FlatStyle = FlatStyle.Popup;

            buttonMap.Add(btn);

            UpdateButton(btn, p);
            AddToPanel(btn);

            btn.Click += marryButton_Click;
        }

        private void AddToPanel(Button btn)
        {
            if (panel.InvokeRequired)
            {
                d_AddToPanel d = new(AddToPanel);
                Invoke(d, [btn]);
                return;
            }

            panel.SuspendLayout();
            panel.Controls.Add(btn);
            panel.RowStyles[panel.RowStyles.Count - 1].SizeType = SizeType.AutoSize;
            panel.ResumeLayout();
        }

        private void RemoveFromPanel(Button btn)
        {
            if (panel.InvokeRequired)
            {
                d_RemoveFromPanel d = new(RemoveFromPanel);
                Invoke(d, [btn]);
                return;
            }

            panel.SuspendLayout();
            panel.Controls.Remove(btn);
            panel.ResumeLayout();
        }

        private void UpdateButton(int idx)
        {
            if (idx >= buttonMap.Count)
            {
                Debug.WriteLine($"Could Not Update Button: Index [{idx}] is out of range"); return;
            }

            UpdateButton(buttonMap[idx], CeremonyInfo.participants[idx]);
        }

        private void UpdateButton(Button btn, Participant p)
        {
            if (btn.InvokeRequired)
            {
                d_UpdateButton d = new(UpdateButton);
                Invoke(d, [btn, p]);
                return;
            }

            btn.Text = p.name;
            btn.ForeColor = p.color;

            if (!canMarry)
            {
                overTip.SetToolTip(btn,
                #region thanking you
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n" +
                    "THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU THANK YOU \n");
                #endregion
                return;
            }

            didYouKnowTip.SetToolTip(btn, $"This participant is named {btn.Text}!");
        }

        private void RemoveButton(int idx)
        {
            if (idx >= buttonMap.Count)
            {
                Debug.WriteLine($"Could Not Remove Button: Index [{idx}] is out of range");
                UpdateParticipantButtons($"{new Participant("SOME", Color.Red, 1)},{new Participant("THING", Color.Red, 1)},{new Participant("WRONG", Color.Red, 1)},{new Participant(":(", Color.Blue, 1)}");
                return;
            }

            RemoveButton(buttonMap[idx]);
        }

        private void RemoveButton(Button btn)
        {
            if (btn == null)
            {
                Debug.WriteLine($"Could Not Remove Button: Button is null");
                return;
            }

            if (btn.InvokeRequired)
            {
                d_RemoveButton d = new(RemoveButton);
                Invoke(d, [btn]);
                return;
            }

            RemoveFromPanel(btn);
            buttonMap.Remove(btn);
            btn.Dispose();
        }

        private void marryButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;

            int idx = buttonMap.IndexOf(btn);
            if (idx < 0)
            {
                Debug.WriteLine($"Could not marry participant: Could not find button in button map");
                return;
            }

            if (idx >= CeremonyInfo.participants.Length || !canMarry)
            {
                CreateButton(new("XXXXXIT [IS] OVEROVERXXXXX", Color.Firebrick));
                return;
            }
            else
                RequestMarry(CeremonyInfo.participants[idx]);
        }

        private void RequestMarry(Participant partner)
        {
            if (!canMarry)
            {
                CreateButton(new("XXXXXIT [IS] OVEROVEROVER", Color.Firebrick));
                return;
            }

            client.Send($"RMARRY|{partner.name}");
        }

        private void UpdateButtons()
        {
            int buttonCount = buttonMap.Count;
            int participantCount = CeremonyInfo.participants.Length;

            int loopCount = Math.Max(buttonCount, participantCount);


            for (int i = 0; i < loopCount; i++)
            {
                if (i >= buttonMap.Count)
                    CreateButton(CeremonyInfo.participants[i]);
                else if (i < participantCount)
                    UpdateButton(i);
                else
                    RemoveButton(i);
            }
        }

        private void Ceremony_Load(object sender, EventArgs e)
        {
            quarrels = Environment.GetCommandLineArgs();
            HandleQuarrels();

            if (!ceremonyValid)
            {
                Debug.WriteLine($"Could not connect to marriage: ceremony is not valid: [{CeremonyInfo.ipPort}]");
                return;
            }

            SetInfoText("going!");
            SetSpouseLabel("TRAGEDY", Color.Red);

            client.Events.Connected += Client_OnConnected;
            client.Events.Disconnected += Client_OnDisconnected;
            client.Events.DataReceived += Client_OnDataReceived;

            try
            {
                client.Connect();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Cannot connect to marriage: No Seremony with IP: [{CeremonyInfo.ipPort}]");
                Debug.WriteLine(ex.Message);

                SetInfoText("NO SEREMONYFOUND");
                SetDebugText("THE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\nTHE HORRROR\n");
                SetStatusText("gungry for lovw");
                SetSpouseLabel("TERROR YOU ARE SCARED", Color.Red, false);
                ceremonyValid = false;
                return;
            }

            client.Keepalive.EnableTcpKeepAlives = true;
            client.Keepalive.TcpKeepAliveTime = 60;
            client.Keepalive.TcpKeepAliveInterval = 30;
            client.Keepalive.TcpKeepAliveInterval = 2;
        }

        private void HandleQuarrels()
        {
            Debug.WriteLine("Handling Quarrels");

            if (quarrels.Length <= 0) return;

            StringBuilder sb = new();

            foreach (string q in quarrels)
            {
                switch (q)
                {
                    case "bug":
                        buggin = true;
                        Text = "BUGTACULAR CEREMONY";
                        break;


                    default:
                        sb.AppendLine($"\n{q}\n is not a valid quarrel");
                        break;
                }
            }

            Debug.WriteLine(sb.ToString());
            Debug.WriteLine("Quarrels Handled");
        }

        private void Client_OnDataReceived(object? sender, SuperSimpleTcp.DataReceivedEventArgs e)
        {
            // All data should be formatted like this: HEADER|DATA0;DATA1;etc

            string rawData = Encoding.UTF8.GetString(e.Data);

            Debug.WriteLine($"Data Received: \"{rawData}\"");
            string[] data = rawData.Split('|');

            switch (data[0])
            {
                case "PLIST":
                    ParticipantListRecieved(data[1]);
                    break;

                case "NUM":
                    SetNumber(data[1]);
                    break;

                case "CMARRY":
                    ConfirmMarry(data[1]);
                    break;

                case "MSG":
                    SetDebugText(data[1]);
                    break;

                default:
                    Debug.WriteLine($"Recieved invalid data: No data definition found\n\"{rawData}\"");
                    break;
            }
        }

        /// Data Format
        /// NUMBER
        private void SetNumber(string data)
        {
            if (!int.TryParse(data, out int num))
            {
                Debug.WriteLine($"Could not parse recieved number: [{data}]");
                return;
            }

            CeremonyInfo.self.number = num;
            recievedNumber = true;

            TryUpdateButtonsWithRawData();
        }

        private void SetDebugText(string data)
        {
            if (debugText.InvokeRequired)
            {
                d_SetDebugText d = new(SetDebugText);
                Invoke(d, [data]);
                return;
            }

            debugText.Text = data;
        }

        private void TryUpdateButtonsWithRawData()
        {
            if (!(recievedList && recievedNumber)) return;

            UpdateParticipantButtons(CeremonyInfo.rawParticipantData);
        }

        private void ParticipantListRecieved(string data)
        {
            Debug.WriteLine($"Participant List Recieved: [{data}]");

            if (string.IsNullOrWhiteSpace(data))
            {
                if (data == null)
                    Debug.WriteLine("Could not update buttons: Data is null");
                else
                    Debug.WriteLine($"Could not update buttons: Data was whitespace");


                SetInfoText("):");
                SetDebugText("couldnt\ndo\nit\n:(");
                SetStatusText("):");

                Task.Delay(5000).Wait();

                Close();

                return;
            }

            recievedList = true;
            canMarry = true;
            SetRawParticipantDataAndUpdate(data);
        }

        private void SetRawParticipantDataAndUpdate(string data)
        {
            CeremonyInfo.rawParticipantData = data;

            TryUpdateButtonsWithRawData();
        }

        /// Data Format
        /// CERTIFICATE,SELFDATA,PARTNERDATA,DATETIME
        private void ConfirmMarry(string data)
        {
            string[] dataPieces = data.Split(',');

            Debug.WriteLine("Confirmed Marriage!");

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Certificate.txt");

            if (!Participant.TryParse(dataPieces[1], out Participant p1))
            {
                Debug.WriteLine($"Could not parse 1st participant in order to confirm marriage: \"{dataPieces[1]}\"");
                SetSpouseLabel("!!!!MYSTERY!!!!", Color.Black);
                return;
            }

            if (!Participant.TryParse(dataPieces[2], out Participant p2))
            {
                Debug.WriteLine($"Could not parse 2nd participant in order to confirm marriage: \"{dataPieces[2]}\"");
                SetSpouseLabel("!!!!MYSTERY!!!!", Color.Black);
                return;
            }

            if (p1 == CeremonyInfo.self)
            {
                SetSpouseLabel(p2);
                CeremonyInfo.spouse = p2;
            }
            else if (p2 == CeremonyInfo.self)
            {
                SetSpouseLabel(p1);
                CeremonyInfo.spouse = p1;
            }
            else
                SetSpouseLabel("!!!!MYSTERY!!!!", Color.Black);

            StringBuilder sb = new();
            sb.AppendLine(string.Format(dataPieces[0], p1.name, p2.name, dataPieces[3]));
            #region pending
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            #endregion
            sb.AppendLine("############################################");
            sb.AppendLine("   SPOUSE INFO - Know who you're marrying");
            sb.AppendLine("############################################");
            sb.AppendLine($"NAME: {CeremonyInfo.spouse.name}");
            sb.AppendLine($"COLOR: {CeremonyInfo.spouse.color}");
            sb.AppendLine($"FREQUENCY: {CeremonyInfo.spouse.GetFrequency()}");
            sb.AppendLine("############################################");
            sb.AppendLine("  LOVE!");

            File.WriteAllText(path, sb.ToString());
            Debug.WriteLine("Certificate Created To Commemorate This Special Thing!!");

            Console.Beep(CeremonyInfo.spouse.GetFrequency(), 50);
        }

        /// Data Format
        /// NAME1;COLOR1;NUMBER1,NAME2;COLOR2;NUMBER2,etc
        private void UpdateParticipantButtons(string data)
        {
            if (data == null)
            {
                Console.WriteLine("Could not update buttons with provided data: Data is null");

                CeremonyInfo.participants = [];
                UpdateButtons();
                return;
            }

            string[] strings = data.Split(',');

            List<Participant> participants = [];
            for (int i = 0; i < strings.Length; i++)
            {
                if (Participant.TryParse(strings[i], out Participant p))
                {
                    if (p != CeremonyInfo.self || p.number < 0)
                        participants.Add(p);
                    else Debug.WriteLine($"Excluded Participant From List: #{p.number}");
                }
                else
                {
                    SetDebugText(data);
                }
            }

            Console.WriteLine($"Participants Found: {participants.Count}");

            if (participants.Count <= 0)
            {

                CeremonyInfo.participants = [];
                SetInfoText("Nobody :(");
                SetStatusText(":(");
                UpdateButtons();
                return;
            }

            CeremonyInfo.participants = participants.Reverse<Participant>().ToArray();
            SetInfoText("Marry!");
            SetStatusText($"Participants waitng for YOUR love: {participants.Count}");
            UpdateButtons();
        }

        private void SetStatusText(string message)
        {
            participantCount.Text = message;
        }

        private void SetSpouseLabel(Participant p, bool autoFormat = true)
        {
            SetSpouseLabel(p.name, p.color, autoFormat);
        }

        private void SetSpouseLabel(string message, Color color, bool autoFormat = true)
        {
            if (autoFormat)
                spouseLabel.Text = $"Spouse = \"{message}\"";
            else
                spouseLabel.Text = message;

            spouseLabel.ForeColor = color;
        }

        private void Client_OnDisconnected(object? sender, ConnectionEventArgs e)
        {
            canMarry = false;
            Debug.WriteLine("MARRIAGE OVER THANK YOU");
            UpdateParticipantButtons($"{new Participant("MARRIAGE", Color.Red, 1)},{new Participant("OVER", Color.Red, 1)},{new Participant("THANK!", Color.Red, 1)}");
            SetInfoText("GO");
            SetDebugText("OVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER\nOVER");
            SetStatusText("MARRIAGE OVER THANK YOU");
        }

        private void Client_OnConnected(object? sender, ConnectionEventArgs e)
        {
            client.Send($"JOIN|{CeremonyInfo.self}");
            SetInfoText("getting them!");
        }

        private void SetInfoText(string message)
        {
            if (infoText.InvokeRequired)
            {
                d_SetInfoText d = new(SetInfoText);
                Invoke(d, [message]);
                return;
            }

            infoText.Text = message;
        }

        private void LeaveCeremony()
        {
            if (this.InvokeRequired)
            {
                d_LeaveCeremony d = new(LeaveCeremony);
                Invoke(d);
                return;
            }

            Close();
        }

        private void Ceremony_KeyDown(object sender, KeyEventArgs e)
        {
            if (!buggin)
                return;

            if (!e.KeyCode.ToString().StartsWith('F'))
                return;

            if (!int.TryParse(e.KeyCode.ToString()[1..], out int ger))
                return;

            StringBuilder sb = new();

            switch (e.KeyCode)
            {
                case Keys.F1:

                    sb.AppendLine("interesting daeat NETWORK");
                    sb.AppendLine("=================");
                    sb.AppendLine("");
                    sb.AppendLine($"Is Connected: {client.IsConnected}");
                    if (!client.IsConnected)break;

                    sb.AppendLine($"ServerIP: {client.ServerIpPort}");
                    sb.AppendLine($"Sent Bytes: {client.Statistics.SentBytes}");
                    sb.AppendLine($"Received Bytes: {client.Statistics.ReceivedBytes}");
                    break;

                case Keys.F2:

                    sb.AppendLine("PARTICIPANT DATA");
                    sb.AppendLine("=================");

                    foreach (Participant p in CeremonyInfo.participants)
                    {
                        sb.AppendLine(p.ToString());
                    }
                    sb.AppendLine("THIS CONCLUDES THE LIST OF PARTICIPANT DATA THANK YOU FOR COMING");
                    break;
                
                default: return;
            }

            Debug.WriteLine(sb.ToString());

            DEBUGFORM debug = new(sb.ToString());
            debug.ShowDialog();
        }
    }
}
