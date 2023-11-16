using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using Project2.Models;
using Tmds.DBus.Protocol;

namespace Project2.Windows;

public partial class AddZakaz : Window
{
    public AddZakaz()
    {
        InitializeComponent();
        Width = 400;
        Height = 450;
    }
    
    
    private void AddBtnOnClick(object? sender, RoutedEventArgs e)
    {
        
    }
    
    
    private void BackOnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }

    
}