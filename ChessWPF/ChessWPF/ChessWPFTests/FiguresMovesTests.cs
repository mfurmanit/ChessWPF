using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessWPF;
using System.Threading;
using ChessWPF.Utils;
using ChessWPF.Model;

namespace ChessWPFTests
{
    /// <summary>
    /// Summary description for FiguresMovesTests
    /// </summary>
    [TestClass]
    public class FiguresMovesTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Mediator.ResetMediator();
        }

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

        [TestMethod]
        public void Test_WhiteLeftKnight_Move_MovesUpLeft()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var basePosition = 57;
            var newPosition = 40;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteLeftKnight_Move_MovesUpRight()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var basePosition = 57;
            var newPosition = 42;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRightKnight_Move_MovesUpLeft()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var basePosition = 62;
            var newPosition = 45;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRightKnight_Move_MovesUpRight()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var basePosition = 62;
            var newPosition = 47;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_DarkLeftKnight_Move_MovesDownLeft()
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

            var basePosition = 1;
            var newPosition = 16;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_DarkLeftKnight_Move_MovesDownRight()
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

            var basePosition = 1;
            var newPosition = 18;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRightKnight_Move_MovesDownLeft()
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

            var basePosition = 6;
            var newPosition = 21;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRightKnight_Move_MovesDownRight()
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

            var basePosition = 6;
            var newPosition = 23;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;

            //Act
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(knightFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteLeftBishop_Move_CantMoveUpLeftTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 48;
            var newWhitePosition = 40;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 16;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            var basePosition = 58;
            var newPosition = 40;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(bishopFigure.TileIndex, basePosition);
            Assert.AreEqual(someTile.Figure, whitePawnFigure);
            Assert.AreEqual(bishop.Figure, bishopFigure);
        }

        [TestMethod]
        public void Test_WhiteLeftBishop_Move_MovesUpLeftTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 49;
            var newWhitePosition = 41;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 16;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            var basePosition = 58;
            var newPosition = 40;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteLeftBishop_Move_MovesUpRightFiveTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 43;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 16;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            var basePosition = 58;
            var newPosition = 23;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRightBishop_Move_MovesUpRightTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 54;
            var newWhitePosition = 46;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 16;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            var basePosition = 61;
            var newPosition = 47;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRightBishop_Move_MovesUpLeftFiveTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 52;
            var newWhitePosition = 44;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 16;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            var basePosition = 61;
            var newPosition = 16;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

    }
}
