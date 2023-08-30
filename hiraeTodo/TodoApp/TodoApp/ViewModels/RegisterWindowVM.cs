using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoApp.ViewModels
{
    // MVVMのView Model は、必ずINotifyPropertyChangedを継承するルールがある。
    class RegisterWindowVM : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        // View Modelのルールとして実装しておくイベントハンドラ
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));

        // 変更通知
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        // コマンドを格納するプロパティ
        public RegisterCommand RegisterCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RegisterWindowVM()
        {
            // コマンドを実装したクラスをプロパティに代入
            RegisterCommand = new RegisterCommand(this);
        }

        // タスクTextboxの入力プロパティ
        private string _Task;
        public string Task
        {
            get { return _Task; }
            set { if (_Task != value) { _Task = value; RaisePropertyChanged(); } }
        }

        // 日付Textboxの入力プロパティ
        private string _Date;
        public string Date
        {
            get { return _Date; }
            set { if (_Date != value) { _Date = value; RaisePropertyChanged(); } }
        }
    }
}
