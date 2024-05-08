using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_i_APS_lab_2
{
    internal interface IServer_model
    {

        int Get_namber_client();
        void Add_client(string name_client, Socket socket_client);
        void Del_client(string name_client);
        void BroadcastMessage(string message, int flag);
        void Send_list_client(Socket tcpClient);
       
    }
}
