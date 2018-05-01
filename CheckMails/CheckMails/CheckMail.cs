using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CheckMails
{
    class Mail
    {
        public string address;
        public string password;
    }
    class BlackAddress
    {
        public string address;
    }

    class CheckMail
    {
        int uptime;
        int period;

        List<Mail> ListMail = new List<Mail>();
        List<BlackAddress> ListBlack = new List<BlackAddress>();

        public int UpTime
        {
            get
            {
                return uptime;                
            }
            set
            {
                if (UpTime > 1) uptime = UpTime;               
            }
        } 
        public int Period
        {
            get
            {
                return period;
            }
            set
            {
                if (Period > 1) period = Period;
            }
        }

        public void LoadConfig(string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            XmlElement xRoot = xDoc.DocumentElement; // получение корневого элемента - checkmails

            // обход всех элементов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                Console.WriteLine(xnode.Name);
            }

        }
    }
}
