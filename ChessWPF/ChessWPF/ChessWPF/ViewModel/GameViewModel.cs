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
    public class GameViewModel : Utils.BindableBase
    {
        private Player whitePlayer;
        private Player darkPlayer;
        private Player actualPlayer;
        private int baseTimer = 30;
        private int timer = 30;
        DispatcherTimer dispatcherTimer;

        public ICommand ClickCommand { get; private set; }
        public event Action Click = delegate { };

        public GameViewModel() {
            WhitePlayer = new Player("White", Model.Constants.FigureColor.White);
            DarkPlayer = new Player("Dark", Model.Constants.FigureColor.Dark);
            Mediator.Register("StartGame", StartGame);
            Mediator.Register("ChangePlayer", ChangeActualPlayer);
            ClickCommand = new RelayCommand(OnClick);
        }

        private void OnClick()
        {
            StopTimer();
            SetActualPlayer();
            MessageBox.Show($"Zwyciężył {actualPlayer.Name}, gratulacje!", "Rozgrywka zakończona", MessageBoxButton.OK, MessageBoxImage.Information);
            Mediator.NotifyColleagues("EndGame", ActualPlayer);
            Click();
        }

        private void SetActualPlayer() {
            ActualPlayer = WhitePlayer.Equals(ActualPlayer) ? DarkPlayer : WhitePlayer;
        }

        private void ChangeActualPlayer(object message)
        {
            Timer = baseTimer;
            SetActualPlayer();
        }

        public void StartGame(object message)
        {
            List<Player> players = (List<Player>) message;
            WhitePlayer = players[0];
            DarkPlayer = players[1];
            ActualPlayer = whitePlayer;
            BaseTimer = ActualPlayer.SecondsForMove;
            InitTimer();
        }

        private void InitTimer() {
            Timer = BaseTimer;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += new EventHandler(DecrementTimer);
            dispatcherTimer.Start();
        }

        private void StopTimer() {
            dispatcherTimer.Stop();
            Timer = BaseTimer;
        }

        private void DecrementTimer(object sender, EventArgs e)
        {
            if (timer == 0)
            {
                Mediator.NotifyColleagues("ChangePlayer", ActualPlayer);
            } else {
                Timer--;
            }
        }

        public Player WhitePlayer
        {
            get => whitePlayer;
            set => SetProperty(ref whitePlayer, value);
        }

        public Player DarkPlayer
        {
            get => darkPlayer;
            set => SetProperty(ref darkPlayer, value);
        }

        public Player ActualPlayer
        {
            get => actualPlayer;
            set => SetProperty(ref actualPlayer, value);
        }

        public int Timer
        {
            get => timer;
            set => SetProperty(ref timer, value);
        }

        public int BaseTimer
        {
            get => baseTimer;
            set => SetProperty(ref baseTimer, value);
        }
    }
}
