using System;

namespace TodoApp.Models
{
    // DataGridに表示するデータ群
    public class Task
    {
        // 期限
        public DateTime Date { get; set; }
        // タスク
        public string Done { get; set; }
        // 優先度
        public int Priority { get; set; }
    }
}
