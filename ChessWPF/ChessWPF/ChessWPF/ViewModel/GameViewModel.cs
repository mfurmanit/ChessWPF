using ChessWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWPF.ViewModel
{
    public class GameViewModel : Utils.BindableBase
    {
        private Player firstPlayer;
        private Player secondPlayer;

        public GameViewModel() {
            FirstPlayer = new Player("Tomasz", Model.Constants.FigureColor.Dark);
            SecondPlayer = new Player("Marcin", Model.Constants.FigureColor.White);
        }

        public Player FirstPlayer
        {
            get => firstPlayer;
            set => SetProperty(ref firstPlayer, value);
        }

        public Player SecondPlayer
        {
            get => secondPlayer;
            set => SetProperty(ref secondPlayer, value);
        }
    }
}
