using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessWPF;
using System.Threading;

namespace ChessWPFTests
{
    /// <summary>
    /// Summary description for FiguresMovesTests
    /// </summary>
    [TestClass]
    public class FiguresMovesTests
    {

        [TestMethod]
        public void Test_WhitePawn_Move_MovesOnePosition()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var basePosition = 48;
            var newPosition = 40;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;

            //Act
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(pawnFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, null);
        }

        [TestMethod]
        public void Test_WhitePawn_Move_MovesTwoPositions()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var basePosition = 48;
            var newPosition = 32;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;

            //Act
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(pawnFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, null);
        }

        [TestMethod]
        public void Test_DarkPawn_Move_CantMoveBeforeWhite()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var basePosition = 8;
            var newPosition = 16;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;

            //Act
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(pawnFigure.TileIndex, basePosition);
            Assert.AreEqual(someTile.Figure, null);
            Assert.AreEqual(pawn.Figure, pawnFigure);
        }

        [TestMethod]
        public void Test_DarkPawn_Move_MovesOnePosition()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White makes first move
            var baseWhitePosition = 48;
            var newWhitePosition = 40;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            Assert.AreEqual(mainWindowModel.GameViewModel.ActualPlayer.SelectedColor, ChessWPF.Model.Constants.FigureColor.Dark);

            var basePosition = 8;
            var newPosition = 16;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;

            //Act
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(pawnFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, null);
        }

        [TestMethod]
        public void Test_DarkPawn_Move_MovesTwoPositions()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White makes first move
            var baseWhitePosition = 48;
            var newWhitePosition = 40;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            Assert.AreEqual(mainWindowModel.GameViewModel.ActualPlayer.SelectedColor, ChessWPF.Model.Constants.FigureColor.Dark);

            var basePosition = 8;
            var newPosition = 24;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;

            //Act
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(pawnFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, null);
        }
    }
}
