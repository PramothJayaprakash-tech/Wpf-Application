using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;


namespace Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameData.Text) ||
                string.IsNullOrWhiteSpace(QuantityData.Text) ||
                string.IsNullOrWhiteSpace(PriceData.Text) ||
                string.IsNullOrWhiteSpace(DescriptionData.Text))
            {
                MessageBox.Show("Try to fill in all Checkbox.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string name = NameData.Text.Trim();
            string description = DescriptionData.Text.Trim();
            int quantity;
            decimal price;

            if (!int.TryParse(QuantityData.Text, out quantity) || !decimal.TryParse(PriceData.Text, out price))
            {
                MessageBox.Show("Try to enter valid values for Quantity and Price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Items (Name, Quantity, Price, Description) VALUES (@Name, @Quantity, @Price, @Description)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Description", description);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Data inputed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inputing data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Items";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    ItemsDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 1) 
            {
                LoadData();
            }
        }

        private void ClearForm()
        {
            NameData.Text = string.Empty;
            QuantityData.Text = string.Empty;
            PriceData.Text = string.Empty;
            DescriptionData.Text = string.Empty;
        }
    }
}
