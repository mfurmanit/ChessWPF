using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChessWPF.Model.Constants;
using ChessWPF.Utils;
using ChessWPF.ViewModel;

namespace ChessWPF
{
	/// <summary>
	/// Window Model for MainWindow
	/// </summary>
	/// <seealso cref="ChessWPF.Utils.BindableBase" />
	public class MainWindowModel : Utils.BindableBase
	{
		private BoardViewModel boardViewModel = new BoardViewModel();
		private GameViewModel gameViewModel = new GameViewModel();
		private StartViewModel startViewModel = new StartViewModel();
		private bool showStartView = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowModel"/> class.
		/// </summary>
		public MainWindowModel()
		{
			startViewModel.Click += StartViewModel_Start;
			Mediator.Register("EndGame", EndGame);
		}

		private void StartViewModel_Start()
		{
			gameViewModel.WhitePlayer = startViewModel.WhitePlayer;
			gameViewModel.DarkPlayer = startViewModel.DarkPlayer;
			ShowStartView = false;
		}

		private void EndGame(object message)
		{
			ShowStartView = true;
			StartViewModel.Player1 = "";
			StartViewModel.Player2 = "";
			StartViewModel.SelectedItem = null;
		}

		/// <summary>
		/// Gets or sets the board view model.
		/// </summary>
		/// <value>
		/// The board view model.
		/// </value>
		public BoardViewModel BoardViewModel
		{
			get => boardViewModel;
			set => SetProperty(ref boardViewModel, value);
		}

		/// <summary>
		/// Gets or sets the game view model.
		/// </summary>
		/// <value>
		/// The game view model.
		/// </value>
		public GameViewModel GameViewModel
		{
			get => gameViewModel;
			set => SetProperty(ref gameViewModel, value);
		}

		/// <summary>
		/// Gets or sets the start view model.
		/// </summary>
		/// <value>
		/// The start view model.
		/// </value>
		public StartViewModel StartViewModel
		{
			get => startViewModel;
			set => SetProperty(ref startViewModel, value);
		}

		/// <summary>
		/// Gets or sets a value indicating whether [show start view].
		/// </summary>
		/// <value>
		///   <c>true</c> if [show start view]; otherwise, <c>false</c>.
		/// </value>
		public bool ShowStartView
		{
			get => showStartView;
			set => SetProperty(ref showStartView, value);
		}

	}
}
