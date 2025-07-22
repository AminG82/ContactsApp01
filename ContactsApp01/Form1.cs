using Microsoft.Data.SqlClient;
using System.Data;

namespace ContactsApp01
{
    public partial class MainForm : Form
    {
        SqlConnection connection = new SqlConnection("""
                Data Source=.;Initial Catalog=ContactsDB;User ID=sa; Password = amin5123 ;Encrypt = false
                """);
        private int SelectedContactId = -1;
        public MainForm()
        {
            InitializeComponent();
            btnRemove.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void LoadContacts()
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Contacts", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                contactShowGridView.DataSource = dataTable;
                contactShowGridView.Columns["ContactID"].Visible = false; // Hide the ID column
                contactShowGridView.AllowUserToAddRows = false; // Disable the ability to add rows directly in the grid view
                contactShowGridView.AllowUserToDeleteRows = false;
                contactShowGridView.ReadOnly = true; // Make the grid view read-only

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}");
                Application.Exit();
            }
            finally
            {
                connection.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("""
                    INSERT INTO Contacts (ContactName, ContactLastName, ContactPhone, ContactEmail)
                    VALUES (@Name, @LastName, @Phone, @Email)
                    """, connection);

                queryExecution(insertCommand, connection);
            }

            // Clear the input fields after saving
            txtName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();

            // Refresh the list box to show the newly added contact
            LoadContacts();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        private void contactShowGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = contactShowGridView.SelectedRows.Count > 0;
            btnRemove.Enabled = hasSelection;
            btnUpdate.Enabled = hasSelection;

            if (hasSelection)
            {
                var selectedRow = contactShowGridView.SelectedRows[0];
                SelectedContactId = Convert.ToInt32(selectedRow.Cells["ContactID"].Value);

                txtName.Text = selectedRow.Cells["ContactName"].Value?.ToString();
                txtLastName.Text = selectedRow.Cells["ContactLastName"].Value?.ToString();
                txtPhone.Text = selectedRow.Cells["ContactPhone"].Value?.ToString();
                txtEmail.Text = selectedRow.Cells["ContactEmail"].Value?.ToString();

                txtName.Modified = false;
                txtLastName.Modified = false;
                txtPhone.Modified = false;
                txtEmail.Modified = false;
            }
            else
            {
                SelectedContactId = -1;
                txtName.Clear();
                txtLastName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!txtName.Modified &&
                !txtLastName.Modified &&
                !txtPhone.Modified &&
                !txtEmail.Modified)
            {
                MessageBox.Show("No changes made to the contact.");
                return;
            }

            SqlCommand updateCommand = new SqlCommand("""
                UPDATE Contacts
                SET ContactName = @Name ,
                ContactLastName = @LastName ,
                ContactPhone = @Phone ,
                ContactEmail = @Email 
                WHERE ContactID = @ContactID
                """,
            connection);

            queryExecution(updateCommand, connection);

        }

        private void queryExecution(SqlCommand command, SqlConnection connection)
        {
            if (command.CommandText.Contains("@Name"))
                command.Parameters.AddWithValue("@Name", txtName.Text);
            if (command.CommandText.Contains("@LastName"))
                command.Parameters.AddWithValue("@LastName", txtLastName.Text);
            if (command.CommandText.Contains("@Phone"))
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
            if (command.CommandText.Contains("@Email"))
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
            if (command.CommandText.Contains("@ContactID"))
                command.Parameters.AddWithValue("@ContactID", SelectedContactId);

            connection.Open();
            int affected = command.ExecuteNonQuery();
            MessageBox.Show($"Operation complete! {affected} row(s) affected");
            connection.Close();

            txtName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();

            LoadContacts();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this row?", "Warning", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                SqlCommand deleteCommand = new SqlCommand("""
                DELETE FROM Contacts WHERE ContactID = @ContactID
                """, connection);

                queryExecution(deleteCommand, connection);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter searchCommand = new SqlDataAdapter("""
                SELECT * FROM Contacts WHERE ContactName LIKE @Search OR ContactLastName LIKE @Search
                """, connection);
            searchCommand.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");
            DataSet ds = new DataSet();
            searchCommand.Fill(ds , "Contacts");
            contactShowGridView.Columns.Clear();
            contactShowGridView.DataSource = ds.Tables["Contacts"];
            contactShowGridView.Columns["ContactID"].Visible = false; // Hide the ID column
        }
    }
}