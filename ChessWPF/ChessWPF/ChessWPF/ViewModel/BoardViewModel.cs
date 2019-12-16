using ChessWPF.Model;
using ChessWPF.Model.Constants;
using ChessWPF.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ChessWPF.ViewModel
{
    class BoardViewModel
    {
        private List<BoardFigure> _FiguresList;
        private List<BoardTileViewModel> _TilesList;

        public BoardViewModel()
        {
            InitializeFiguresList();
            GenerateTilesList();
        }

        private void InitializeFiguresList()
        {
            _FiguresList = new List<BoardFigure>
            {
                // Dark figures
                new BoardFigure{Path="/Resources/Figures/rook_dark.png", Type=FigureType.Rook, Color=FigureColor.Dark, TileIndex=0},
                new BoardFigure{Path="/Resources/Figures/knight_dark.png", Type=FigureType.Knight, Color=FigureColor.Dark, TileIndex=1},
                new BoardFigure{Path="/Resources/Figures/bishop_dark.png", Type=FigureType.Bishop, Color=FigureColor.Dark, TileIndex=2},
                new BoardFigure{Path="/Resources/Figures/queen_dark.png", Type=FigureType.Queen, Color=FigureColor.Dark, TileIndex=3},
                new BoardFigure{Path="/Resources/Figures/king_dark.png", Type=FigureType.King, Color=FigureColor.Dark, TileIndex=4},
                new BoardFigure{Path="/Resources/Figures/bishop_dark.png", Type=FigureType.Bishop, Color=FigureColor.Dark, TileIndex=5},
                new BoardFigure{Path="/Resources/Figures/knight_dark.png", Type=FigureType.Knight, Color=FigureColor.Dark, TileIndex=6},
                new BoardFigure{Path="/Resources/Figures/rook_dark.png", Type=FigureType.Rook, Color=FigureColor.Dark, TileIndex=7},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=8},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=9},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=10},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=11},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=12},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=13},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=14},
                new BoardFigure{Path="/Resources/Figures/pawn_dark.png", Type=FigureType.Pawn, Color=FigureColor.Dark, TileIndex=15},

                // White figures
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=48},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=49},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=50},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=51},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=52},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=53},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=54},
                new BoardFigure{Path="/Resources/Figures/pawn_white.png", Type=FigureType.Pawn, Color=FigureColor.White, TileIndex=55},
                new BoardFigure{Path="/Resources/Figures/rook_white.png", Type=FigureType.Rook, Color=FigureColor.White, TileIndex=56},
                new BoardFigure{Path="/Resources/Figures/knight_white.png", Type=FigureType.Knight, Color=FigureColor.White, TileIndex=57},
                new BoardFigure{Path="/Resources/Figures/bishop_white.png", Type=FigureType.Bishop, Color=FigureColor.White, TileIndex=58},
                new BoardFigure{Path="/Resources/Figures/queen_white.png", Type=FigureType.Queen, Color=FigureColor.White, TileIndex=59},
                new BoardFigure{Path="/Resources/Figures/king_white.png", Type=FigureType.King, Color=FigureColor.White, TileIndex=60},
                new BoardFigure{Path="/Resources/Figures/bishop_white.png", Type=FigureType.Bishop, Color=FigureColor.White, TileIndex=61},
                new BoardFigure{Path="/Resources/Figures/knight_white.png", Type=FigureType.Knight, Color=FigureColor.White, TileIndex=62},
                new BoardFigure{Path="/Resources/Figures/rook_white.png", Type=FigureType.Rook, Color=FigureColor.White, TileIndex=63}
            };
        }

        private void GenerateTilesList()
        {
            _TilesList = new List<BoardTileViewModel>();

            int tilesCount = 64;
            int row = 0;
            int column = 0;

            for (int tileIndex = 0; tileIndex < tilesCount; tileIndex++)
            {
                var position = new Position(column, row);
                var figure = _FiguresList.FirstOrDefault(f => f.TileIndex == tileIndex);
                BoardTileViewModel tile = new BoardTileViewModel(figure, tileIndex, position);
                tile.Click += Tile_Click;
                tile.MouseEnter += Tile_Enter;
                tile.MouseLeave += Tile_Leave;

                _TilesList.Add(tile);
                if (column == 7)
                {
                    row++;
                    column = 0;
                } else
                {
                    column++;
                }
            }
        }

        private BoardTileViewModel selectedTile = null;
        private void Tile_Click(BoardTileViewModel eventCaller)
        {
            if (selectedTile != null && eventCaller.Position.Equals(ResolvePosition(eventCaller)))
            {
                var selectedFigure = selectedTile.Figure;
                SetBaseStyle(selectedTile);
                selectedTile.Figure = null;
                selectedTile = null;
                selectedFigure.TileIndex = eventCaller.Index;
                eventCaller.Figure = selectedFigure;
                SetBaseStyle(eventCaller);
            } else if (eventCaller.Figure != null)
            {
                selectedTile = eventCaller;
                CheckSelectedStyle(eventCaller);
            }
        }

        private void Tile_Enter(BoardTileViewModel eventCaller)
        {
            if (selectedTile != null && eventCaller.Position.Equals(ResolvePosition(eventCaller)))
            {
                SetEnabledStyle(eventCaller);
            } else if (selectedTile != null && !eventCaller.Position.Equals(ResolvePosition(eventCaller)))
            {
                SetDisabledStyle(eventCaller);
            } else
            {
                SetBaseStyle(eventCaller);
            }

            CheckSelectedStyle(eventCaller);
        }

        private void Tile_Leave(BoardTileViewModel eventCaller)
        {
            SetBaseStyle(eventCaller);
            CheckSelectedStyle(eventCaller);
        }

        private void CheckSelectedStyle(BoardTileViewModel tile)
        {
            if (selectedTile != null && selectedTile.Figure != null && selectedTile.Equals(tile))
            {
                SetSelectedStyle(tile);
            }
        }

        private void SetSelectedStyle(BoardTileViewModel tile)
        {
            tile.Stroke = StaticResources.BORDER_SELECTED_TILE_COLOR;
            tile.StrokeThickness = 3;
        }

        private void SetBaseStyle(BoardTileViewModel tile)
        {
            tile.Stroke = StaticResources.BORDER_TILE_COLOR;
            tile.StrokeThickness = 1;
        }

        private void SetDisabledStyle(BoardTileViewModel tile)
        {
            tile.Stroke = StaticResources.BORDER_DISABLED_TILE_COLOR;
            tile.StrokeThickness = 3;
        }

        private void SetEnabledStyle(BoardTileViewModel tile)
        {
            tile.Stroke = StaticResources.BORDER_ENABLED_TILE_COLOR;
            tile.StrokeThickness = 3;
        }

        private Position ResolvePosition(BoardTileViewModel wanted)
        {
            var position = selectedTile.Position;
            var figure = selectedTile.Figure;
            var figureColor = selectedTile.Figure.Color;
            switch (figure.Type)
            {
                case FigureType.Pawn:
                    return new Position(position.Column, (figureColor == FigureColor.Dark ? position.Row + 1 : position.Row - 1));
                case FigureType.King:
                    return ResolveKingPosition(wanted);
                default:
                    return position;
            }
        }

        private Position ResolvePawnPosition()
        {
            var position = selectedTile.Position;
            var figure = selectedTile.Figure;
            var figureColor = selectedTile.Figure.Color;
            return new Position(position.Column, (figureColor == FigureColor.Dark ? position.Row + 1 : position.Row - 1));
        }

        private Position ResolveKingPosition(BoardTileViewModel caller) {

            int[] x = { -1, -1, -1, 1, 1, 1, 0, 0 };
            int[] y = { -1, 0, 1, -1, 0, 1, -1, 1 };
            var selectedColumn = selectedTile.Position.Column;
            var selectedRow = selectedTile.Position.Row;

            List<Position> possiblePositions = new List<Position>();

            for (int iterator = 0; iterator < 8; iterator++)
            {
                Position position = new Position(selectedColumn + y[iterator], selectedRow + x[iterator]);
                if (IsPossibleToMove(caller, position)) {
                    possiblePositions.Add(position);
                }
            }

            return possiblePositions.Contains(caller.Position) ? caller.Position : null;
        }

        private bool IsPossibleToMove(BoardTileViewModel caller, Position newPosition) {
            bool isWithinBoard = newPosition.Column > 0 && newPosition.Column <= 7 && newPosition.Row > 0 && newPosition.Row <= 7;
            bool isAlly = caller.Figure == null ? false : caller.Figure.Color == selectedTile.Figure.Color;
            return isWithinBoard && !isAlly;
        }

        public List<BoardFigure> BoardFigures
        {
            get { return _FiguresList; }
            set { _FiguresList = value; }
        }

        public List<BoardTileViewModel> BoardTiles
        {
            get { return _TilesList; }
            set { _TilesList = value; }
        }

    }
}
