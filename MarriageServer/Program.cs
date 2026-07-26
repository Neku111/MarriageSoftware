using MarriageServer;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using SuperSimpleTcp;

#region CONSTANTS
//const string _ipPort = "129.146.50.88:58008";
const string _ipPort = "0.0.0.0:58008";
//const string _ipPort = "localhost:58008";
string[] _certificates =
    [
        "{0} marryed {1} :D",
        "Marriage has happened!",
        "{0} married {1} at {2}",
        "{0} will have awsom honeymoon with {1}!!!!"
    ];
#endregion

#region Varble
Dictionary<string, Participant> participants = [];
Dictionary<string, string> connectionIDs = [];

bool started = false;
IPAddress publicIP = IPAddress.None;
IPAddress privateIP = IPAddress.None;
#endregion


#region Server Setup
SimpleTcpServer server = new(_ipPort);
server.Events.ClientConnected += OnConnected;
server.Events.ClientDisconnected += OnDisconnected;
server.Events.DataReceived += DataReceived;
server.Keepalive.EnableTcpKeepAlives = true;
server.Keepalive.TcpKeepAliveTime = 60;
server.Keepalive.TcpKeepAliveInterval = 30;
server.Keepalive.TcpKeepAliveInterval = 2;
server.Start();
OnStarted();

Console.WriteLine($"Started Listening at: {_ipPort}");


ReadInput();


// delay so no close
await Task.Delay(Timeout.Infinite);
#endregion


void OnStarted()
{
    started = true;

    Participant.Total = 0;

    Console.WriteLine("Marriage HAS Started!");

    Task<IPAddress?> ipTask = GetPublicIpAddress();
    GetPublicIpAddress().Wait();

    if (ipTask.Result == null)
    {
        Console.WriteLine("Could not get Public IP: Result was null");
        return;
    }

    if (ipTask.Status == TaskStatus.Faulted)
    {
        Console.WriteLine("Could not get Public IP: Task ran into error:" + ipTask.Exception);
        return;
    }

    publicIP = ipTask.Result;

    IPAddress? pIP = GetPrivateIpAddress();
    if (pIP == null)
    {
        Console.WriteLine("Could not get Private IP: Result was null");
        return;
    }

    privateIP = pIP;
}

void ReadInput()
{
    Stream stream = Console.OpenStandardInput(1024 * 8);
    Console.SetIn(new StreamReader(stream, Encoding.ASCII));

    string? input;
    CancellationTokenSource cts = new();

    while ((input = Console.ReadLine()) != null)
    {
        switch (input)
        {
            case "help":
                Console.WriteLine("Available Commands:");
                Console.WriteLine("    help");
                Console.WriteLine("    msg;name;message");
                Console.WriteLine("    flush");
                Console.WriteLine("    dump");
                Console.WriteLine("    list");
                Console.WriteLine("    total");
                Console.WriteLine("    stop");
                Console.WriteLine("    quit");
                break;

            case "flush":
                participants.Clear();
                connectionIDs.Clear();
                UpdateParticipantList();
                break;

            case "dump":
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Server Info Dump");
                Console.ResetColor();
                Console.WriteLine($"    Started: {started}");
                Console.WriteLine($"    Start Time: {server.Statistics.StartTime}");
                Console.WriteLine($"    Up Time: {server.Statistics.UpTime}");
                Console.WriteLine($"    Is Connected: {NetworkInterface.GetIsNetworkAvailable()}");
                Console.WriteLine($"    Listening: {server.IsListening}");
                Console.WriteLine($"    Server IP: {server.IpAddress}");
                Console.WriteLine($"    Server Port: {server.Port}");
                Console.WriteLine($"    Found Public IP: {publicIP}");
                Console.WriteLine($"    Found Private IP: {privateIP}");
                Console.WriteLine($"    Network Domain Name: {Environment.UserDomainName}");
                Console.WriteLine($"    Sent Bytes: {server.Statistics.SentBytes}");
                Console.WriteLine($"    Received Bytes: {server.Statistics.ReceivedBytes}");
                break;
            
            case "list":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Participant Count: [{participants.Count}]");
                Console.ResetColor();
                foreach (Participant p in participants.Values)
                {
                    Console.WriteLine(p.name);
                }
                break;

            case "total":
                Console.WriteLine($"Total Participants Joined: [{Participant.Total}]");
                break;

            case "stop":
            case "quit":
                Environment.Exit(0);
                return; // Stop the run thread

            default:
                switch (TrySendMessage(input))
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Message Sent!");
                        Console.ResetColor();
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("bad not all parameters found");
                        Console.ResetColor();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("couldnt find participant :(");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Command not found: \"{input}\"");
                        Console.ResetColor();
                        break;
                }
                break;
        }
    }
}

