using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using KeyVault.Managers;
using KeyVault.Objects;
using FireSharp.Response;

namespace KeyVault
{
    public partial class frmKeyVault : Form
    {
        Library library = new Library();
        DbManager database = new DbManager();
        

        public frmKeyVault()
        {
            InitializeComponent();
        }

        private void frmKeyVault_Load(object sender, EventArgs e)
        {
            try
            {
                if (checkInitialRun())
                {
                    //Create master passsword.
                    createMasterPassword();
                }
                else
                {
                    requestMasterPassword();
                }

                if (database.connect())
                {
                    MessageBox.Show("connected");
                    getAllEntries();
                }
                else
                {
                    MessageBox.Show("unable to connect to firebase.");
                }
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        private Boolean checkInitialRun()
        {
            Boolean initialRun = false;

            try
            {
                initialRun = Properties.Settings.Default.initialRun;

                if(initialRun)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
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

                        if(password == confirmPassword)
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
            catch(Exception ex)
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
                if(password != "")
                {
                    salt = library.CreateSalt();
                    hashedPass = library.GenerateHash(password, salt);

                    Properties.Settings.Default.masterPass = hashedPass;
                    Properties.Settings.Default.salt = salt;
                    Properties.Settings.Default.Save();
                }
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        public void requestMasterPassword()
        {
            var passwordInput = "";
            var storedHash = "";
            var salt = "";
            var passwordValid = false;

            try
            {
                storedHash = Properties.Settings.Default.masterPass;
                salt = Properties.Settings.Default.salt;

                if(storedHash != "")
                {
                    do
                    {
                        passwordInput = Interaction.InputBox("Enter master password.");
                        
                        if(library.verifyPassword(passwordInput, storedHash, salt))
                        {
                            passwordValid = true;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password");
                        }

                    } while (passwordValid == false);
                }
                
            }
            catch (Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        public void disableInitialRun()
        {
            try
            {
                Properties.Settings.Default.initialRun = false;
                Properties.Settings.Default.Save();
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        private void btnAddKey_Click(object sender, EventArgs e)
        {
            ProductKey key = new ProductKey
            {
                name = txtName.Text,
                productKey = txtProductKey.Text,
                notes = txtNotes.Text
            };

            database.insert(key);
        }

        private async void getAllEntries()
        {
            try
            {
                //TODO implement
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
            }
        }
    }
}
