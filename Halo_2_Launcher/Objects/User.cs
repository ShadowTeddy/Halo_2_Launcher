using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Halo_2_Launcher.Objects
{
    class User
    {
        private string _Username;
        private string _Password;
        public string Username
        { get { return this._Username; } set { this._Username = value; } }
        public string Password
        { get { return this._Password; } set { this._Password = HashPassword(value); } }
        public string HashPassword(string Password)
        {
            using (SHA512CryptoServiceProvider Crpyto = new SHA512CryptoServiceProvider())
            {
                return (BitConverter.ToString(Crpyto.ComputeHash((new UnicodeEncoding()).GetBytes(Password)))).ToString();
            }
        }
    }
}
