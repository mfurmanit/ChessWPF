using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ChessWPF.Views
{
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();
            DrawTilesOnBoard();
        }

        private void DrawTilesOnBoard()
        {
            var BLACK_TILE_COLOR = Brushes.LightSteelBlue;
            var WHITE_TILE_COLOR = Brushes.White;
            var BORDER_TILE_COLOR = Brushes.Black;

            int tilesCount = 64;
            bool isWhite = false;

            for (int tileIndex = 1; tileIndex <= tilesCount; tileIndex++)
            {
                Rectangle rect = new Rectangle
                {
                    Name = "TILE" + tileIndex,
                    Stroke = BORDER_TILE_COLOR,
                    Fill = isWhite ? WHITE_TILE_COLOR : BLACK_TILE_COLOR
                };

                UniformGrid.Children.Add(rect);

                if (tileIndex % 8 != 0)
                    isWhite = !isWhite;
            }
        }

    }
}
