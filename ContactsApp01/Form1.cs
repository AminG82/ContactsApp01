using Microsoft.Data.SqlClient;

namespace ContactsApp01
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("""
                Data Source=.;Initial Catalog=ContactsDB;User ID=sa; Password = amin5123 ;Encrypt = false
                """);

            try
            {
                connection.Open();
                MessageBox.Show("Connection to the database was successful.");
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
    }
}
