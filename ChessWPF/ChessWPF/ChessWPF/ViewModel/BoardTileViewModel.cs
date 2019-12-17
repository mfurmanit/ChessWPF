using ChessWPF.Model;
using ChessWPF.Utils;
using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessWPF.ViewModel
{
    class BoardTileViewModel : Utils.BindableBase, IEquatable<BoardTileViewModel>
    {
        private int index;
        private SolidColorBrush background;
        private SolidColorBrush stroke;
        private int strokeThickness;
        private bool isActive;
        private BoardFigure figure;
        private ImageSource figureImage;
        private Position position;

        public ICommand ClickCommand { get; private set; }
        public event Action<BoardTileViewModel> Click = delegate { };

        public ICommand MouseEnterCommand { get; private set; }
        public event Action<BoardTileViewModel> MouseEnter = delegate { };

        public ICommand MouseLeaveCommand { get; private set; }
        public event Action<BoardTileViewModel> MouseLeave = delegate { };

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

        public bool Equals(BoardTileViewModel other)
        {
            return this.Index == other.Index && this.Position == other.Position;
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

        public int StrokeThickness
        {
            get => strokeThickness;
            set => SetProperty(ref strokeThickness, value);
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

        public ImageSource ImageSource
        {
            get => figureImage;
            set => SetProperty(ref figureImage, value);
        }

        public Position Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }
    }
}
