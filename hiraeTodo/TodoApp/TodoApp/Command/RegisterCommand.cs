using System;
using System.Windows;
using System.Windows.Input;
using TodoApp.ViewModels;

namespace TodoApp
{
    class RegisterCommand : ICommand
    {
        /// <summary>
        /// コマンドを読み出す側のクラス（View Model）を保持するプロパティ
        /// </summary>
        private RegisterWindowVM _view { get; set; }

        /// <summary>
        /// コンストラクタ
        /// コマンドで処理したいクラス(View Model)をここで受け取る
        /// </summary>
        /// <param name="view"></param>
        public RegisterCommand(RegisterWindowVM view)
        {
            _view = view;
        }

        /// <summary>
        /// コマンドのルールとして必ず実装しておくイベントハンドラ
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// コマンドの有効／無効を判定するメソッド
        /// コマンドのルールとして必ず実装しておくメソッド
        /// 有効／無効を制御する必要が無ければ、無条件にTrueを返しておく
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// コマンドの動作を定義するメソッド
        /// 記入した内容を登録する
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {

        }
    }
}
