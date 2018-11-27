using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestNetwork
{
    class SendSMS
    {
        //класс для отправки смс и получения результата
        private string login, password;
        private List<message> messages;
        private string adrServer;

        public SendSMS(List<message> messages)
        {
            login = "user1";
            password = "password_secret";
            adrServer = "192.168.0.56";

            //назначим уникальные id  в рамках пакета
            int id = 1;
            foreach(var messageObj in messages)
            {
                messageObj.id = id++;
            }
            this.messages = messages;
        }

        public async Task<List<message>> send()
        {
            var packageObj = new package(login, password, messages);
            package result = null;

            XmlSerializer formatter = new XmlSerializer(typeof(package));
            StringWriter textWriter = new StringWriter();
            
            using (XmlWriter xmlWriter = XmlWriter.Create(textWriter))
            {
                formatter.Serialize(xmlWriter, packageObj);
            }

            WebRequest request = WebRequest.Create(adrServer);
            request.Method = "POST"; 

            byte[] byteArray = Encoding.UTF8.GetBytes(textWriter.ToString());
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = (package)formatter.Deserialize(reader);
                    
                    if(result.error!=null)
                    {
                        Console.WriteLine("Фатальная ошибка: {0}", result.error);
                        result = null;
                    }
                }
            }
            response.Close();
            return (result!=null) ? result.send : null;
        }
    }

    [Serializable]
    public class message
    {
        //класс-модель для сообщения
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute("receiver")]
        public string phone { get; set; }
        [XmlAttribute]
        public string sender { get; set; }
        [XmlAttribute]
        public string server_id { get; set; }

        [XmlText]
        public string text { get; set; }

        public string error { get; set; }

        public message()
        {

        }

        public message(string phone, string sender, string text)
        {
            this.phone = phone;
            this.sender = sender;
            this.text = text;
        }
    }

    [Serializable]
    public class package
    {
        //класс-модель для пакета
        public List<message> send { get; set; }
        [XmlAttribute]
        public string login { get; set; }
        [XmlAttribute]
        public string password { get; set; }
        public string error { get; set; }

        public package()
        {

        }

        public package(string login, string password, List<message> send)
        {
            this.login = login;
            this.password = password;
            this.send = send;
        }
    }
}
