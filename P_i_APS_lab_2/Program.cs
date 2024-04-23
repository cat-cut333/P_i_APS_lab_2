using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace P_i_APS_lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server_view a = new Server_view();
           
            Server_model b = new Server_model();
            Server_controller cont = new  Server_controller(a,b);
            cont.Start_Server();
            

            

        }
    }
}
