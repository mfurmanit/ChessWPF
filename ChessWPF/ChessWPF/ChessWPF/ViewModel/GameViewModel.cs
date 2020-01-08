using ChessWPF.Model;
using ChessWPF.Model.Constants;
using ChessWPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ChessWPF.ViewModel
{
	/// <summary>
	/// View Model for GameView
	/// View show information about the game (e.g information about the players)
	/// </summary>
	/// <seealso cref="ChessWPF.Utils.BindableBase" />
	public class GameViewModel : Utils.BindableBase
	{
		private Player whitePlayer;
		private Player darkPlayer;
		private Player actualPlayer;
		private int baseTimer = 30;
		private int timer = 30;
		DispatcherTimer dispatcherTimer;

		/// <summary>
		/// Gets the click command.
		/// </summary>
		/// <value>
		/// The click command.
		/// </value>
		public ICommand ClickCommand { get; private set; }

		/// <summary>
		/// Occurs when player whant to give up.
		/// </summary>
		public event Action Click = delegate { };

		/// <summary>
		/// Initializes a new instance of the <see cref="GameViewModel"/> class.
		/// </summary>
		public GameViewModel()
		{
			WhitePlayer = new Player(Properties.Resources.White_Player, FigureColor.White);
			DarkPlayer = new Player(Properties.Resources.Dark_Player, FigureColor.Dark);
			Mediator.Register("StartGame", StartGame);
			Mediator.Register("ChangePlayer", ChangeActualPlayer);
			ClickCommand = new RelayCommand(OnClick);
		}

		private void OnClick()
		{
			string message = String.Format(Properties.Resources.Winner_Dialog_Info, actualPlayer.Name);
			string title = Properties.Resources.Winner_Dialog_Title;
			StopTimer();
			SetActualPlayer();
			MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
			Mediator.NotifyColleagues("EndGame", ActualPlayer);
			Click();
		}

		private void SetActualPlayer()
		{
			ActualPlayer = WhitePlayer.Equals(ActualPlayer) ? DarkPlayer : WhitePlayer;
		}

		private void ChangeActualPlayer(object message)
		{
			Timer = baseTimer;
			SetActualPlayer();
		}

		/// <summary>
		/// Starts the game.
		/// </summary>
		/// <param name="message">The message.</param>
		public void StartGame(object message)
		{
			List<Player> players = (List<Player>)message;
			WhitePlayer = players[0];
			DarkPlayer = players[1];
			ActualPlayer = whitePlayer;
			BaseTimer = ActualPlayer.SecondsForMove;
			InitTimer();
		}

		private void InitTimer()
		{
			Timer = BaseTimer;
			dispatcherTimer = new DispatcherTimer();
			dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
			dispatcherTimer.Tick += new EventHandler(DecrementTimer);
			dispatcherTimer.Start();
		}

		private void StopTimer()
		{
			dispatcherTimer.Stop();
			Timer = BaseTimer;
		}

		private void DecrementTimer(object sender, EventArgs e)
		{
			if (timer == 0)
			{
				Mediator.NotifyColleagues("ChangePlayer", ActualPlayer);
			}
			else
			{
				Timer--;
			}
		}

		/// <summary>
		/// Gets or sets the white player.
		/// </summary>
		/// <value>
		/// The white player.
		/// </value>
		public Player WhitePlayer
		{
			get => whitePlayer;
			set => SetProperty(ref whitePlayer, value);
		}

		/// <summary>
		/// Gets or sets the dark player.
		/// </summary>
		/// <value>
		/// The dark player.
		/// </value>
		public Player DarkPlayer
		{
			get => darkPlayer;
			set => SetProperty(ref darkPlayer, value);
		}

		/// <summary>
		/// Gets or sets the actual player.
		/// </summary>
		/// <value>
		/// The actual player.
		/// </value>
		public Player ActualPlayer
		{
			get => actualPlayer;
			set => SetProperty(ref actualPlayer, value);
		}

		/// <summary>
		/// Gets or sets the timer.
		/// </summary>
		/// <value>
		/// The timer.
		/// </value>
		public int Timer
		{
			get => timer;
			set => SetProperty(ref timer, value);
		}

		/// <summary>
		/// Gets or sets the base timer.
		/// </summary>
		/// <value>
		/// The base timer.
		/// </value>
		public int BaseTimer
		{
			get => baseTimer;
			set => SetProperty(ref baseTimer, value);
		}
	}
}
