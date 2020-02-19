namespace KeyVault
{
    partial class frmKeyVault
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpKeys = new System.Windows.Forms.TabPage();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblProductKey = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtProductKey = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tpOptions = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpKeys.SuspendLayout();
            this.tpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpKeys);
            this.tabControl1.Controls.Add(this.tpOptions);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(337, 415);
            this.tabControl1.TabIndex = 1;
            // 
            // tpKeys
            // 
            this.tpKeys.Controls.Add(this.btnAddKey);
            this.tpKeys.Controls.Add(this.lblNotes);
            this.tpKeys.Controls.Add(this.txtNotes);
            this.tpKeys.Controls.Add(this.lblProductKey);
            this.tpKeys.Controls.Add(this.lblName);
            this.tpKeys.Controls.Add(this.txtProductKey);
            this.tpKeys.Controls.Add(this.txtName);
            this.tpKeys.Location = new System.Drawing.Point(4, 22);
            this.tpKeys.Name = "tpKeys";
            this.tpKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tpKeys.Size = new System.Drawing.Size(329, 389);
            this.tpKeys.TabIndex = 0;
            this.tpKeys.Text = "Keys";
            this.tpKeys.UseVisualStyleBackColor = true;
            // 
            // btnAddKey
            // 
            this.btnAddKey.Location = new System.Drawing.Point(6, 285);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(317, 23);
            this.btnAddKey.TabIndex = 6;
            this.btnAddKey.Text = "Add ";
            this.btnAddKey.UseVisualStyleBackColor = true;
            this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(7, 99);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 5;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(6, 113);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(317, 166);
            this.txtNotes.TabIndex = 4;
            // 
            // lblProductKey
            // 
            this.lblProductKey.AutoSize = true;
            this.lblProductKey.Location = new System.Drawing.Point(7, 51);
            this.lblProductKey.Name = "lblProductKey";
            this.lblProductKey.Size = new System.Drawing.Size(65, 13);
            this.lblProductKey.TabIndex = 3;
            this.lblProductKey.Text = "Product Key";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtProductKey
            // 
            this.txtProductKey.Location = new System.Drawing.Point(6, 65);
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(317, 20);
            this.txtProductKey.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(317, 20);
            this.txtName.TabIndex = 0;
            // 
            // tpOptions
            // 
            this.tpOptions.Controls.Add(this.button1);
            this.tpOptions.Location = new System.Drawing.Point(4, 22);
            this.tpOptions.Name = "tpOptions";
            this.tpOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpOptions.Size = new System.Drawing.Size(329, 389);
            this.tpOptions.TabIndex = 1;
            this.tpOptions.Text = "Options";
            this.tpOptions.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(316, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export Vault";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(345, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove Key";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.name,
            this.productKey,
            this.notes});
            this.dataGridView1.Location = new System.Drawing.Point(355, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(345, 360);
            this.dataGridView1.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // productKey
            // 
            this.productKey.HeaderText = "Product Key";
            this.productKey.Name = "productKey";
            this.productKey.ReadOnly = true;
            // 
            // notes
            // 
            this.notes.HeaderText = "Notes";
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            // 
            // frmKeyVault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 436);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmKeyVault";
            this.Text = "KeyVault";
            this.Load += new System.EventHandler(this.frmKeyVault_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpKeys.ResumeLayout(false);
            this.tpKeys.PerformLayout();
            this.tpOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpKeys;
        private System.Windows.Forms.Button btnAddKey;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblProductKey;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtProductKey;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage tpOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn productKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
    }
}

