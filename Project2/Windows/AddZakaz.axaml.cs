using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;

using Project2.Models;

namespace Project2.Windows;

public partial class AddZakaz : Window
{
    
    private List<Zakaz> _orders;
    public AddZakaz()
    {
        InitializeComponent();
        Width = 400;
        Height = 450;
    }

    private void BackOnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }

    //private void AddOnClick(object? sender, RoutedEventArgs e)
    //{
    //    string ClientAdded = ClientTextBox.Text;
    //    string Auto = AutoTextBox.Text;
    //    string Gruz = GruzTextBox.Text;
    //    string Status = StatusTextBlock.Name;
    //    string sql = " insert into Zakaz (ClientAdded, Auto, Gruz, Status) " +
    //                 " values (@ClientAdded, @Auto, @Gruz, @Status);";
    //}
}