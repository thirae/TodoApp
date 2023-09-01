using System;

namespace TodoApp
{
    // DataGridに表示するデータ群
    public class Task
    {
        //タスクチェック
        public bool IsSelected { get; set; }
        //public string IsSelected { get; set; }
        // 期限
        public string DeadLine { get; set; }
        // タスク
        public string Done { get; set; }

        public Task(bool select,string date ,string done)
        {
            IsSelected = select;
            DeadLine = date;
            Done = done;
        }

        //public Task(bool select, string date, string done)
        //{
        //    IsSelected = select.ToString();
        //    DeadLine = date;
        //    Done = done;
        //}
    }
}
