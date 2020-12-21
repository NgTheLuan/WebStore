using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace WebStore.Models
{
    public class USERMANAGER
    {
        ModelWebStore db = new ModelWebStore();
        public bool checkUserName(string username)
        {
            List<USER> find_user = (from fu in db.USERs where fu.UserName == username select fu).ToList();
            if (find_user.Count == 1)
            {
                return false;
            }
            else { return true; }
        }
        public bool checkEmail(string email)
        {
            List<USER> find_email = (from fe in db.USERs where fe.Email == email select fe).ToList();
            if (find_email.Count >= 1)
            {
                return false;
            }
            else { return true; }
        }

        public bool checkLogin(string TxtUserName, string TxtPassword)
        {
            //SHA256 md5 = new SHA256CryptoServiceProvider();
            //Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(TxtPassword);
            //Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            //TxtPassword = BitConverter.ToString(encodedBytes);
            //List<USER> login_finded = (from log in db.USERs where (log.UserName == TxtUserName && log.Password == TxtPassword) select log).ToList();


           
           USER usr = db.USERs.SingleOrDefault(p => p.UserName == TxtUserName && p.Password == TxtPassword);

            if (usr != null )
            {
                return true;
            }
            return false;
        }
    }
}