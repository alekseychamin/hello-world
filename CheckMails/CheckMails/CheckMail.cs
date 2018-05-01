using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMails
{
    class Mail
    {
        public string address;
        public string password;
    }
    class BlackList
    {
        public string address;
    }

    class CheckMail
    {
        int uptime;
        int period;

        public List<Mail> ListMail = new List<Mail>();
        public List<BlackList> ListBlack = new List<BlackList>();

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

        }
    }
}
