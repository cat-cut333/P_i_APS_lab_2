using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace P_i_APS_lab_2
{
    internal class Server_controller

    {

        IServer_view obj_server_View;
        IServer_model obj_server_Model;
        IPEndPoint ipPoint;
        Socket tcpListener;
        public bool Active = false;
        string IP;
        string Host;


    public Server_controller(object inter_view,object inter_model)
        {
            ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            tcpListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            obj_server_Model = (IServer_model)inter_model;
            obj_server_View = (IServer_view)inter_view;
         
            
        }
        
        public void Start_Server()
        {
            try
            {
               
                    tcpListener.Bind(ipPoint);
                    tcpListener.Listen(1000);
                    Active = true;
                    Host = System.Net.Dns.GetHostName();
                    IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();
                    obj_server_View.Print_message("Сервер запущен. Ожидание подключений... ");
                    obj_server_View.Get_link_to_function_Get_namber_client(seter_g);
                    new Thread(() => Listen_Server()).Start(); 
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public  void Listen_Server()
        {

            while (true)
            { 
            var tcpClient = tcpListener.Accept();
            if (tcpClient != null)
            {
                new Thread(() => ProcessClient(tcpClient)).Start();
                   
            }
        }
        }


        public  void ProcessClient(Socket tcpClient)
        {
           

            bool Active = true;
            byte[] data1 = new byte[1024] ;
            tcpClient.Receive(data1);
            string name_client = Encoding.ASCII.GetString(data1);
            name_client = name_client.Replace("\0", string.Empty);
            obj_server_View.Print_message("Клиент <<" + name_client+">> подключился");
            obj_server_Model.Add_client(name_client, tcpClient);

            while (Active)
            {
                try
                {
                   
                   if(tcpClient.Receive(data1)>0)
                    {
                        string someString = Encoding.ASCII.GetString(data1);
                        someString = someString.Replace("\0", string.Empty);
                        obj_server_Model.BroadcastMessage(someString);
                        obj_server_View.Print_message("Клиент <<" + name_client + ">> отправил сообщение");
                       
                    }
                   
                   
                }
                catch
                {
                    string someString2 = "Пользователь <<" + name_client + ">> покинул чат";
                    obj_server_Model.Del_client(name_client);
                    obj_server_Model.BroadcastMessage(someString2);
                    obj_server_View.Display_message_client_is_disconnected(name_client);
                    Active = false;

                }

    
            }
                
        }




        public  int seter_g()
        {
            return obj_server_Model.Get_namber_client(); 
        }

        
    }
}
