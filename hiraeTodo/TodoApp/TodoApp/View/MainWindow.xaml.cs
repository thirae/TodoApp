using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace TodoApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();

        public MainWindow()
        {
            InitializeComponent();

            TaskDataGrid.ItemsSource = tasks;

            // MVVM用
            // DataContext = new MainWindowVM();
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            tasks.Add(new Task("sssssssssss", "sasa"));
            TaskDataGrid.ItemsSource = tasks;
            // RegisterWindow registerWindow = new RegisterWindow(this);
            // registerWindow.ShowDialog();
        }
    }
}
