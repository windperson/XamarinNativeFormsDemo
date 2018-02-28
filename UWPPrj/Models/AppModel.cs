using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPrj.Models
{
    class AppModel
    {
        static List<string> phoneNumbers;

        public static List<string> PhoneNumbers
        {
            get
            {
                if (phoneNumbers == null)
                {
                    phoneNumbers = new List<string>();
                }
                return phoneNumbers;
            }
            set
            {
                phoneNumbers = value;
            }
        }
    }
}
