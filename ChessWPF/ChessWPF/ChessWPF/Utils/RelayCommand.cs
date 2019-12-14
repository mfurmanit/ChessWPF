using System;
using System.Windows.Input;

namespace ChessWPF.Utils
{
	class RelayCommand : ICommand
	{
		private Action _action;
		private Func<bool> _canExecute;


		public RelayCommand(Action action)
		{
			if (action == null)
				throw new ArgumentNullException("action cannot be null");

			_action = action;
		}

		public RelayCommand(Action action, Func<bool> canExecute)
		   : this(action)
		{
			if (canExecute == null)
				throw new ArgumentNullException("canExecute cannot be null");

			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _canExecute != null ? _canExecute() : true;
		}

		public void Execute(object parameter)
		{
			_action();
		}

		public void Refresh()
		{
			if (CanExecuteChanged != null)
				CanExecuteChanged(this, EventArgs.Empty);
		}
	}

	class RelayCommand<T> : ICommand
	{
		private Action<T> _action;
		private Func<bool> _canExecute;


		public RelayCommand(Action<T> action)
		{
			if (action == null)
				throw new ArgumentNullException("action cannot be null");

			_action = action;
		}

		public RelayCommand(Action<T> action, Func<bool> canExecute)
		   : this(action)
		{
			if (canExecute == null)
				throw new ArgumentNullException("canExecute cannot be null");

			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _canExecute != null ? _canExecute() : true;
		}

		public void Execute(object parameter)
		{
			_action((T)parameter);
		}

		public void Refresh()
		{
			if (CanExecuteChanged != null)
				CanExecuteChanged(this, EventArgs.Empty);
		}
	}
}
