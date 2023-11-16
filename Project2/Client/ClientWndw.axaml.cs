using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

using Client = Project2.Models.Client;

namespace Project2.Windows;

public partial class ClientWndw : Window
{
    public string _connString = "server = sql12.freesqldatabase.com; database = sql12661858; port = 3306; User = sql12661858; password = NF2LEehAvp";
    private List<Models.Client> _clients;
    private MySqlConnection _connection;
    public ClientWndw()
    {
        InitializeComponent();
        ShowTable();
    }

    public void ShowTable()
    {
        string sql = "select ClientID, FIO, Adress, Gender from sql12661858.Client"+
                     " join Gender G on G.GenderID = Client.Gender ";
        _clients = new List<Models.Client>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentClient = new Models.Client()
            {
                ClientId = reader.GetInt32(column: "ClientID"),
                FIO = reader.GetString(column: "FIO"),
                Adress = reader.GetString(column:"Adress"),
                Gender = reader.GetString(column:"Gender")
            };
            _clients.Add(currentClient);
        }
        _connection.Close();
        ClientGrid.ItemsSource = _clients;
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }
}