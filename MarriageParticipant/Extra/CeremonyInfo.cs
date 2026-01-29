namespace MarriageParticipant.Extra
{
    public static class CeremonyInfo
    {
        public static Participant self;
        public static Participant spouse;
        public static Participant[] participants = [];

        public static string rawParticipantData;

        public const string DEFAULT_ipPort = "129.146.50.88:58008";
        public static string ipPort = DEFAULT_ipPort;
    }
}
