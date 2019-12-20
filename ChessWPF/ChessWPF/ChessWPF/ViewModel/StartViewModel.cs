using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChessWPF.ViewModel
{
	public class StartViewModel : Utils.BindableBase
	{
		string player1;
		string player2;
		public string Player1
		{
			get => player1;
			set => SetProperty(ref player1, value);
		}
		public string Player2
		{
			get => player2;
			set => SetProperty(ref player2, value);
		}

		public Model.Player WhitePlayer { get; set; } = new Model.Player("", Model.Constants.FigureColor.White);
		public Model.Player DarkPlayer { get; set; } = new Model.Player("", Model.Constants.FigureColor.Dark);

		public ICommand ClickCommand { get; private set; }
		public event Action Click = delegate { };

		public StartViewModel()
		{
			ClickCommand = new Utils.RelayCommand(StartClick);
		}

		private void StartClick()
		{
			if (string.IsNullOrWhiteSpace(Player1))
				Player1 = "White";

			if (string.IsNullOrWhiteSpace(Player2))
				Player2 = "Black";

			WhitePlayer.Name = Player1;
			DarkPlayer.Name = Player2;

			Click();
		}
	}
}
