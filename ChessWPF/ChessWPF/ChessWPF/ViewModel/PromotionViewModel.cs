using ChessWPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessWPF.ViewModel
{
	public class ListBoxItem
	{
		public ListBoxItem(Model.Constants.FigureType type, Model.Constants.FigureColor color)
		{
			Type = type;
			Color = color;

			Image = GetFigureBitmapImage();
		}

		public Model.Constants.FigureType Type { get; set; }
		public Model.Constants.FigureColor Color { get; set; }

		public string Name
		{
			get { return ToString(); }
		}

		public ImageSource Image { get; private set; }
		public override string ToString()
		{
			switch (Type)
			{
				case Model.Constants.FigureType.Knight:
					return Properties.Resources.Knight;
				case Model.Constants.FigureType.Bishop:
					return Properties.Resources.Bishop;
				case Model.Constants.FigureType.Queen:
					return Properties.Resources.Queen;
				case Model.Constants.FigureType.Rook:
					return Properties.Resources.Rook;
				default:
					break;
			}

			return "";
		}

		private BitmapImage GetFigureBitmapImage()
		{
			string path = "";
			if (Color == Model.Constants.FigureColor.White)
			{
				switch (Type)
				{
					case Model.Constants.FigureType.Pawn:
						path = "/Resources/Figures/pawn_white.png";
						break;
					case Model.Constants.FigureType.Knight:
						path = "/Resources/Figures/knight_white.png";
						break;
					case Model.Constants.FigureType.Bishop:
						path = "/Resources/Figures/bishop_white.png";
						break;
					case Model.Constants.FigureType.Queen:
						path = "/Resources/Figures/queen_white.png";
						break;
					case Model.Constants.FigureType.King:
						path = "/Resources/Figures/king_white.png";
						break;
					case Model.Constants.FigureType.Rook:
						path = "/Resources/Figures/rook_white.png";
						break;
					default:
						break;
				}
			}
			else if (Color == Model.Constants.FigureColor.Dark)
			{
				switch (Type)
				{
					case Model.Constants.FigureType.Pawn:
						path = "/Resources/Figures/pawn_dark.png";
						break;
					case Model.Constants.FigureType.Knight:
						path = "/Resources/Figures/knight_dark.png";
						break;
					case Model.Constants.FigureType.Bishop:
						path = "/Resources/Figures/bishop_dark.png";
						break;
					case Model.Constants.FigureType.Queen:
						path = "/Resources/Figures/queen_dark.png";
						break;
					case Model.Constants.FigureType.King:
						path = "/Resources/Figures/king_dark.png";
						break;
					case Model.Constants.FigureType.Rook:
						path = "/Resources/Figures/rook_dark.png";
						break;
					default:
						break;
				}
			}
			return new BitmapImage(new Uri(path, UriKind.Relative));
		}
	}
	public class PromotionViewModel : BindableBase
	{
		public event Action Promotion = delegate { };
		public RelayCommand OKCommand { get; private set; }

		private readonly Model.BoardFigure _figure;
		public PromotionViewModel(Model.BoardFigure figure)
		{
			_figure = figure;

			Figures = new ObservableCollection<ListBoxItem>();
			SelectedFigure = new ListBoxItem(Model.Constants.FigureType.Queen, figure.Color);
			Figures.Add(SelectedFigure);

			Figures.Add(new ListBoxItem(Model.Constants.FigureType.Rook, figure.Color));
			Figures.Add(new ListBoxItem(Model.Constants.FigureType.Knight, figure.Color));
			Figures.Add(new ListBoxItem(Model.Constants.FigureType.Bishop, figure.Color));

			OKCommand = new RelayCommand(OnOK);
		}

		private void OnOK()
		{
			Promotion();
		}

		private ObservableCollection<ListBoxItem> _Figures;
		public ObservableCollection<ListBoxItem> Figures
		{
			get { return _Figures; }
			set { SetProperty(ref _Figures, value); }
		}


		ListBoxItem _SelectedFigure;
		public ListBoxItem SelectedFigure
		{
			get { return _SelectedFigure; }
			set { SetProperty(ref _SelectedFigure, value); }
		}

	}
}
