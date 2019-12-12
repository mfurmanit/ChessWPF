using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessWPF.ViewModel;

namespace ChessWPF
{
	class MainWindowModel : Utils.BindableBase
	{
		private BoardViewModel boardViewModel = new BoardViewModel();

		public BoardViewModel BoardViewModel
		{
			get => boardViewModel;
			set => SetProperty(ref boardViewModel, value);
		}

	}
}
