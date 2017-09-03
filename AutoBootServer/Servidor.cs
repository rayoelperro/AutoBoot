using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AutoBootServer
{
    class Servidor
    {
        public TcpListener escucha;

        public Servidor(int port)
        {
            escucha = new TcpListener(IPAddress.Any, port);
            escucha.Start();
        }

        public TcpClient Entrada()
        {
            return escucha.AcceptTcpClient();
        }

        public string IpCliente(TcpClient client)
        {
            IPEndPoint ipep = (IPEndPoint)client.Client.RemoteEndPoint;
            return ipep.Address.ToString();
        }

        public string Mensaje(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            return new StreamReader(stream).ReadToEnd();
        }

        public static void ReviseAServer(Servidor sv)
        {
            TcpClient cl = sv.Entrada();
            string msg = sv.Mensaje(cl);
            Backexe.CompileCode(msg);
        }
    }
}
