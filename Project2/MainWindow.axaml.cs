using System.Collections.Generic;
using Avalonia.Controls;
using MySql.Data.MySqlClient;
using Project2.Models;

namespace Project2;

public partial class MainWindow : Window
{
    public string _connString = "server=Project2;database = sql12661858; port=3306 User=sql12661858 password = NF2LEehAvp";
    private List<Order> _orders;
    private MySqlConnection _connection;
    public void ShowTable()
    {
        string sql = "select ЗаказID, Заказчик, Автомобиль, Груз, Статус_заказа from sql12661858.Заказ" +
            "join Заказчик Z on Order.Client = Z.Client"+
            "join Груз Г on Order.Груз = Г.ГрузID"+
            "join Автомобиль А on Order.Автомобиль = А.Auto"+
            "join Статус_заказа Сз on Order.Статус_заказа = Сз.Статус_ID";
        _orders = new List<Order>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentOrder = new Order()
            {
                Order_id = reader.GetInt32(column: "Order_id"),
                Client = reader.GetInt32(column:"Client"),
                Auto = reader.GetInt32(column:"Auto"),
                Cargo = reader.GetInt32(column:"Cargo"),
                Status =reader.GetInt32(column:"Status")
            };
            _orders.Add(currentOrder);
        }
        _connection.Close();
        OrderGrid.ItemsSource = _orders;
    }
    
}