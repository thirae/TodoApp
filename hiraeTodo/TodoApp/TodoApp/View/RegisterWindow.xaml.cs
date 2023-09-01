using System.Windows;
using System.Windows.Input;

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

        /// <summary>
        ///  MainWindowへのデータの受け渡しボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            // データグリッド書き込み
            _mainWindow.tasks.Add(new Task(false,DeadlineText.Text, TaskText.Text));
            _mainWindow.TaskDataGrid.ItemsSource = _mainWindow.tasks;

            _mainWindow.FileSave();

            // Windowを閉じる
            Close();
        }

        /// <summary>
        /// 入力チェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 入力されたテキストにカンマが含まれているかをチェック
            if (e.Text.Contains(","))
            {
                e.Handled = true; // カンマが含まれている場合、入力をキャンセル
            }
        }

        /// <summary>
        /// ペーストを禁止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                e.Handled = true; // Ctrl+V キー操作をキャンセル
            }
        }
    }
}