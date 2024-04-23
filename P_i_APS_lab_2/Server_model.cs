using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P_i_APS_lab_2
{

    class Client
    {
        string name;
        Socket socket;

        public string Get_name()
        {
            return name;
        }
        public Socket Get_Socket()
        {
            return socket;
        }
        public Client( string name, Socket socket)
        {
            this.socket = socket;
            this.name = name;
        }

    }
    internal class  Server_model : IServer_model
    {

       // object loker = new object();
        List<Client> arr_client;
        public Server_model()
        {
            arr_client = new List<Client>();
        }


       

        public void Add_client(string name_client, Socket socket_client)
        {
         
             arr_client.Add(new Client(name_client, socket_client)); 
        }

        public void BroadcastMessage(string message)
        {


            byte[] data_byte = Encoding.ASCII.GetBytes(message);
            Client client;

            for (int i = 0; i < arr_client.Count(); i++)
                {
                try
                {
                    client = arr_client[i];
                    client.Get_Socket().Send(data_byte);

                }
                catch
                {

                }
                    
            }
            

        }

        public void Del_client(string name_client)
        {
            Client client;

            for (int i = 0; i < arr_client.Count(); i++)
                {
                 client = arr_client[i];

                if (client.Get_name() == name_client)
                    {
                        arr_client.Remove(client);
                    }
                }
            
        }

        public int Get_namber_client()
        {
            return arr_client.Count();
        }

       
    }
}
