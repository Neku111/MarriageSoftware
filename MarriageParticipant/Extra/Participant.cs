using System.Text;

namespace MarriageParticipant.Extra
{
    public struct Participant(string name = "INVALID", Color color = new(), int number = -1)
    {
        public string name = name;
        public Color color = color;
        public int number = number;


        public override string ToString()
        {
            StringBuilder sb = new(name);
            sb.Append(';');
            sb.Append(color.ToArgb());
            sb.Append(';');
            sb.Append(number);

            return sb.ToString();
        }

        public static bool TryParse(string s, out Participant p)
        {
            string[] data = s.Split(';');
            try
            {
                if (!int.TryParse(data[1], out int colorParse))
                {
                    p = new();
                    return false;
                }

                if (!int.TryParse(data[2], out int numberParse))
                {
                    p = new();
                    return false;
                }

                p = new(data[0], Color.FromArgb(colorParse), numberParse);
                return true;
            }
            catch (Exception)
            {
                p = new();
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Participant participant &&
                   name == participant.name &&
                   color.ToArgb().Equals(participant.color.ToArgb()) &&
                   number == participant.number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, color, number);
        }

        public static bool operator ==(Participant left, Participant right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Participant left, Participant right)
        {
            return !(left == right);
        }
    }
}
