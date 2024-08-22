using System.Net.Sockets;

string host = "127.0.0.1";
int port = 5000;

using TcpClient client = new TcpClient();
await  client.ConnectAsync(host, port);
Console.WriteLine($"Us address {client.Client.LocalEndPoint}");

if (client.Connected)
    Console.WriteLine($"We a connect to server {client.Client.RemoteEndPoint}");
else
    Console.WriteLine("Nor connected");