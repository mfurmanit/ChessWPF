using ChessWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessWPF.ViewModel
{
	class BoardTileViewModel : Utils.BindableBase
	{
		private int index;
		private SolidColorBrush background;
		private SolidColorBrush stroke;
		private bool isActive;
		private BoardFigure figure;

		public ICommand ClickCommand { get; private set; }
		public event Action<BoardTileViewModel> Click = delegate { };

		public BoardTileViewModel(BoardFigure figure, int index)
		{
			SolidColorBrush BLACK_TILE_COLOR = Brushes.LightSteelBlue;
			SolidColorBrush WHITE_TILE_COLOR = Brushes.White;
			SolidColorBrush BORDER_TILE_COLOR = Brushes.Black;

			bool isWhite = false;
			int idx = index / 8;
			if (idx % 2 == 0)
				isWhite = index % 2 == 0;
			else
				isWhite = index % 2 == 1;

			Background = isWhite ? WHITE_TILE_COLOR : BLACK_TILE_COLOR;
			Stroke = BORDER_TILE_COLOR;

			IsActive = false;
			Index = index;
			Figure = figure;

			ClickCommand = new Utils.RelayCommand(OnClick);
		}

		private void OnClick()
		{
			Click(this);
		}

		public int Index
		{
			get => index;
			set => SetProperty(ref index, value);
		}

		public SolidColorBrush Background
		{
			get => background;
			set => SetProperty(ref background, value);
		}

		public SolidColorBrush Stroke
		{
			get => stroke;
			set => SetProperty(ref stroke, value);
		}

		public bool IsActive
		{
			get => isActive;
			set => SetProperty(ref isActive, value);
		}

		public BoardFigure Figure
		{
			get => figure;
			set
			{
				SetProperty(ref figure, value);
				if (figure != null)
					ImageSource = new BitmapImage(new Uri(Figure.Path, UriKind.Relative));
				else
					ImageSource = null;
			}
		}

		private ImageSource figureImage;
		public ImageSource ImageSource
		{
			get => figureImage;
			set => SetProperty(ref figureImage, value);

		}
	}
}
