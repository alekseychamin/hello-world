using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CheckMails
{
    class MailBox
    {
        public string address;
        public string password;
        public string hostname;
        public int port;
        public bool usessl;
    }
    class Address
    {
        public string address;
    }

    class CheckMail
    {
        int uptime;
        int period;

        List<MailBox> ListMailBox = new List<MailBox>();
        List<Address> ListBlack = new List<Address>();
        List<Address> ListWhite = new List<Address>();

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

                if (xnode.Name == "listwhite")
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "whiteaddress")
                        {
                            Address whiteaddress = new Address() { address = childnode.InnerText };
                            ListWhite.Add(whiteaddress);
                        }
                    }
                }

                if (xnode.Name == "listblack")
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "blackaddress")
                        {
                            Address blackaddress = new Address() { address = childnode.InnerText };
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
                            MailBox mail = new MailBox();                            
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
                                if (childmail.Name == "hostname")
                                {
                                    mail.hostname = childmail.InnerText;
                                }
                                if (childmail.Name == "port")
                                {
                                    try
                                    {                                        
                                        mail.port = Convert.ToInt32(childmail.InnerText);
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Неверный формат числа port!");
                                    }                                    
                                }
                                if (childmail.Name == "usessl")
                                {
                                    string usessl = childmail.InnerText;
                                    usessl = usessl.ToLower();

                                    if (usessl == "true")
                                        mail.usessl = true;
                                    if (usessl == "false")
                                        mail.usessl = false;
                                }
                            }
                            ListMailBox.Add(mail);
                        }
                    }
                }


            }

        }

        private bool IsBlackAddress(string mailAddress)
        {
            bool isBlack = false;

            foreach (Address black in ListBlack)
            {
                if (mailAddress.ToLower().Contains(black.address.ToLower()) || mailAddress.ToLower().Equals(black.address.ToLower()))
                {
                    isBlack = true;
                    break;
                }
            }

            return isBlack;
        }

        private bool IsWhiteAddress(string mailAddress)
        {
            bool isWhite = false;

            foreach (Address address in ListWhite)
            {
                if (mailAddress.ToLower().Contains(address.address.ToLower()) || mailAddress.ToLower().Equals(address.address.ToLower()))
                {
                    isWhite = true;
                    break;
                }
            }

            return isWhite;
        }

        private bool IsMorePeriod(DateTime messageDate)
        {
            bool isMore = false;

            DateTime now = DateTime.Now;
            TimeSpan mailPeriod = (now - messageDate);

            if (mailPeriod.TotalDays > period)
                isMore = true;            

            return isMore;
        }

        public void ManageMail()
        {
            MessageHeader messageHeader;
            string mailAddress;            

            foreach (MailBox mailbox in ListMailBox)
            {
                Pop3Client client = new Pop3Client();                

                client.Connect(mailbox.hostname, mailbox.port, mailbox.usessl);
                client.Authenticate(mailbox.address, mailbox.password);

                int countMail = client.GetMessageCount();
                Console.WriteLine("In mailbox {0}, Count letters = {1}", mailbox.address, countMail);

                int i = 1;
                
                while (i <= countMail)
                {
                    messageHeader = client.GetMessageHeaders(i);
                    mailAddress = messageHeader.From.ToString();
                    

                    if ((IsBlackAddress(mailAddress) || IsMorePeriod(messageHeader.DateSent)) && !IsWhiteAddress(mailAddress))
                    {                       
                        client.DeleteMessage(i);
                        Console.WriteLine("N mail = {0}, from = {1} - delete", i, mailAddress);
                    }

                    i++;
                }

                client.Disconnect();
                client.Dispose();
            }
        }
    }
}
;