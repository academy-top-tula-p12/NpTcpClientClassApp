using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

string host = "yandex.ru";
int port = 80;

using TcpClient tcpClient = new();
var stream = tcpClient.GetStream();

try
{
    await tcpClient.ConnectAsync(host, port);
    Console.WriteLine($"We a connected to host");

    string getMessage = $"GET /events HTTP/1.1\r\nHost: {host}\r\nConnection: close\r\n\r\n";
    byte[] getBuffer = Encoding.UTF8.GetBytes(getMessage);

    await stream.WriteAsync(getBuffer, 0, getBuffer.Length);

    byte[] responseBuffer = new byte[1024];
    StringBuilder responseText = new();
    int bytesCountStream;

    do
    {
        bytesCountStream = await stream.ReadAsync(responseBuffer);
        responseText.Append(Encoding.UTF8.GetString(responseBuffer));

    } while (bytesCountStream > 0);

    Console.WriteLine(responseText);
}
catch(Exception ex)
{
    Console.WriteLine($"Connection error: {ex.Message}");
}
