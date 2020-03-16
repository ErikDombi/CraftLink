using CraftLink.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftLink
{
    public class CLink
    {
        public List<Server> Servers = new List<Server>();
        public string ServersDirectory;

        public CLink()
        {

        }

        public void MassInvokeCommand(string cmd)
        {
            foreach(Server server in Servers)
                server.InvokeCommand(cmd);
        }

        public void MassStop()
        {
            foreach (Server server in Servers)
                server.StopServer();
        }

        public Server CreateServer()
        {
            Server Server = new Server();
            Servers.Add(Server);
            return Servers.LastOrDefault();
        }

        public Server CreateServer(string Name)
        {
            Server Server = CreateServer();
            Server.Name = Name;
            return Server;
        }

        public Server CreateServer(string Name, int Memory)
        {
            Server Server = CreateServer(Name);
            Server.Memory = Memory;
            return Server;
        }

        public Server CreateServer(string Name, int Memory, string Directory)
        {
            Server Server = CreateServer(Name, Memory);
            Server.WorkingDirectory = Directory;
            return Server;
        }

        public Server CreateServer(string Name, int Memory, string Directory, string JarFile)
        {
            Server Server = CreateServer(Name, Memory, Directory);
            Server.JarFile = JarFile;
            return Server;
        }
    }
}
