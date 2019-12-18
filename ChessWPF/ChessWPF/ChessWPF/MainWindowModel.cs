using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessWPF.ViewModel;

namespace ChessWPF
{
	public class MainWindowModel : Utils.BindableBase
	{
		private BoardViewModel boardViewModel = new BoardViewModel();
		private GameViewModel gameViewModel = new GameViewModel();

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

    }
}
