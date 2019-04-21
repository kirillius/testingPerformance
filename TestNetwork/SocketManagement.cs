using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebSocketSharp;

namespace TestNetwork
{
    class SocketManagement
    {
        public void Execute(CallBack listener)
        {
            var userId = new Random().Next(1, 1500);
            var ws = new WebSocket("ws://192.168.0.88:2300/socket.io/?userId=" + userId + "&transport=websocket");
            ws.Connect();

            ws.OnMessage += (sender, e) => {
                string stringForParse = PrepareMessageForParse(e.Data);
                Console.WriteLine("New message from server: " + stringForParse);

                try
                {
                    var parsingMessage = JsonConvert.DeserializeObject<string[]>(stringForParse);
                    if (searchActionStart(parsingMessage))
                    {
                        //значит пришел сигнал о начале экспериментов, нужно начать эксперимент
                        listener();
                    }
                }
                catch(Exception exp)
                {

                }
                
            };

            ws.OnOpen += (sender, e) => {
                Console.WriteLine("Socket connected");
            };

            ws.OnClose += (sender, e) => {
                Console.WriteLine("Socket disconnected");
            };
        }

        public string PrepareMessageForParse(string message)
        {
            string result = message;

            foreach (var symbol in result)
            {
                if (!symbol.Equals('{') & !symbol.Equals('['))
                {
                    result = result.Remove(0, 1);
                    continue;
                }

                break;
            }

            return result;
        }

        public bool searchActionStart(string[] parsingMessage)
        {
            foreach (var item in parsingMessage)
                if (item.Equals("startExperiment"))
                    return true;

            return false;
        }
    }
}
