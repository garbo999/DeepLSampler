using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLSampler
{
    class Logger
    {
        private string filename;
        private StreamWriter fileStream;

        public Logger(string fn)
        {
            Console.WriteLine("filename:" + filename);

            filename = fn;

            //using (var fileStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            //var fileStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            fileStream = File.AppendText(filename);
        }

        public void WriteLine(string s, Boolean with_timestamp)
        {
            if (with_timestamp)
            {
                fileStream.WriteLine("   " + DateTime.Now + ": " + s);
            }
            else
            {
                fileStream.WriteLine("   " + s);
            }
        }

        public void WriteFileHeader()
        {
            string dotNetVersion = Get45or451FromRegistry();

            fileStream.WriteLine("************************************");
            fileStream.WriteLine("****** DeepL Sampler LOG FILE ******");
            fileStream.WriteLine("************************************");
            fileStream.WriteLine("");
            fileStream.WriteLine("   : New session: " + DateTime.Now);
            fileStream.WriteLine("   : Windows version: " + System.Environment.OSVersion);
            fileStream.WriteLine("   : .Net version: " + dotNetVersion);
            fileStream.WriteLine("");
        }

        public void Close()
        {
            fileStream.Close();
        }

        private static string Get45or451FromRegistry()
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                if (true)
                {
                    return CheckFor45DotVersion(releaseKey);
                }
                else
                {
                    return ".NET version could not be determined";
                }

            }
        }

        // Checking the version using >= will enable forward compatibility,  
        // however you should always compile your code on newer versions of 
        // the framework to ensure your app works the same. 
        private static string CheckFor45DotVersion(int releaseKey)
        {
            if (releaseKey >= 461808)
            {
                return "4.7.2 or later";
            }
            if (releaseKey >= 461308)
            {
                return "4.7.1 or later";
            }
            if (releaseKey >= 460798)
            {
                return "4.7 or later";
            }
            if (releaseKey >= 394802)
            {
                return "4.6.2 or later";
            }
            if (releaseKey >= 394254)
            {
                return "4.6.1 or later";
            }
            if (releaseKey >= 393295)
            {
                return "4.6 or later";
            }
            if (releaseKey >= 393273)
            {
                return "4.6 RC or later";
            }
            if ((releaseKey >= 379893))
            {
                return "4.5.2 or later";
            }
            if ((releaseKey >= 378675))
            {
                return "4.5.1 or later";
            }
            if ((releaseKey >= 378389))
            {
                return "4.5 or later";
            }
            // This line should never execute. A non-null release key should mean 
            // that 4.5 or later is installed. 
            return "No 4.5 or later version detected";
        }


    }
}
