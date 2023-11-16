using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using Project2.Models;
using Project2.Windows;

namespace Project2;

public partial class MainWindow : Window
{
    public string _connString = "server = sql12.freesqldatabase.com;database = sql12661858; port = 3306; User = sql12661858; password = NF2LEehAvp";
    private List<Zakaz> _orders;
    private MySqlConnection _connection;

    public MainWindow()
    {
        InitializeComponent();
        ShowTable();
    }
    public void ShowTable()
    {
        string sql = "select ZakazID, C.FIO, A.Marka, G.Name as Imya, S.Name from sql12661858.Zakaz" +
            " join sql12661858.Client C on Zakaz.Client = C.ClientID" +
            " join sql12661858.Gruz G on Zakaz.Gruz = G.GruzID" +
            " join sql12661858.Auto A on Zakaz.Auto = A.AutoID" +
            " join sql12661858.Status S on Zakaz.Status = S.StatusID";
        _orders = new List<Zakaz>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentOrder = new Zakaz()
            {
                ZakazID = reader.GetInt32(column: "ZakazID"),
                Client = reader.GetString(column:"FIO"),
                Auto = reader.GetString(column:"Marka"),
                Gruz = reader.GetString(column:"Imya"),
                Status = reader.GetString(column:"Name")
            };
            _orders.Add(currentOrder);
        }
        _connection.Close();
        OrderGrid.ItemsSource = _orders;
    }
    private void AddZakaz_OnClick(object? sender, RoutedEventArgs e)
    {
        AddZakaz addZakaz = new AddZakaz();
        this.Hide();
        addZakaz.Show();
    }

    private void RedZakaz_OnClick(object? sender, RoutedEventArgs e)
    {
        RedZakaz redZakaz = new RedZakaz();
        this.Hide();
        redZakaz.Show();
    }
    private void DelZakaz_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void ShowAuto_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    private void ShowTovar_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void ShowKlient_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}