using System.Net;
using System.Net.Sockets;

string host = "127.0.0.1";
int port = 5000;

IPAddress localAddress = IPAddress.Parse(host);
IPEndPoint localEndPoint = new IPEndPoint(localAddress, port);

TcpListener listener = new TcpListener(IPAddress.Parse(host), port);
//TcpListener tcpListener = new TcpListener(localEndPoint);

try
{
    listener.Start();
    Console.WriteLine($"Server {listener.LocalEndpoint} waiting clients...");

    while (true)
    {
        using var client = await listener.AcceptTcpClientAsync();
        Console.WriteLine($"server accept client: {client.Client.RemoteEndPoint}");
    }
}
catch(Exception ex)
{
    Console.WriteLine($"{ex.Message}");
}
finally
{
    listener.Stop();
}