int TrySendMessage(string rawData)
{
    if (!rawData.StartsWith("msg"))
        return -1;

    string[] data = rawData.Split(';');
    if (data.Length != 3)
        return 1;

    if (!connectionIDs.TryGetValue(data[1], out string? ip))
        return 2;

    server.Send(ip, "MSG|" + data[2].Replace(',', '\n'));
    return 0;
}

void DataReceived(object? sender, DataReceivedEventArgs e)
{
    // All data should be formatted like this: [HEADER|DATA0;DATA1]

    string rawData = Encoding.UTF8.GetString(e.Data);
    string[] data = rawData.Split('|');

    switch (data[0])
    {
        case "JOIN":
            RequestJoin(e.IpPort, data[1]);
            break;

        case "RMARRY":
            RequestMarry(e.IpPort, data[1]);
            break;

        default:
            Console.WriteLine($"Recieved invalid data: No data definition found\n\"{rawData}\"");
            break;
    }
}

/// Data Format
/// PARTNERNAME
void RequestMarry(string selfIP, string partnerName)
{
    if (!participants.TryGetValue(selfIP, out Participant self))
    {
        Console.WriteLine($"Could not officiate wedding: Participant with connection ID [{selfIP}] does not exist");
        return;
    }

    Console.WriteLine($"Marriage Requested: \"{self.name}\" wishes to marry \"{partnerName}\"");

    if (!connectionIDs.TryGetValue(partnerName, out string? partnerID))
    {
        Console.WriteLine($"Could not officiate wedding: Parter [{partnerName}] does not exist");
        return;
    }

    ConfirmMarry(selfIP, partnerID);
}

void ConfirmMarry(string selfIP, string partnerIP)
{
    Console.WriteLine("Marriage Confirmed!");
    Console.WriteLine("Manifesting and Sending Certificate to Participants Involved");

    StringBuilder sb = new("CMARRY|");
    sb.Append(GetCertificateTemplate());
    sb.Append(',');
    sb.Append(participants[selfIP]);
    sb.Append(',');
    sb.Append(participants[partnerIP]);
    sb.Append(',');
    sb.Append(DateTime.UtcNow);
    sb.Append(" UTC");

    string data = sb.ToString();

    server.Send(selfIP, data);
    server.Send(partnerIP, data);
    Console.WriteLine("Certificates Sent!");
}

string GetCertificateTemplate()
{
    return _certificates[Random.Shared.Next(0, _certificates.Length)];
}

/// Data Format
/// NAME;COLOR
bool RequestJoin(string ip, string data)
{
    if (!Participant.TryParse(data, out Participant p))
    {
        Console.WriteLine($"Participant unable to join: Tried to parse invalid data\n[{data}]");
        return false;
    }

    Join(ip, p);
    return true;
}

void Join(string ip, Participant p)
{
    participants[ip] = p;
    connectionIDs[p.name] = ip;

    Console.WriteLine($"Connected Participant #{p.number}: [{p.name}]");
    UpdateParticipantList();

    server.Send(ip, $"NUM|{p.number}");
}

void OnDisconnected(object? sender, ConnectionEventArgs e)
{
    if (!participants.TryGetValue(e.IpPort, out Participant p))
    {
        Console.WriteLine("Failed to remove participant from list: Invalid Connection ID");
        return;
    }
    else participants.Remove(e.IpPort);

    string name = p.name;
    if (!connectionIDs.TryGetValue(p.name, out _))
    {
        Console.WriteLine("Failed to remove participant from list: Invalid Connection ID");
        return;
    }
    else connectionIDs.Remove(name);


    Console.WriteLine($"Disconnected Participant: [{name}]");
    UpdateParticipantList();
}

void OnConnected(object? sender, ConnectionEventArgs e)
{
    Console.WriteLine($"New Connection: [{e.IpPort}]");
}

void UpdateParticipantList()
{
    SendString_SYNCED("PLIST|" + string.Join(',', participants.Values));
}

void SendString_SYNCED(string str)
{
    foreach (string ip in participants.Keys)
    {
        server.Send(ip, str);
    }

    Console.WriteLine($"Broadcasted String To All Participants\n\"{str}\"");
}

static async Task<IPAddress?> GetPublicIpAddress()
{
    var externalIpString = (await new HttpClient().GetStringAsync("http://icanhazip.com"))
        .Replace("\\r\\n", "").Replace("\\n", "").Trim();
    if (!IPAddress.TryParse(externalIpString, out var ipAddress)) return null;
    return ipAddress;
}

static IPAddress? GetPrivateIpAddress()
{
    IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
    foreach (IPAddress ip in host.AddressList)
    {
        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            return ip;
    }

    return null;
}
