using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace TestNetwork
{
    class ListenHook
    {
        string ServerURI = "http://localhost:8080/signalr";
        private HubConnection Connection { get; set; }
        private IHubProxy HubProxy { get; set; }

        public ListenHook()
        {
            //HubProxy.Invoke("Send"); //UserName, TextBoxMessage.Text
        }

        public async System.Threading.Tasks.Task ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");

            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            HubProxy.On<string, string>("AddMessage", (name, message) =>
                Console.WriteLine(String.Format("{0}: {1}" + Environment.NewLine, name, message))
            );
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Unable to connect to server: Start server before connecting clients.");
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            Console.WriteLine("Connected to server at " + ServerURI + Environment.NewLine);
        }

        private void Connection_Closed()
        {
            Console.WriteLine("You have been disconnected");
        }
    }
}
