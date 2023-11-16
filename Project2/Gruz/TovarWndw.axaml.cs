using System.Collections.Generic;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using Project2.Models;

namespace Project2.Windows;

public partial class TovarWndw : Window
{
    public string _connString = "server = sql12.freesqldatabase.com; database = sql12661858; port = 3306; User = sql12661858; password = NF2LEehAvp";
    private List<Tovar> _tovars;
    private MySqlConnection _connection;
    public TovarWndw()
    {
        InitializeComponent();
        Showtable();
    }

    public void Showtable()
    {
        string sql = " select GruzID, Count, Name, from sql12661858.Gruz";
        _tovars = new List<Tovar>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentGruz = new Models.Tovar()
            {
                GruzID = reader.GetInt32(column:"GruzID"),
                Name = reader.GetString(column:"Name"),
                Count = reader.GetInt32(column:"Count")
            };
            _tovars.Add(currentGruz);
        }
        _connection.Close();
        TovarGrid.ItemsSource = _tovars;
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }
}