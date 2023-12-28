using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Helpers;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoViewModel : ChangeNotifier
    {
        public string Title { get { return $"Todo({todoModels.Count(x=>!x.IsDone)}) Completed({todoModels.Count(x => x.IsDone)})"; }  }
        private ObservableCollection<TodoModel> todoModels = new ObservableCollection<TodoModel>();

		public ObservableCollection<TodoModel> TodoModels
		{
			get { return todoModels; }
			set { todoModels = value; }
		}
		private string _newTodo;

        public string NewTodo
		{
			get { return _newTodo; }
            set { _newTodo = value; OnPropertyChanged(nameof(NewTodo)); }
		}

        public ICommand AddCommand { get; set; }
        internal void AddTodo(object? param)
        {
           if(string.IsNullOrEmpty(_newTodo)) return;
           TodoModel todo = new TodoModel { Title = _newTodo };
            todo.PropertyChanged += Todo_PropertyChanged;
            TodoModels.Add(todo);
            NewTodo = string.Empty;
            OnPropertyChanged(nameof(Title));
        }

        private void Todo_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Title));
        }

        public TodoViewModel()
        {
            AddCommand = new GenericCommand(AddTodo);
        }
    }
}
