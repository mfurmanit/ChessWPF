using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessWPF.Utils
{
	/// <summary>
	/// BindableBase - utilities for helping implement interface INotifyPropertyChanged
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class BindableBase : INotifyPropertyChanged
	{
		/// <summary>
		/// Sets the property and notify if property was changed
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="member">The member.</param>
		/// <param name="value">The value.</param>
		/// <param name="propertyName">Name of the property.</param>
		protected virtual void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(member, value))
				return;

			member = value;
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Notify that property was changed.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Raises the property changed.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		public void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}
