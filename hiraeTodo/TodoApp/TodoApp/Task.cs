using System;

namespace TodoApp
{
    // DataGridに表示するデータ群
    public class Task
    {
        public Task(string date ,string done)
        {
            DeadLine = date;
            Done = done;
        }
        // 期限
        public string DeadLine { get; set; }
        // タスク
        public string Done { get; set; }
    }
}
