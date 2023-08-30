//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Windows;
//using System;
//
//namespace TodoApp
//{
//    /// <summary>
//    /// Register.xaml の相互作用ロジック
//    /// </summary>
//    public partial class RegisterWindow : Window
//    {
//        private MainWindow _mainWindow = null;
//        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();
//        public RegisterWindow(MainWindow mainWindow)
//        {
//            _mainWindow = mainWindow;
//
//            InitializeComponent();
//
//            // MVVM
//            // DataContext = new RegisterWindowVM();
//        }
//
//        //MainWindowへのデータの受け渡し
//        private void RegButtonClick(object sender, RoutedEventArgs e)
//        {
//            tasks.Add(new Task(DeadlineText.Text, TaskText.Text));
//            _mainWindow.TaskDataGrid.ItemsSource = new ObservableCollection<Task>();
//            //_mainWindow.TaskDataGrid.ItemsSource = tasks;
//            Close();
//        }
//
//    }
//}
