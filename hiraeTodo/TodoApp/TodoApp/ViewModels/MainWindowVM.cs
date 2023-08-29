using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace TodoApp.ViewModels
{
    // MVVMのView Model は、必ずINotifyPropertyChangedを継承するルールがある。
    class MainWindowVM : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        // View Modelのルールとして実装しておくイベントハンドラ
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

        // コマンドを格納するプロパティ
        public ShowWindowCommand RegisterCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowVM()
        {
            RegisterCommand = new ShowWindowCommand(this);
        }
    }
}
