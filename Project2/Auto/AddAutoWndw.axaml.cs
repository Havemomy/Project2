using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace Project2.Auto;

public partial class AddAutoWndw : Window
{
    public string _connString = "@server = sql12.freesqldatabase.com; database = sql12661858; port = 3306; User = sql12661858; password = NF2LEehAvp";
    private MySqlConnection _connection;
    public AddAutoWndw()
    {
        InitializeComponent();
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        _connection.Open();
        string sql = " insert into Auto (Marka, Nomer, Rashod)" +
                     "VALUES (@marka, @nomer, @rashod)";
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.AddWithValue("marka", MarkaTxt.Text);
        command.Parameters.AddWithValue("nomer", NomerTxt.Text);
        command.Parameters.AddWithValue("rashod", RashodTxt.Text);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}