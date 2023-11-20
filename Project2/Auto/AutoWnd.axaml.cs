using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using Project2.Auto;
using Auto = Project2.Models.Auto;



namespace Project2.Windows;

public partial class AutoWnd : Window
{
    public string _connString = "server = sql12.freesqldatabase.com; database = sql12661858; port = 3306; User = sql12661858; password = NF2LEehAvp";
    private List<Models.Auto> _autos;
    private MySqlConnection _connection;
    public AutoWnd()
    {
        InitializeComponent();
        Showtable();
        Width = 400;
        Height = 300;
    }

    public void Showtable()
    {
        string sql = " select AutoID, Marka, Nomer, Rashod from sql12661858.Auto";
        _autos = new List<Models.Auto>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentAuto = new Models.Auto()
            {
                AutoID = reader.GetInt32(column: "AutoID"),
                Marka = reader.GetString(column: "Marka"),
                Nomer = reader.GetString(column: "Nomer"),
                Rashod = reader.GetDecimal(column: "Rashod")
            };
            _autos.Add(currentAuto);
        };
        _connection.Close();
        AutoGrid.ItemsSource = _autos;
    }

    private void Delete(int id)
    {
        _connection.Open();
        string sql = " delete from Auto where AutoID = @id";
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }

    private void AddAuto_OnClick(object? sender, RoutedEventArgs e)
    {
        AddAutoWndw addAutoWndw = new AddAutoWndw();
        addAutoWndw.Show();
    }

    private void DelAuto_OnClick(object? sender, RoutedEventArgs e)
    {
        Delete((AutoGrid.SelectedItem as Models.Auto).AutoID);
    }

    private void RedAuto_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
}