using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessWPF.Utils
{
	public class BindableBase : INotifyPropertyChanged
	{
		protected virtual void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(member, value))
				return;

			member = value;
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}
