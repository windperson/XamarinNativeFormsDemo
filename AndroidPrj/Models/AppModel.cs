using System.Collections.Generic;

namespace AndroidPrj.Models
{
    public static class AppModel
    {
        private static List<string> phoneNumbers;

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
            set { phoneNumbers = value; }
        }
    }
}