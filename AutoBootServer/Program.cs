using System;
using System.Threading;

namespace AutoBootServer
{
    class Program
    {

        private Servidor server;
        private Thread escucha;

        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            escucha = new Thread(new ThreadStart(Escuchar));
            escucha.Start();
        }

        private void Escuchar()
        {
            server = new Servidor(434);
            while (true)
            {
                try
                {
                    Servidor.ReviseAServer(server);
                }
                catch (Exception)
                {

                }
            }
        }

        ~Program()
        {
            escucha.Join();
            server = null;
        }
    }
}
