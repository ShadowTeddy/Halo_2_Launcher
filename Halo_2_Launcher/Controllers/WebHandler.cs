using Halo_2_Launcher.Objects;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Halo_2_Launcher.Controllers
{
    public class WebHandler
    {
        private string Api = @"http://halo2vista.com/H2Cartographer/H2Cartographer.php";
        public void Login(MetroForm Form, string Username, string Password, bool Remember)
        {
            /*
                ID = int identity
                Username = 15len String
                Password = 32len string
                XUID = 8Bytes unsigned Longlong
                GamerName = 15len String
                sIP = 4byte unisgned int
            */
            WebRequest req = WebRequest.Create(new Uri(Api));
            req.ContentType = "application/plain";
            req.Method = "POST";
            req.Headers.Add("Action", "login");
            req.Headers.Add("Username", Username);
            req.Headers.Add("Password", EncryptString(Password));
            if(Remember) req.Headers.Add("RememberToken", "true");
            using (WebResponse resp = req.GetResponse())
            {
                switch((H2ResponseCode)int.Parse(resp.Headers["Result"]))
                {
                    case H2ResponseCode.LoginAccountDoesntExsist:
                        {
                            MetroMessageBox.Show(Form, "Sorry there is no account linked with this username.\r\nPlease try again.", Fun.PauseIdiomGenerator, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            break;
                        }
                    case H2ResponseCode.LoginInvalidPassword:
                        {
                            MetroMessageBox.Show(Form, "The password entered is either incorrect or invalid.\r\nPlease try again.", Fun.PauseIdiomGenerator, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            break;
                        }
                    case H2ResponseCode.LoginSuccessful:
                        {
                            H2Launcher.StartHalo(resp.Headers["uid"], Username, resp.Headers["Logintoken"], (Remember) ? resp.Headers["Remembertoken"] : string.Empty, Form);
                            if (Remember) H2Launcher.LauncherSettings.RememberUsername = Username;
                            break;
                        }
                    case H2ResponseCode.LoginBanned: 
                        {
                            MetroMessageBox.Show(Form, "Sorry this acccount is banned for the reason of:\r\n" + resp.Headers["bannedreason"], Fun.PauseIdiomGenerator, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            break;
                        }
                    case H2ResponseCode.LoginError:
                        {
                            MetroMessageBox.Show(Form, "There was an issue trying to login.\r\nPlease Try again.", Fun.PauseIdiomGenerator, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            break;
                        }
                }
            }
        }
        public void RememberLogin(MetroForm Form, string Username, string RememberToken, bool Remember)
        {
            WebRequest req = WebRequest.Create(new Uri(Api));
            req.ContentType = "application/plain";
            req.Method = "POST";
            req.Headers.Add("Action", "rememberlogin");
            req.Headers.Add("Token", RememberToken);
            if (Remember) req.Headers.Add("RememberToken", "true");
            using (WebResponse resp = req.GetResponse())
            {
                switch ((H2ResponseCode)int.Parse(resp.Headers["Result"]))
                {
                    case H2ResponseCode.LoginRememberTokenSuccessful:
                        {
                            H2Launcher.StartHalo(resp.Headers["uid"],Username , resp.Headers["Logintoken"], (Remember) ? resp.Headers["Remembertoken"] : string.Empty, Form);
                            break;
                        }
                    case H2ResponseCode.LoginRememberTokenFailed:
                        {
                            MetroMessageBox.Show(Form, "Your account token has expired, please re-enter your password.", Fun.PauseIdiomGenerator, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            H2Launcher.LauncherSettings.RememberAccount = false;
                            H2Launcher.LauncherSettings.RememberToken = "";
                            ((MetroFramework.Controls.MetroCheckBox)Form.Controls["rememberCheckBox"]).Checked = false;
                            ((MetroFramework.Controls.MetroTextBox)Form.Controls["passwordTextBox"]).Text = "";
                            break;
                        }
                }
            }
        }
        public void Register(MetroForm Form, string Username, string Password)
        {
            /*
                ID = int identity
                Username = 15len String
                Password = 32len string
                XUID = 8Bytes unsigned Longlong
                GamerName = 15len String
                sIP = 4byte unisgned int
            */
            WebRequest req = WebRequest.Create(new Uri(Api));
            req.ContentType = "application/plain";
            req.Method = "POST";
            req.Headers.Add("Action", "register");
            req.Headers.Add("Username", Username);
            req.Headers.Add("Password", EncryptString(Password));
            using (WebResponse resp = req.GetResponse())
            {
                switch ((H2ResponseCode)int.Parse(resp.Headers["Result"]))
                {
                    case H2ResponseCode.RegisterSuccessful:
                        {
                            MetroMessageBox.Show(Form, "Your account " + Username + " has been created.\r\nYou can now login to play!", Fun.GoIdioms, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question);
                            break;
                        }
                    case H2ResponseCode.RegisterUsernameInvalid:
                        {
                            MetroMessageBox.Show(Form, "The username is invalid.", Fun.PauseIdiomGenerator, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            break;
                        }
                    case H2ResponseCode.RegisterUsernameFailed:
                        {
                            MetroMessageBox.Show(Form, "There was an issue registering the account.", Fun.PauseIdiomGenerator, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            break;
                        }

                }
            }
        }
        private string EncryptString(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X"));
            return sb.ToString().ToLower();
        }
    }
}
