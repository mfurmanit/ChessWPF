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
    public class MainWindowModel : Utils.BindableBase
    {
        private BoardViewModel boardViewModel = new BoardViewModel();
        private GameViewModel gameViewModel = new GameViewModel();
        private StartViewModel startViewModel = new StartViewModel();
        private bool showStartView = true;

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

        public BoardViewModel BoardViewModel
        {
            get => boardViewModel;
            set => SetProperty(ref boardViewModel, value);
        }

        public GameViewModel GameViewModel
        {
            get => gameViewModel;
            set => SetProperty(ref gameViewModel, value);
        }

        public StartViewModel StartViewModel
        {
            get => startViewModel;
            set => SetProperty(ref startViewModel, value);
        }

        public bool ShowStartView
        {
            get => showStartView;
            set => SetProperty(ref showStartView, value);
        }

    }
}
