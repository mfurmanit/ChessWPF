using ChessWPF.Model;
using ChessWPF.Utils;
using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessWPF.ViewModel
{
	/// <summary>
	/// BoardTileViewModel - View model for BoardTileView.
	/// Defines how tile should look like and also defines behavior of the tile
	/// </summary>
	/// <seealso cref="ChessWPF.Utils.BindableBase" />
	/// <seealso cref="System.IEquatable{ChessWPF.ViewModel.BoardTileViewModel}" />
	public class BoardTileViewModel : Utils.BindableBase, IEquatable<BoardTileViewModel>
    {
        private int index;
        private SolidColorBrush background;
        private SolidColorBrush stroke;
        private Cursor cursor = Cursors.Arrow;
        private int strokeThickness;
        private bool isActive;
        private BoardFigure figure;
        private ImageSource figureImage;
        private Position position;

		/// <summary>
		/// Gets the click command.
		/// </summary>
		/// <value>
		/// The click command.
		/// </value>
		public ICommand ClickCommand { get; private set; }
		/// <summary>
		/// Occurs when [click].
		/// </summary>
		public event Action<BoardTileViewModel> Click = delegate { };

		/// <summary>
		/// Gets the mouse enter command.
		/// </summary>
		/// <value>
		/// The mouse enter command.
		/// </value>
		public ICommand MouseEnterCommand { get; private set; }
		/// <summary>
		/// Occurs when [mouse enter].
		/// </summary>
		public event Action<BoardTileViewModel> MouseEnter = delegate { };

		/// <summary>
		/// Gets the mouse leave command.
		/// </summary>
		/// <value>
		/// The mouse leave command.
		/// </value>
		public ICommand MouseLeaveCommand { get; private set; }
		/// <summary>
		/// Occurs when [mouse leave].
		/// </summary>
		public event Action<BoardTileViewModel> MouseLeave = delegate { };

		/// <summary>
		/// Initializes a new instance of the <see cref="BoardTileViewModel"/> class.
		/// </summary>
		/// <param name="figure">The figure.</param>
		/// <param name="index">The index.</param>
		/// <param name="position">The position.</param>
		public BoardTileViewModel(BoardFigure figure, int index, Position position)
        {

            bool isWhite = false;
            int idx = index / 8;
            if (idx % 2 == 0)
                isWhite = index % 2 == 0;
            else
                isWhite = index % 2 == 1;

            Background = isWhite ? StaticResources.WHITE_TILE_COLOR : StaticResources.BLACK_TILE_COLOR;
            Stroke = StaticResources.BORDER_TILE_COLOR;
            StrokeThickness = 1;

            IsActive = false;
            Index = index;
            Figure = figure;
            Position = position;

            ClickCommand = new RelayCommand(OnClick);
            MouseEnterCommand = new RelayCommand(OnMouseEnter);
            MouseLeaveCommand = new RelayCommand(OnMouseLeave);
        }

		private void OnClick()
        {
            Click(this);
        }

        private void OnMouseEnter()
        {
            MouseEnter(this);
        }

        private void OnMouseLeave()
        {
            MouseLeave(this);
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		/// </returns>
		public bool Equals(BoardTileViewModel other)
        {
            return this.Index == other.Index && this.Position == other.Position;
        }

		/// <summary>
		/// Gets or sets the index.
		/// </summary>
		/// <value>
		/// The index.
		/// </value>
		public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }

		/// <summary>
		/// Gets or sets the background.
		/// </summary>
		/// <value>
		/// The background.
		/// </value>
		public SolidColorBrush Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }

		/// <summary>
		/// Gets or sets the stroke.
		/// </summary>
		/// <value>
		/// The stroke.
		/// </value>
		public SolidColorBrush Stroke
        {
            get => stroke;
            set => SetProperty(ref stroke, value);
        }

		/// <summary>
		/// Gets or sets the cursor.
		/// </summary>
		/// <value>
		/// The cursor.
		/// </value>
		public Cursor Cursor
        {
            get => cursor;
            set => SetProperty(ref cursor, value);
        }

		/// <summary>
		/// Gets or sets the stroke thickness.
		/// </summary>
		/// <value>
		/// The stroke thickness.
		/// </value>
		public int StrokeThickness
        {
            get => strokeThickness;
            set => SetProperty(ref strokeThickness, value);
        }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is active.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
		/// </value>
		public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }

		/// <summary>
		/// Gets or sets the figure.
		/// </summary>
		/// <value>
		/// The figure.
		/// </value>
		public BoardFigure Figure
        {
            get => figure;
            set
            {
                SetProperty(ref figure, value);
				if (figure != null)
					ImageSource = GetFigureBitmapImage();
				else
					ImageSource = null;
            }
        }

		private BitmapImage GetFigureBitmapImage()
		{
			if (figure == null)
				return null;

			string path = "";
			if (figure.Color == Model.Constants.FigureColor.White)
			{
				switch (figure.Type)
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
			else if (figure.Color == Model.Constants.FigureColor.Dark)
			{
				switch (figure.Type)
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

		/// <summary>
		/// Gets or sets the figure image.
		/// </summary>
		/// <value>
		/// The image source.
		/// </value>
		public ImageSource ImageSource
        {
            get => figureImage;
            set => SetProperty(ref figureImage, value);
        }

		/// <summary>
		/// Gets or sets the position on the board.
		/// </summary>
		/// <value>
		/// The position.
		/// </value>
		public Position Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }
    }
}
