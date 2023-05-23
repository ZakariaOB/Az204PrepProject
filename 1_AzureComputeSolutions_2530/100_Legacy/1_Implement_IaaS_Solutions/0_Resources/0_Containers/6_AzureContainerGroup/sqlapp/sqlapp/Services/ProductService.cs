using MySql.Data.MySqlClient;
using sqlapp.Models;


namespace sqlapp.Services
{

    // This service will interact with our Product data in the SQL database
    public class ProductService
    {
        private static string db_connectionstring = "server=localhost;Port=3306;user=root;password=Azure123;database=appdb";
        private MySqlConnection GetConnection()
        {            
           return new MySqlConnection(db_connectionstring);
        }
        public List<Product> GetProducts()
        {
            List<Product> _product_lst = new List<Product>();
            string _statement = "SELECT ProductID,ProductName,Quantity from Products";
            MySqlConnection _connection = GetConnection();
            
            _connection.Open();
            
            MySqlCommand _sqlcommand = new MySqlCommand(_statement, _connection);
            
            using (MySqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };

                    _product_lst.Add(_product);
                }
            }
            _connection.Close();
            return _product_lst;
        }

    }
}

