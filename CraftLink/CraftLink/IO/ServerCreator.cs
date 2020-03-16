using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CraftLink.IO
{
    public class ServerCreator
    {
        public static Process SpawnServerProcess(string JavaDir, int Memory, string WorkingDirectory, string JarFile)
        {
            var _serverProcess = new Process();
            _serverProcess.StartInfo.FileName = Path.Combine(JavaDir, "java.exe");
            _serverProcess.StartInfo.Arguments = $"-Xmx{Memory}M -Xms{Memory}M -jar {Path.Combine(WorkingDirectory, JarFile)} nogui";
            _serverProcess.StartInfo.WorkingDirectory = WorkingDirectory;
            _serverProcess.StartInfo.UseShellExecute = false;
            _serverProcess.StartInfo.RedirectStandardOutput = true;
            _serverProcess.StartInfo.RedirectStandardInput = true;
            _serverProcess.StartInfo.RedirectStandardError = true;
            _serverProcess.StartInfo.CreateNoWindow = true;
            return _serverProcess;
        }
    }
}
