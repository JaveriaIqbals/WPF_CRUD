using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_FirstLec
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }    

    }
    public partial class Window1 : Window
    {
        List<Student> students;
        SqlConnection conn;
        public Window1()
        {
            InitializeComponent();
            AddFillStudentsInGrid();
            conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;");
            // students = new List<Student>();
        }

        void AddFillStudentsInGrid()
        {
            /*students.Add(new Student { Id = 1, Name = "abc", Age = 30 });
           students.Add(new Student { Id = 2, Name = "bbb", Age = 40 });
           students.Add(new Student { Id = 3, Name = "ccc", Age = 20 });
           students.Add(new Student { Id = 4, Name = "ddd", Age = 10 });*/

            students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name = "abc",
                    Age =   20,
                },
                new Student()
                {
                    Id = 2,
                    Name = "bbb",
                    Age =   20,
                },
                  new Student()
                {
                    Id = 3,
                    Name = "ccc",
                    Age =   30,
                },
                   new Student()
                {
                    Id = 4,
                    Name = "ddd",
                    Age =   25,
                }

            };
            this.dg1.ItemsSource = students;
        }
        
        void FillCustomerDataInGrid()
        {
            // Load Customer Data into Data Grid
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Customer", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dg2.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            FillCustomerDataInGrid();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer values ('"+this.textbox1.Text+ "', '" + this.textbox2.Text + "', '" + this.textbox3.Text + "', '" + this.textbox4.Text + "' )", conn);
            
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Success : Data Inserted");
            FillCustomerDataInGrid();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer WHERE CustID = '"+this.textbox1.Text+"' ", conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Success : Data Deleted");
            FillCustomerDataInGrid();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Customer SET CustID = '"+this.textbox1.Text+"', " +
                "Name = '"+this.textbox2.Text+"', Address = '"+this.textbox3.Text+"', Gender = '"+this.textbox4.Text+"' " +
                "where CustID = '"+this.textbox1.Text+"' ", conn);
            
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Success : Data Deleted");
            FillCustomerDataInGrid();
        }
    }
}
