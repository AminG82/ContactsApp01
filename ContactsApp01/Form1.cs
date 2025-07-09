using Microsoft.Data.SqlClient;
using System.Data;

namespace ContactsApp01
{
    public partial class MainForm : Form
    {
        SqlConnection connection = new SqlConnection("""
                Data Source=.;Initial Catalog=ContactsDB;User ID=sa; Password = amin5123 ;Encrypt = false
                """);
        public MainForm()
        {
            InitializeComponent();
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
                SqlCommand Insert = new SqlCommand("""
                    INSERT INTO Contacts (ContactName, ContactLastName, ContactPhone, ContactEmail)
                    VALUES (@Name, @LastName, @Phone, @Email)
                    """, connection);
                Insert.Parameters.AddWithValue("@Name", txtName.Text);
                Insert.Parameters.AddWithValue("@LastName", txtLastName.Text);
                Insert.Parameters.AddWithValue("@Phone", txtPhone.Text);
                Insert.Parameters.AddWithValue("@Email", txtEmail.Text);

                connection.Open();
                int affected = Insert.ExecuteNonQuery();
                MessageBox.Show($"InsertComplite! {affected} Row affected");
                connection.Close();
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
    }
}
