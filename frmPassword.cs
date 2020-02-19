using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyVault.Managers;
using KeyVault.Objects;
using System.Threading;

namespace KeyVault
{
    public partial class frmPassword : Form
    {
        Library library = new Library();
        DbManager database = new DbManager();

        public frmPassword()
        {
            InitializeComponent();
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            if (checkInitialRun())
            {
                //Create master passsword.
                createMasterPassword();
            }
        }

        private Boolean checkInitialRun()
        {
            Boolean initialRun = false;

            try
            {
                initialRun = Properties.Settings.Default.initialRun;

                if (initialRun)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                library.errorHandler(ex);
                return false;
            }
        }

        public void createMasterPassword()
        {
            try
            {
                Boolean valid = false;
                String password = "";
                String confirmPassword = "";

                do
                {
                    password = Interaction.InputBox("Please enter a master password.");

                    if (password != "")
                    {
                        confirmPassword = Interaction.InputBox("Please confirm your password");

                        if (password == confirmPassword)
                        {

                            setMasterPassword(confirmPassword);
                            disableInitialRun();
                            valid = true;
                            MessageBox.Show("Master password set.");
                        }
                        else
                        {
                            MessageBox.Show("Passwords do not match.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid password.");
                    }

                } while (valid == false);
            }
            catch (Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        public void setMasterPassword(string password)
        {
            string salt = "";
            string hashedPass = "";
            try
            {
                if (password != "")
                {
                    salt = library.CreateSalt();
                    hashedPass = library.GenerateHash(password, salt);

                    Properties.Settings.Default.masterPass = hashedPass;
                    Properties.Settings.Default.salt = salt;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        public Boolean requestMasterPassword(string passwordInput)
        {
            var storedHash = "";
            var salt = "";
            var passwordValid = false;

            try
            {
                storedHash = Properties.Settings.Default.masterPass;
                salt = Properties.Settings.Default.salt;

                if (storedHash != "")
                {
                    if (library.verifyPassword(passwordInput, storedHash, salt))
                    {
                        passwordValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password");
                        passwordValid = false;
                    }
                }
               
            }
            catch (Exception ex)
            {
                library.errorHandler(ex);
            }
            return passwordValid;
        }

        public void disableInitialRun()
        {
            try
            {
                Properties.Settings.Default.initialRun = false;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if(requestMasterPassword(txtPassword.Text))
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(newForm));
                t.Start();
                this.Close();
            }
        }

        public static void newForm()
        {
            frmKeyVault keyVault;
            Application.Run(new frmKeyVault());
        }
    }
}
