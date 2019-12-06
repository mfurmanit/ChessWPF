﻿using ChessWPF.Model;
using ChessWPF.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ChessWPF.ViewModel
{
    class BoardViewModel
    {
        private List<BoardFigure> _FiguresList;
        private List<BoardTile> _TilesList;

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
                new BoardFigure{Path="/Resources/Figures/rook_dark.png", Type=FigureType.Rook, Color=FigureColor.Dark, TileIndex=1},
                new BoardFigure{Path="/Resources/Figures/knight_dark.png", Type=FigureType.Knight, Color=FigureColor.Dark, TileIndex=2},
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

        private void GenerateTilesList()
        {
            _TilesList = new List<BoardTile>();

            var BLACK_TILE_COLOR = Brushes.LightSteelBlue;
            var WHITE_TILE_COLOR = Brushes.White;
            var BORDER_TILE_COLOR = Brushes.Black;

            int tilesCount = 64;
            bool isWhite = false;

            for (int tileIndex = 1; tileIndex <= tilesCount; tileIndex++)
            {
                BoardTile tile = new BoardTile {
                    Background = isWhite ? WHITE_TILE_COLOR : BLACK_TILE_COLOR,
                    Figure = _FiguresList.FirstOrDefault(figure => figure.TileIndex == tileIndex),
                    Index = tileIndex,
                    IsActive = false,
                    Stroke = BORDER_TILE_COLOR
                };

                if (tileIndex % 8 != 0)
                    isWhite = !isWhite;

                _TilesList.Add(tile);
            }
        }

        public List<BoardFigure> BoardFigures
        {
            get { return _FiguresList; }
            set { _FiguresList = value; }
        }

        public List<BoardTile> BoardTiles
        {
            get { return _TilesList; }
            set { _TilesList = value; }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
    }
}