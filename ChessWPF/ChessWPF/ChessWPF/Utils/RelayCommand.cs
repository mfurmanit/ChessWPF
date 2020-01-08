using System;
using System.Windows.Input;

namespace ChessWPF.Utils
{
	/// <summary>
	/// Utilities for helping implement interface ICommand
	/// </summary>
	/// <seealso cref="System.Windows.Input.ICommand" />
	public class RelayCommand : ICommand
	{
		private Action _action;
		private Func<bool> _canExecute;

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <exception cref="ArgumentNullException">action cannot be null</exception>
		public RelayCommand(Action action)
		{
			if (action == null)
				throw new ArgumentNullException("action cannot be null");

			_action = action;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="canExecute">The can execute.</param>
		/// <exception cref="ArgumentNullException">canExecute cannot be null</exception>
		public RelayCommand(Action action, Func<bool> canExecute)
		   : this(action)
		{
			if (canExecute == null)
				throw new ArgumentNullException("canExecute cannot be null");

			_canExecute = canExecute;
		}

		/// <summary>
		/// Occurs when changes occur that affect whether or not the command should execute.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// Defines the method that determines whether the command can execute in its current state.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
		/// </returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute != null ? _canExecute() : true;
		}

		/// <summary>
		/// Defines the method to be called when the command is invoked.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		public void Execute(object parameter)
		{
			_action();
		}

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		public void Refresh()
		{
			if (CanExecuteChanged != null)
				CanExecuteChanged(this, EventArgs.Empty);
		}
	}

	/// <summary>
	/// Utilities for helping implement interface ICommand
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="System.Windows.Input.ICommand" />
	class RelayCommand<T> : ICommand
	{
		private Action<T> _action;
		private Func<bool> _canExecute;

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <exception cref="ArgumentNullException">action cannot be null</exception>
		public RelayCommand(Action<T> action)
		{
			if (action == null)
				throw new ArgumentNullException("action cannot be null");

			_action = action;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="canExecute">The can execute.</param>
		/// <exception cref="ArgumentNullException">canExecute cannot be null</exception>
		public RelayCommand(Action<T> action, Func<bool> canExecute)
		   : this(action)
		{
			if (canExecute == null)
				throw new ArgumentNullException("canExecute cannot be null");

			_canExecute = canExecute;
		}

		/// <summary>
		/// Occurs when changes occur that affect whether or not the command should execute.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// Defines the method that determines whether the command can execute in its current state.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
		/// </returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute != null ? _canExecute() : true;
		}

		/// <summary>
		/// Defines the method to be called when the command is invoked.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		public void Execute(object parameter)
		{
			_action((T)parameter);
		}

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		public void Refresh()
		{
			if (CanExecuteChanged != null)
				CanExecuteChanged(this, EventArgs.Empty);
		}
	}
}
