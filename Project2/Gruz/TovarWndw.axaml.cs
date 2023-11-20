using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using Project2.Gruz;
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
        Width = 400;
        Height = 300;
    }

    public void Showtable()
    {
        string sql = " select GruzID, Kolichestvo, Name from Gruz";
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
                Count = reader.GetInt32(column:"Kolichestvo")
            };
            _tovars.Add(currentGruz);
        }
        _connection.Close();
        TovarGrid.ItemsSource = _tovars;
    }
    private void Delete(int id)
    {
        _connection.Open();
        string sql = " delete from Gruz where GruzID = @id";
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
        Showtable();
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }

    private void AddTovar_OnClick(object? sender, RoutedEventArgs e)
    {
        AddTovarWndw addTovarWndw = new AddTovarWndw();
        addTovarWndw.Show(owner:this);
    }

    private void DelTovar_OnClick(object? sender, RoutedEventArgs e)
    {
        Delete((TovarGrid.SelectedItem as Models.Tovar).GruzID);
        
    }
}