using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TodoApp.ViewModels
{
    // MVVMのView Model は、必ずINotifyPropertyChangedを継承するルールがある。
    class RegisterWindowVM : INotifyPropertyChanged
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
        public RegisterWindowVM()
        {
            
        }
    }
}
