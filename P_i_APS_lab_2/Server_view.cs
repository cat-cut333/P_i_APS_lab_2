using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_i_APS_lab_2
{
    internal class Server_view : IServer_view
    {
        
        Func<int> namber_client;

        public void Display_message_client_is_connected(string name_client)
        {
            System.Console.WriteLine("Подключился новый клиент " + name_client);
            Display_number_of_clients(namber_client());


        }

        public void Display_message_client_is_disconnected(string name_client)
        {
            System.Console.WriteLine("Отключился клиент " + name_client);
            Display_number_of_clients(namber_client());
        }

        public void Display_number_of_clients(int count_client)
        {
            System.Console.WriteLine("К серверу подключенно клиентов - " + namber_client() );
        }

        public void Get_link_to_function_Get_namber_client(Func<int> function )

        {
            namber_client = function;
          
        }

        public void Print_message(string mes)
        {
            System.Console.WriteLine(mes);
        }
    }
}
