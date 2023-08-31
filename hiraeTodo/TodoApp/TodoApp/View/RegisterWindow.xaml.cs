using System.Windows;

namespace TodoApp
{
    /// <summary>
    /// Register.xaml の相互作用ロジック
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private MainWindow _mainWindow = null;
        public RegisterWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            InitializeComponent();
        }

        //MainWindowへのデータの受け渡し
        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            // データグリッド書き込み
            _mainWindow.tasks.Add(new Task(DeadlineText.Text, TaskText.Text));
            _mainWindow.TaskDataGrid.ItemsSource = _mainWindow.tasks;

            _mainWindow.FileSave();

            // Windowを閉じる
            Close();
        }
    }
}