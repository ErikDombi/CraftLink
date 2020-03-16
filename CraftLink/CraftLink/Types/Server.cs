using CraftLink.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CraftLink.Types
{
    public class Server
    {
        private Process _serverProcess = new Process();
        private const string JavaDir = @"C:\Program Files (x86)\Common Files\Oracle\Java\javapath\";

        public string Name;
        public int Memory;
        public string WorkingDirectory;
        public string JarFile;

        public void StartServer()
        {
            SpawnProcess();
        }

        public void SpawnProcess()
        {
            _serverProcess = ServerCreator.SpawnServerProcess(JavaDir, Memory, WorkingDirectory, JarFile);
            _serverProcess.OutputDataReceived += stdout;
            _serverProcess.ErrorDataReceived += stderr;
            _serverProcess.Start();
            _serverProcess.BeginOutputReadLine();
            _serverProcess.BeginErrorReadLine();
        }

        public void InvokeCommand(string cmd) => _serverProcess.StandardInput.WriteLine(cmd);

        public void StopServer()
        {
            InvokeCommand("stop");
        }

        private void stderr(object sender, DataReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[#] " + e.Data);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void stdout(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("[#] " + e.Data);
        }
    }
}
