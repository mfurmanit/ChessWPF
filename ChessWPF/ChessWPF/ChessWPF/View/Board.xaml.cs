using ChessWPF.ViewModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Input;
using System.Windows;
using ChessWPF.Model;
using System.Collections.ObjectModel;
using ChessWPF.Model.Constants;

namespace ChessWPF.Views
{
    public partial class Board : UserControl
    {

        private ObservableCollection<BoardFigure> Pieces { get; set; }

        public Board()
        {
            InitializeComponent();
            DrawTilesOnBoard();
        }

        private void DrawTilesOnBoard()
        {
            DataContext = Pieces;
            BoardViewModel model = new BoardViewModel();
            model.BoardTiles.ForEach(tile =>
            {

                //Canvas canvas = new Canvas();
                //canvas.Name = "CANVAS_" + tile.Index.ToString();

                //Rectangle rect = new Rectangle
                //{
                //    Width = 80,
                //    Height = 80,
                //    Name = "Tile" + tile.Index,
                //    Stroke = tile.Stroke,
                //    Fill = tile.Background
                //};

                //UniformGrid.Children.Add(rect);

                //Canvas.SetZIndex(rect, 1);
                //canvas.Children.Add(rect);

                //if (tile.Figure != null)
                //{

                //    Image image = new Image
                //    {
                //        Width = 80,
                //        Height = 75,
                //        Name = tile.Figure.Type.ToString()
                //    };

                //    ImageSource imageSource = new BitmapImage(new Uri(tile.Figure.Path, UriKind.Relative));
                //    image.Source = imageSource;
                //    image.Cursor = Cursors.Hand;
                //    image.MouseDown += new MouseButtonEventHandler(Image_MouseDown);

                //    Canvas.SetZIndex(image, 2);
                //    canvas.Children.Add(image);
                //}

                //UniformGrid.Children.Add(canvas);
            });

            Pieces = new ObservableCollection<BoardFigure>
            {
                // Dark figures
                new BoardFigure{Path="/Resources/Figures/rook_dark.png", Row=1, Column=1, Color2="Aquamarine", Type=FigureType.Rook, Color=FigureColor.Dark, TileIndex=1},
                new BoardFigure{Path="/Resources/Figures/knight_dark.png", Row=2, Column=2, Type=FigureType.Knight, Color=FigureColor.Dark, TileIndex=2},
                new BoardFigure{Path="/Resources/Figures/bishop_dark.png", Type=FigureType.Bishop, Color=FigureColor.Dark, TileIndex=3},
                new BoardFigure{Path="/Resources/Figures/queen_dark.png", Type=FigureType.Queen, Color=FigureColor.Dark, TileIndex=4},
                new BoardFigure{Path="/Resources/Figures/king_dark.png", Type=FigureType.King, Color=FigureColor.Dark, TileIndex=5},
                new BoardFigure{Path="/Resources/Figures/bishop_dark.png", Type=FigureType.Bishop, Color=FigureColor.Dark, TileIndex=6},
                new BoardFigure{Path="/Resources/Figures/knight_dark.png", Type=FigureType.Knight, Color=FigureColor.Dark, TileIndex=7},
                new BoardFigure{Path="/Resources/Figures/rook_dark.png", Type=FigureType.Rook, Color=FigureColor.Dark, TileIndex=8},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=9},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=10},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=11},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=12},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=13},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=14},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=15},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=16},

                // White figures
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=49},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=50},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=51},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=52},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=53},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=54},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=55},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=56},
                new BoardFigure{Path="/Resources/Figures/rook_white.png", Type=FigureType.Rook, Color=FigureColor.White, TileIndex=57},
                new BoardFigure{Path="/Resources/Figures/knight_white.png", Type=FigureType.Knight, Color=FigureColor.White, TileIndex=58},
                new BoardFigure{Path="/Resources/Figures/bishop_white.png", Type=FigureType.Bishop, Color=FigureColor.White, TileIndex=59},
                new BoardFigure{Path="/Resources/Figures/queen_white.png", Type=FigureType.Queen, Color=FigureColor.White, TileIndex=60},
                new BoardFigure{Path="/Resources/Figures/king_white.png", Type=FigureType.King, Color=FigureColor.White, TileIndex=61},
                new BoardFigure{Path="/Resources/Figures/bishop_white.png", Type=FigureType.Bishop, Color=FigureColor.White, TileIndex=62},
                new BoardFigure{Path="/Resources/Figures/knight_white.png", Type=FigureType.Knight, Color=FigureColor.White, TileIndex=63},
                new BoardFigure{Path="/Resources/Figures/rook_white.png", Type=FigureType.Rook, Color=FigureColor.White, TileIndex=64}
            };
        }

        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            Image obj = (Image) sender;
            MessageBox.Show($"You clicked {obj.Name}!");
        }

    }
}
