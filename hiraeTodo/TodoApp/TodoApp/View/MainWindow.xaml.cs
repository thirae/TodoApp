using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TodoApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // ファイルパス
        private string csvPath = "save.csv";
        public ObservableCollection<Task> tasks;

        public MainWindow()
        {
            InitializeComponent();

            tasks = ReadCsvFile(csvPath);
            TaskDataGrid.ItemsSource = tasks;
        }

        /// <summary>
        /// ファイル読み込みメソッド
        /// </summary>
        /// <param name="filePath">csvファイルのパス</param>
        /// <returns></returns>
        public ObservableCollection<Task> ReadCsvFile(string filePath)
        {
            var collection = new ObservableCollection<Task>();

            try
            {
                // 引数のパスにファイルが存在するか
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("ファイルが見つかりません");
                }

                // 行データをカンマ区切りで分割するようにファイルオープン
                using (var parser = new TextFieldParser(filePath))
                {
                    parser.Delimiters = new string[] { "," };
                    // 最終行まで繰り返す
                    while (!parser.EndOfData)
                    {
                        // 文字列中の前後スペースを削除しない
                        parser.TrimWhiteSpace = false;

                        // カンマで分割した文字列の配列を取得
                        var cells = parser.ReadFields();

                        bool isTrue = bool.Parse(cells[0]);

                        // 登録
                        collection.Add(new Task(isTrue,cells[1], cells[2]));
                    }
                }
            }
            catch (Exception ex)
            {
                // エラー内容を出力
                Debug.WriteLine("エラーが発生しました: ",ex.Message);
            }
            return collection;
        }

        /// <summary>
        /// ファイル書き込みメソッド
        /// </summary>
        public void FileSave()
        {
            // 書き込み処理
            using (var sw = new StreamWriter(csvPath,false, Encoding.Unicode))
            {
                // セルの内容
                foreach (var item in tasks)
                {
                    sw.WriteLine($"{item.IsSelected},{item.DeadLine},{item.Done}");
                }
            }
        }

        /// <summary>
        /// タスク削除ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Tag as Task;
            tasks.Remove(tag);
            FileSave();
        }

        /// <summary>
        /// 登録ボタンを押した際のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            // 登録画面に遷移
            RegisterWindow registerWindow = new RegisterWindow(this);
            registerWindow.ShowDialog();
        }

        /// <summary>
        /// セルが更新したら起きるイベント(フォーカスを失ったら)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskDataGrid_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            FileSave();
        }

        /// <summary>
        /// チェックボックスをクリックした際のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Clicked(object sender, RoutedEventArgs e)
        {
            FileSave();
        }

        /// <summary>
        /// 編集の際カンマが入力されたらキャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
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
