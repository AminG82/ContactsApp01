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

        private void MainForm_Load(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
                MessageBox.Show("Connection to the database was successful.");

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Contacts", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                lstContactsShow.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    // Adjust the fields as per your Contacts table columns     // Load existing contacts into the list box
                    string display = $"{row["ContactName"]} {row["ContactLastName"]} - {row["ContactPhone"]} - {row["ContactEmail"]}";
                    lstContactsShow.Items.Add(display);
                }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtName.Text) ||
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

            
            
        }
    }
}
