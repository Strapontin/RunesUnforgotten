using System.Diagnostics;
using System.Linq;
using System.Management;

namespace WindowsFormsApp1
{
    public static class ProcessResolver
    {
        public static string GetCommandLine(Process process)
        {
            using (var searcher = new ManagementObjectSearcher(
                $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}"))
            using (var objects = searcher.Get())
            {
                return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
            }
        }

        public static Process[] GetProcessesByName(string name)
        {
            return Process.GetProcessesByName(name);
        }
    }
}
