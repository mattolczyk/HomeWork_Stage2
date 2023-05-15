using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.EntityFramework
{
    public class BorrowerValidator
    {
        public bool IsIdValid(string id)
        {
            Guid guid;
            return Guid.TryParse(id, out guid);
        }

        public bool IsNameValid(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

        public bool IsEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsPhoneValid(string phone)
        {
            return !string.IsNullOrEmpty(phone);
        }
    }
}
