using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TodoApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> tasks;

        // ファイルパス
        private string csvPath = "save.csv";

        public MainWindow()
        {
            InitializeComponent();

            tasks = ReadCsvFile(csvPath);
            TaskDataGrid.ItemsSource = tasks;
        }

        // CsvFile読み込み
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

                        // 登録
                        collection.Add(new Task(cells[1], cells[2]));
                    }
                }
            }
            catch (Exception ex)
            {
                // エラー内容を出力
                Debug.WriteLine(ex.Message);
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
                // 列ヘッダ
                sw.WriteLine(string.Join(",",TaskDataGrid.Columns
                    .Select(x =>
                    {
                        if (x.Header is string headerText)
                        {
                            return headerText;
                        }
                        //else if (TaskDataGrid)
                        //{
                        //
                        //}
                        else
                        {
                            return string.Empty;
                        }
                    })));

                // セルの内容
                foreach (var item in TaskDataGrid.Items)
                {
                    sw.WriteLine(string.Join(",",TaskDataGrid.Columns
                        .Select(x => x.OnCopyingCellClipboardContent(item)?.ToString())));
                }
            }
        }

        /// <summary>
        /// 
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
    }
}
