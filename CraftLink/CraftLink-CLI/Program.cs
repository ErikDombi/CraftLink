using System;
using CraftLink;
using CraftLink.Types;

namespace CraftLink_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            CLink CL = new CLink();
            Server _server = CL.CreateServer("Main Server", 2048, @"F:\Servers\1364307782", "server.jar");
            _server.StartServer();
            Console.ReadLine();
            CL.MassStop();
            Console.ReadLine();
        }
    }
}
