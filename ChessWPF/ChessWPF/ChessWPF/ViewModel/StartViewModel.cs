using ChessWPF.Model;
using ChessWPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessWPF.ViewModel
{
	/// <summary>
	/// View Model for StartView.
	/// It allow user to add names for the players and also select the maximum time for the move
	/// </summary>
	/// <seealso cref="ChessWPF.Utils.BindableBase" />
	public class StartViewModel : Utils.BindableBase
    {
        private string player1;
        private string player2;
        private ComboBoxItem selectedItem;

		/// <summary>
		/// Gets or sets the name of the first player.
		/// </summary>
		/// <value>
		/// The first player.
		/// </value>
		public string Player1
        {
            get => player1;
            set => SetProperty(ref player1, value);
        }

		/// <summary>
		/// Gets or sets the name of the second player.
		/// </summary>
		/// <value>
		/// The second player.
		/// </value>
		public string Player2
        {
            get => player2;
            set => SetProperty(ref player2, value);
        }

		/// <summary>
		/// Gets or sets the selected item.
		/// </summary>
		/// <value>
		/// The selected item.
		/// </value>
		public ComboBoxItem SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

		/// <summary>
		/// Gets or sets the white player.
		/// </summary>
		/// <value>
		/// The white player.
		/// </value>
		public Model.Player WhitePlayer { get; set; } = new Model.Player("", Model.Constants.FigureColor.White);

		/// <summary>
		/// Gets or sets the dark player.
		/// </summary>
		/// <value>
		/// The dark player.
		/// </value>
		public Model.Player DarkPlayer { get; set; } = new Model.Player("", Model.Constants.FigureColor.Dark);

		/// <summary>
		/// Gets the click command.
		/// </summary>
		/// <value>
		/// The click command.
		/// </value>
		public ICommand ClickCommand { get; private set; }
		/// <summary>
		/// Occurs when [click].
		/// </summary>
		public event Action Click = delegate { };

		/// <summary>
		/// Initializes a new instance of the <see cref="StartViewModel"/> class.
		/// </summary>
		public StartViewModel()
        {
            ClickCommand = new Utils.RelayCommand(StartClick);
        }

        private void StartClick()
        {
            if (string.IsNullOrWhiteSpace(Player1))
                Player1 = Properties.Resources.White_Player;

            if (string.IsNullOrWhiteSpace(Player2))
                Player2 = Properties.Resources.Dark_Player;
            

            int timer = SelectedItem == null ? 30 : Convert.ToInt32(SelectedItem.Name.Substring(1));
            WhitePlayer.Name = Player1;
            DarkPlayer.Name = Player2;
            WhitePlayer.SecondsForMove = timer;
            DarkPlayer.SecondsForMove = timer;

            List<Player> players = new List<Player>
            {
                WhitePlayer, DarkPlayer
            };

            Mediator.NotifyColleagues("StartGame", players);

            Click();
        }
    }
}
