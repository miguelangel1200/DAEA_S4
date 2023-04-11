using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using WPFSemana04.Models;

namespace WPFSemana04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection("Data Source=LAB707-07\\SQLEXPRESS02;Initial Catalog=dtb_catalogo;Integrated Security=True;");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Person> people = new List<Person>();

            connection.Open();
            SqlCommand command = new SqlCommand("USP_GetPeople", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter1.Size = 50;
            parameter1.Value = "";
            parameter1.ParameterName = "@LastName";

            SqlParameter parameter2 = new SqlParameter();
            parameter2.SqlDbType = SqlDbType.VarChar;
            parameter2.Size = 50;
            parameter2.Value = "";
            parameter2.ParameterName = "@FirstName";

            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    PersonId = dataReader["id"].ToString(),
                    LastName = dataReader["last_name"].ToString(),
                    FirstName = dataReader["first_name"].ToString(),
                    FullName = dataReader["full_name"].ToString(),
                    Age = (int)dataReader["age"]
                });
            }
            connection.Close();
            dgvPeople.ItemsSource = people;
        }
    }
}
