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

        private void btnAddKey_Click(object sender, EventArgs e)
        {
            ProductKey key = new ProductKey
            {
                name = txtName.Text,
                productKey = txtProductKey.Text,
                notes = txtNotes.Text
            };

            database.insert(key);
            getAllEntries();
        }

        private async void getAllEntries()
        {
            try
            {
                List<ProductKey> keys = await database.getAll();
                dgData.Rows.Clear();

                if(keys != null)
                {
                    for (var i = 0; i < keys.Count; i++)
                    {
                        dgData.Rows.Add(
                            keys[i].ID,
                            keys[i].name,
                            keys[i].productKey,
                            keys[i].notes
                            );
                    }
                    
                }
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        private void btnRemoveKey_Click(object sender, EventArgs e)
        {
            if (dgData.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgData.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgData.Rows[selectedrowindex];
                int indexToRemove = Convert.ToInt32(selectedRow.Cells["keyId"].Value);
                
                if(indexToRemove > 0)
                {
                    database.remove(indexToRemove);
                }

                getAllEntries();
            }
        }
    }
}
