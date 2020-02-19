using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyVault
{
    public class Library
    {
        public void errorHandler(Exception error)
        {

            if(error != null)
            {
                MessageBox.Show(error.Message, "An error occured.");
            }
        }

        public string CreateSalt()
        {
            try
            {
                //Generate a cryptographic random number for salt
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buff = new byte[1000];
                rng.GetBytes(buff);
                return Convert.ToBase64String(buff);

            }
            catch(Exception ex)
            {
                errorHandler(ex);
                return "";
            }
           
        }


        public string GenerateHash(string input, string salt)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
                SHA256Managed sHA256ManagedString = new SHA256Managed();
                byte[] hash = sHA256ManagedString.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
            catch (Exception ex)
            {
                errorHandler(ex);
                return "";
            }
            
        }

        public bool verifyPassword(string plainTextInput, string hashedInput, string salt)
        {
            try
            {
                string newHashedPin = GenerateHash(plainTextInput, salt);
                return newHashedPin.Equals(hashedInput);
            }
            catch (Exception ex)
            {
                errorHandler(ex);
                return false;
            }
         
        }

    }

}
