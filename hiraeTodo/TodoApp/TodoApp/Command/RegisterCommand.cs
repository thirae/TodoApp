using System;
using System.Windows.Input;

namespace TodoApp
{
    class RegisterCommand : ICommand
    {
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
