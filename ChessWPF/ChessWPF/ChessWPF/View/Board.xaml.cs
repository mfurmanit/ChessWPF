using ChessWPF.ViewModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Input;
using System.Windows;

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
            BoardViewModel model = new BoardViewModel();
            model.BoardTiles.ForEach(tile =>
            {

                Canvas canvas = new Canvas();
                canvas.Name = "CANVAS_" + tile.Index.ToString();

                Rectangle rect = new Rectangle
                {
                    Width = 80,
                    Height = 80,
                    Name = "Tile" + tile.Index,
                    Stroke = tile.Stroke,
                    Fill = tile.Background
                };

                Canvas.SetZIndex(rect, 1);
                canvas.Children.Add(rect);

                if (tile.Figure != null) {

                    Image image = new Image
                    {
                        Width = 80,
                        Height = 75,
                        Name = tile.Figure.Type.ToString()
                    };

                    ImageSource imageSource = new BitmapImage(new Uri(tile.Figure.Path, UriKind.Relative));
                    image.Source = imageSource;
                    image.Cursor = Cursors.Hand;
                    image.MouseDown += new MouseButtonEventHandler(Image_MouseDown);

                    Canvas.SetZIndex(image, 2);
                    canvas.Children.Add(image);
                }

                UniformGrid.Children.Add(canvas);
            });
        }

        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            Image obj = (Image) sender;
            MessageBox.Show($"You clicked {obj.Name}!");
        }

    }
}
