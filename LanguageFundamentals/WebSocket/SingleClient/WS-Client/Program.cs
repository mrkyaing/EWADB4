using System.Net.WebSockets;
using System.Text;

var ws = new ClientWebSocket();
try
{
    Console.WriteLine("Connecting to server");
    await ws.ConnectAsync(new Uri("ws://localhost:6969/ws"), CancellationToken.None);
    Console.WriteLine("Connected!");
}
catch (Exception)
{
    Console.WriteLine("cant not connet to server ");
}
try
{
    var receiveTask = Task.Run(async () =>
 {
     var buffer = new byte[1024];
     while (true)
     {
         var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer),
             CancellationToken.None);
         if (result.MessageType == WebSocketMessageType.Close)
         {
             break;
         }
         var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
         Console.WriteLine("Recieved: " + message);

     }
 });
    await receiveTask;
}
catch (Exception)
{

    Console.WriteLine("error occur when received messages.");
}



