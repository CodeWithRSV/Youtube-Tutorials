using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.ViewModels;

namespace TodoList.Helpers
{
    internal class GenericCommand : ICommand
    {
        private readonly Action<object?> executeAction;

        public event EventHandler? CanExecuteChanged;
        public GenericCommand(Action<object?> executeAction)
        {
            this.executeAction = executeAction;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            executeAction?.Invoke(parameter);
        }
    }
}
