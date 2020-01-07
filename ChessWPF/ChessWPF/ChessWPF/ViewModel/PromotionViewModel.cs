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
	/// <summary>
	/// Item for the ListBox
	/// </summary>
	public class ListBoxItem
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ListBoxItem"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="color">The color.</param>
		public ListBoxItem(Model.Constants.FigureType type, Model.Constants.FigureColor color)
		{
			Type = type;
			Color = color;

			Image = GetFigureBitmapImage();
		}

		/// <summary>
		/// Gets or sets the type of the figure.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public Model.Constants.FigureType Type { get; set; }

		/// <summary>
		/// Gets or sets the color of the figure.
		/// </summary>
		/// <value>
		/// The color.
		/// </value>
		public Model.Constants.FigureColor Color { get; set; }

		/// <summary>
		/// Gets the name of the figure.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name
		{
			get { return ToString(); }
		}

		/// <summary>
		/// Gets the image of the figure.
		/// </summary>
		/// <value>
		/// The image.
		/// </value>
		public ImageSource Image { get; private set; }

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
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

	/// <summary>
	/// View Model for PromotionView
	/// PromotionView is shown when promotion occured (e.g white pawn move to position X8).
	/// </summary>
	/// <seealso cref="ChessWPF.Utils.BindableBase" />
	public class PromotionViewModel : BindableBase
	{
		/// <summary>
		/// Occurs when user click OK button.
		/// </summary>
		public event Action Promotion = delegate { };

		/// <summary>
		/// Gets the ok command.
		/// </summary>
		/// <value>
		/// The ok command.
		/// </value>
		public RelayCommand OKCommand { get; private set; }

		private readonly Model.BoardFigure _figure;

		/// <summary>
		/// Initializes a new instance of the <see cref="PromotionViewModel"/> class.
		/// </summary>
		/// <param name="figure">The figure.</param>
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

		/// <summary>
		/// Gets or sets the figures.
		/// </summary>
		/// <value>
		/// The figures.
		/// </value>
		public ObservableCollection<ListBoxItem> Figures
		{
			get { return _Figures; }
			set { SetProperty(ref _Figures, value); }
		}


		ListBoxItem _SelectedFigure;
		/// <summary>
		/// Gets or sets the selected figure.
		/// </summary>
		/// <value>
		/// The selected figure.
		/// </value>
		public ListBoxItem SelectedFigure
		{
			get { return _SelectedFigure; }
			set { SetProperty(ref _SelectedFigure, value); }
		}

	}
}
