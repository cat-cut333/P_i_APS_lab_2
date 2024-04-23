using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_i_APS_lab_2
{
    internal interface IServer_view
    {
        
        void Display_message_client_is_connected(string name_client);
        void Display_message_client_is_disconnected(string name_client);
        void Get_link_to_function_Get_namber_client(Func<int> function);
        void Print_message(string mes);



    }
}
