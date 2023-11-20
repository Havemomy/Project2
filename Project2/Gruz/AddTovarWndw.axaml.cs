using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using Project2.Windows;

namespace Project2.Gruz;

public partial class AddTovarWndw : Window
{
    public string _connString = "server = sql12.freesqldatabase.com; database = sql12661858; port = 3306; User = sql12661858; password = NF2LEehAvp";
    private MySqlConnection _connection;
    public AddTovarWndw()
    {
        Width = 400;
        Height = 300;
        InitializeComponent();
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        string sql = "insert into Gruz (Name, Kolichestvo)" +
                     "values (@name , @kolichestvo)";
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.AddWithValue("name", NameTxt.Text);
        command.Parameters.AddWithValue("kolichestvo", KolvoTxt.Text);
        command.ExecuteNonQuery();
        _connection.Close();
        (Owner as TovarWndw).Showtable();
        Close();
    }
}