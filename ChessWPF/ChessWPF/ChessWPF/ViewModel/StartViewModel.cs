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
    public class StartViewModel : Utils.BindableBase
    {
        private string player1;
        private string player2;
        private ComboBoxItem selectedItem;
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

        public ComboBoxItem SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
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
