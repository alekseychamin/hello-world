using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckMails
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckMail checkMail = new CheckMail();
            string filename = Directory.GetCurrentDirectory() + "\\" + "setting_checkmail.xml";
            Console.WriteLine(filename);
            while (true)
            {
                checkMail.LoadConfig(filename);
                checkMail.ManageMail();
                Thread.Sleep(checkMail.UpTime * 60 * 60 * 1000);
            }
            
        }
    }
}
