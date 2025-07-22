namespace ContactsApp01
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            btnExit = new Button();
            btnSave = new Button();
            btnDiscard = new Button();
            contactShowGridView = new DataGridView();
            btnUpdate = new Button();
            btnRemove = new Button();
            searchGroup = new GroupBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)contactShowGridView).BeginInit();
            searchGroup.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 140);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 189);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "LastName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 242);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 2;
            label3.Text = "Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 298);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(91, 137);
            txtName.Name = "txtName";
            txtName.Size = new Size(168, 23);
            txtName.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(91, 189);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(168, 23);
            txtLastName.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(91, 239);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(168, 23);
            txtPhone.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(91, 290);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(168, 23);
            txtEmail.TabIndex = 7;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(713, 415);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 8;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(118, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDiscard
            // 
            btnDiscard.Location = new Point(27, 415);
            btnDiscard.Name = "btnDiscard";
            btnDiscard.Size = new Size(75, 23);
            btnDiscard.TabIndex = 10;
            btnDiscard.Text = "Discard";
            btnDiscard.UseVisualStyleBackColor = true;
            btnDiscard.Click += btnDiscard_Click;
            // 
            // contactShowGridView
            // 
            contactShowGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contactShowGridView.Location = new Point(295, 30);
            contactShowGridView.Name = "contactShowGridView";
            contactShowGridView.RowHeadersWidth = 51;
            contactShowGridView.Size = new Size(493, 306);
            contactShowGridView.TabIndex = 11;
            contactShowGridView.SelectionChanged += contactShowGridView_SelectionChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(27, 388);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 22);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(118, 388);
            btnRemove.Margin = new Padding(3, 2, 3, 2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 22);
            btnRemove.TabIndex = 13;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // searchGroup
            // 
            searchGroup.Controls.Add(txtSearch);
            searchGroup.Location = new Point(23, 12);
            searchGroup.Name = "searchGroup";
            searchGroup.Size = new Size(242, 100);
            searchGroup.TabIndex = 14;
            searchGroup.TabStop = false;
            searchGroup.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 44);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(230, 23);
            txtSearch.TabIndex = 15;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(searchGroup);
            Controls.Add(btnRemove);
            Controls.Add(btnUpdate);
            Controls.Add(contactShowGridView);
            Controls.Add(btnDiscard);
            Controls.Add(btnSave);
            Controls.Add(btnExit);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtLastName);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "Contacts";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)contactShowGridView).EndInit();
            searchGroup.ResumeLayout(false);
            searchGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private Button btnExit;
        private Button btnSave;
        private Button btnDiscard;
        private DataGridView contactShowGridView;
        private Button btnUpdate;
        private Button btnRemove;
        private GroupBox searchGroup;
        private TextBox txtSearch;
    }
}
