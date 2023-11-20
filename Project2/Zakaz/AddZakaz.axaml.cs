using System.Collections.Generic;
using System.Net.NetworkInformation;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using Project2.Models;
using Tmds.DBus.Protocol;

namespace Project2.Windows;

public partial class AddZakaz : Window
{
    public string _connString =
        "server = sql12.freesqldatabase.com; database = sql12661858; port = 3306; User = sql12661858; password = NF2LEehAvp";
    private MySqlConnection _connection;

    public AddZakaz()
    {
        InitializeComponent();
        Width = 400;
        Height = 450;
        InitComboBoxStatus();
        InitComboBoxClient();
        InitComboBoxAuto();
        InitComboBoxGruz();
    }

    private void InitComboBoxStatus()
    {
        string sql = "select StatusID, Name from Status";
        var statuses = new List<Models.Status>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new Models.Status()
            {
                StatusID = reader.GetInt32(column: "StatusID"),
                Name = reader.GetString(column: "Name"),
            };
            statuses.Add(current);
        }

        _connection.Close();
        StatusComboBox.ItemsSource = statuses;
    }

    private void InitComboBoxClient()
    {
        string sql = "select ClientID, FIO from Client";
        var clients = new List<Models.Client>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new Models.Client()
            {
                ClientId = reader.GetInt32(column: "ClientID"),
                FIO = reader.GetString(column: "FIO"),
            };
            clients.Add(current);
        }

        _connection.Close();
        ClientComboBox.ItemsSource = clients;
    }

    private void InitComboBoxAuto()
    {
        string sql = "select AutoID, Marka from Auto";
        var autos = new List<Models.Auto>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new Models.Auto()
            {
                AutoID = reader.GetInt32(column: "AutoID"),
                Marka = reader.GetString(column: "Marka"),
            };
            autos.Add(current);
        }

        _connection.Close();
        AutoComboBox.ItemsSource = autos;
    }
    private void InitComboBoxGruz()
    {
        string sql = "select GruzID, Name from Gruz";
        var tovars = new List<Models.Tovar>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new Models.Tovar()
            {
                GruzID = reader.GetInt32(column: "GruzID"),
                Name = reader.GetString(column: "Name"),
            };
            tovars.Add(current);
        }

        _connection.Close();
        GruzcomboBox.ItemsSource = tovars;
    }
    private void AddBtnOnClick(object? sender, RoutedEventArgs e)
    {
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        string sql = "insert into Zakaz (Auto, Client, Gruz, Status)" +
                     "values (@auto, @client, @gruz, @status)";
        using (MySqlCommand command = new MySqlCommand(sql, _connection))
        {
            command.Parameters.AddWithValue("@auto", AutoComboBox.SelectedValue);
            command.Parameters.AddWithValue("@client", ClientComboBox.SelectedValue);
            command.Parameters.AddWithValue("@gruz", GruzcomboBox.SelectedValue);
            command.Parameters.AddWithValue("@status", StatusComboBox.SelectedValue);
            command.ExecuteNonQuery();
        }
        _connection.Close();
    }


    private void BackOnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }
}