namespace MarriageParticipant
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            Preamble preamble = new Preamble();
            if (preamble.ShowDialog() != DialogResult.OK)
                return;

            Application.Run(Ceremony.Instance);
        }
    }
}
