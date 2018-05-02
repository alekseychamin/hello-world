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
                if (xnode.Name == "uptime_h")
                {
                    try
                    {
                        uptime = Convert.ToInt32(xnode.InnerText);                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат числа uptime_h!");
                    }                    
                }

                if (xnode.Name == "period_d")
                {
                    try
                    {
                        period = Convert.ToInt32(xnode.InnerText);                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат числа period_h!");
                    }
                }

                if (xnode.Name == "listblack")
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "blackaddress")
                        {
                            BlackAddress blackaddress = new BlackAddress() { address = childnode.InnerText };
                            ListBlack.Add(blackaddress);                            
                        }
                    }
                }
                if (xnode.Name == "listmail")
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "mail")
                        {
                            Mail mail = new Mail();                            
                            foreach (XmlNode childmail in childnode.ChildNodes)
                            {
                                if (childmail.Name == "address")
                                {
                                    mail.address = childmail.InnerText;
                                }
                                if (childmail.Name == "password")
                                {
                                    mail.password = childmail.InnerText;
                                }
                            }
                            ListMail.Add(mail);
                        }
                    }
                }


            }

        }
    }
}
;