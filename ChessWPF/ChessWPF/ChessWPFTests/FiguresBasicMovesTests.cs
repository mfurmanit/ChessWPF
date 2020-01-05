using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessWPF;
using ChessWPF.Utils;

namespace ChessWPFTests
{
    /// <summary>
    /// Summary description for FiguresMovesTests
    /// </summary>
    [TestClass]
    public class FiguresBasicMovesTests
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

        [TestMethod]
        public void Test_DarkLeftBishop_Move_MovesDownLeftTwoTiles()
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
            var baseDarkPosition = 9;
            var newDarkPosition = 17;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 33;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextTile.ClickCommand.Execute(someNextTile);

            var basePosition = 2;
            var newPosition = 16;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(whitePawnFigure.TileIndex, nextWhitePosition);
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_DarkLeftBishop_Move_MovesDownRightFiveTiles()
        {
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
            var baseDarkPosition = 11;
            var newDarkPosition = 19;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 33;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextTile.ClickCommand.Execute(someNextTile);

            var basePosition = 2;
            var newPosition = 47;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(whitePawnFigure.TileIndex, nextWhitePosition);
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRightBishop_Move_CantMoveDownLeftFiveTilesDueToSkip()
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
            var baseDarkPosition = 12;
            var newDarkPosition = 20;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 33;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextTile.ClickCommand.Execute(someNextTile);

            var basePosition = 5;
            var newPosition = 40;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(whitePawnFigure.TileIndex, nextWhitePosition);
            Assert.AreEqual(bishopFigure.TileIndex, basePosition);
            Assert.AreEqual(someTile.Figure, null);
            Assert.AreEqual(bishop.Figure, bishopFigure);
        }

        [TestMethod]
        public void Test_DarkRightBishop_Move_MovesDownLeftFiveTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 50;
            var newWhitePosition = 42;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 12;
            var newDarkPosition = 20;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 34;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextTile.ClickCommand.Execute(someNextTile);

            var basePosition = 5;
            var newPosition = 40;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(whitePawnFigure.TileIndex, nextWhitePosition);
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRightBishop_Move_MovesDownRightTwoTiles()
        {
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
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 33;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextTile.ClickCommand.Execute(someNextTile);

            var basePosition = 5;
            var newPosition = 23;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;

            //Act
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(whitePawnFigure.TileIndex, nextWhitePosition);
            Assert.AreEqual(bishopFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteQueen_Move_MovesUpTwoTiles()
        {
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 35;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            var basePosition = 59;
            var newPosition = 43;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;

            //Act
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(queenFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteQueen_Move_MovesUpAndLeft()
        {
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 35;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Queen makes move two tiles up
            var basePosition = 59;
            var newPosition = 43;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Queen makes move to the left
            var nextPosition = 40;
            queen = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            queen.ClickCommand.Execute(queen);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(queenFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteQueen_Move_MovesUpAndRight()
        {
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 35;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Queen makes move two tiles up
            var basePosition = 59;
            var newPosition = 43;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Queen makes move to the right
            var nextPosition = 47;
            queen = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            queen.ClickCommand.Execute(queen);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(queenFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteQueen_Move_MovesUpAndDown()
        {
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 35;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Queen makes move two tiles up
            var basePosition = 59;
            var newPosition = 43;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Queen makes move two tiles down to base position
            queen = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[basePosition];

            //Act
            queen.ClickCommand.Execute(queen);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(queenFigure.TileIndex, basePosition);
            Assert.AreEqual(someNextTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }


        [TestMethod]
        public void Test_WhiteQueen_Move_MovesUpAndLeftDiagonal()
        {
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 35;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Queen makes move two tiles up
            var basePosition = 59;
            var newPosition = 43;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Queen makes move to the left (diagonal)
            var nextPosition = 16;
            queen = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            queen.ClickCommand.Execute(queen);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(queenFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteQueen_Move_MovesUpAndRightDiagonal()
        {
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 35;
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

            //Queen makes move two tiles up
            var basePosition = 59;
            var newPosition = 43;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 24;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Queen makes move to the right (diagonal)
            var nextPosition = 22;
            queen = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            queen.ClickCommand.Execute(queen);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(queenFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteLeftRook_Move_MovesUpTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 48;
            var newWhitePosition = 32;
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

            var basePosition = 56;
            var newPosition = 40;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;

            //Act
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteLeftRook_Move_MovesUpAndDownTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 48;
            var newWhitePosition = 32;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Rook makes move two tiles up
            var basePosition = 56;
            var newPosition = 40;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Rook makes move two tiles down to base position
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[basePosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, basePosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteLeftRook_Move_MovesUpAndRight()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 48;
            var newWhitePosition = 32;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Rook makes move two tiles up
            var basePosition = 56;
            var newPosition = 40;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Rook makes move to the right
            var nextPosition = 47;
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile); 

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRightRook_Move_MovesUpTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 55;
            var newWhitePosition = 39;
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

            var basePosition = 63;
            var newPosition = 47;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;

            //Act
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRightRook_Move_MovesUpAndDownTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 55;
            var newWhitePosition = 39;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Rook makes move two tiles up
            var basePosition = 63;
            var newPosition = 47;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Rook makes move two tiles down to base position
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[basePosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, basePosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRightRook_Move_MovesUpAndLeft()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 55;
            var newWhitePosition = 39;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 14;
            var newDarkPosition = 22;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //Rook makes move two tiles up
            var basePosition = 63;
            var newPosition = 47;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 30;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //Rook makes move to the left
            var nextPosition = 40;
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_DarkLeftRook_Move_MovesDownTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 55;
            var newWhitePosition = 39;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 24;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 31;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextWhiteTile.ClickCommand.Execute(someNextWhiteTile);

            var basePosition = 0;
            var newPosition = 16;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;

            //Act
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_DarkLeftRook_Move_MovesDownAndUpTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 55;
            var newWhitePosition = 39;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 24;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 31;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextWhiteTile.ClickCommand.Execute(someNextWhiteTile);

            //Rook makes move two tiles down
            var basePosition = 0;
            var newPosition = 16;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //White pawn makes next move
            var secondNextWhitePosition = 23;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            var someSecondNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someSecondNextWhiteTile.ClickCommand.Execute(someSecondNextWhiteTile);

            //Rook makes move two tiles up to base position
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[basePosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, basePosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_DarkLeftRook_Move_MovesDownAndRight()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 55;
            var newWhitePosition = 39;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 8;
            var newDarkPosition = 24;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 31;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextWhiteTile.ClickCommand.Execute(someNextWhiteTile);

            //Rook makes move two tiles down
            var basePosition = 0;
            var newPosition = 16;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //White pawn makes next move
            var secondNextWhitePosition = 23;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            var someSecondNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someSecondNextWhiteTile.ClickCommand.Execute(someSecondNextWhiteTile);

            //Rook makes move to the right
            var nextPosition = 23;
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRightRook_Move_MovesDownTwoTiles()
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
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 32;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextWhiteTile.ClickCommand.Execute(someNextWhiteTile);

            var basePosition = 7;
            var newPosition = 23;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;

            //Act
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRightRook_Move_MovesDownAndUpTwoTiles()
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
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 32;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextWhiteTile.ClickCommand.Execute(someNextWhiteTile);

            //Rook makes move two tiles down
            var basePosition = 7;
            var newPosition = 23;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //White pawn makes next move
            var secondNextWhitePosition = 24;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            var someSecondNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someSecondNextWhiteTile.ClickCommand.Execute(someSecondNextWhiteTile);

            //Rook makes move two tiles up to base position
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[basePosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, basePosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRightRook_Move_MovesDownAndLeft()
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
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //White pawn makes next move
            var nextWhitePosition = 32;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var someNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someNextWhiteTile.ClickCommand.Execute(someNextWhiteTile);

            //Rook makes move two tiles down
            var basePosition = 7;
            var newPosition = 23;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            //White pawn makes next move
            var secondNextWhitePosition = 24;
            whitePawn = mainWindowModel.BoardViewModel.BoardTiles[nextWhitePosition];
            var someSecondNextWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextWhitePosition];
            whitePawn.ClickCommand.Execute(whitePawn);
            someSecondNextWhiteTile.ClickCommand.Execute(someSecondNextWhiteTile);

            //Rook makes move to the left
            var nextPosition = 16;
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            rook.ClickCommand.Execute(rook);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(rookFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteKing_Move_MovesUpOneTile()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 52;
            var newWhitePosition = 36;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //King makes move one tile up
            var basePosition = 60;
            var newPosition = 52;
            var king = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var kingFigure = king.Figure;

            //Act
            king.ClickCommand.Execute(king);
            someTile.ClickCommand.Execute(someTile);

            //Assert
            Assert.AreEqual(kingFigure.TileIndex, newPosition);
            Assert.AreEqual(someTile.Figure, kingFigure);
            Assert.AreEqual(king.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteKing_Move_MovesUpTwoTiles()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 52;
            var newWhitePosition = 36;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //King makes move one tile up
            var basePosition = 60;
            var newPosition = 52;
            var king = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var kingFigure = king.Figure;
            king.ClickCommand.Execute(king);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 39;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //King makes move one tile up
            var nextPosition = 44;
            king = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            king.ClickCommand.Execute(king);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(kingFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, kingFigure);
            Assert.AreEqual(king.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteKing_Move_MovesUpLeftDiagonal()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 52;
            var newWhitePosition = 36;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //King makes move one tile up
            var basePosition = 60;
            var newPosition = 52;
            var king = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var kingFigure = king.Figure;
            king.ClickCommand.Execute(king);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 39;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //King makes move one tile up left (diagonal)
            var nextPosition = 43;
            king = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            king.ClickCommand.Execute(king);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(kingFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, kingFigure);
            Assert.AreEqual(king.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteKing_Move_MovesUpRightDiagonal()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 52;
            var newWhitePosition = 36;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //King makes move one tile up
            var basePosition = 60;
            var newPosition = 52;
            var king = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var kingFigure = king.Figure;
            king.ClickCommand.Execute(king);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 39;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //King makes move one tile up left (diagonal)
            var nextPosition = 45;
            king = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];

            //Act
            king.ClickCommand.Execute(king);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(kingFigure.TileIndex, nextPosition);
            Assert.AreEqual(someNextTile.Figure, kingFigure);
            Assert.AreEqual(king.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteKing_Move_MovesUpAndDown()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            //White pawn makes first move
            var baseWhitePosition = 52;
            var newWhitePosition = 36;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            //Dark pawn makes next move
            var baseDarkPosition = 15;
            var newDarkPosition = 31;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            //King makes move one tile up
            var basePosition = 60;
            var newPosition = 52;
            var king = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var kingFigure = king.Figure;
            king.ClickCommand.Execute(king);
            someTile.ClickCommand.Execute(someTile);

            //Dark pawn makes next move
            var nextDarkPosition = 39;
            darkPawn = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var someNextDarkTile = mainWindowModel.BoardViewModel.BoardTiles[nextDarkPosition];
            darkPawn.ClickCommand.Execute(darkPawn);
            someNextDarkTile.ClickCommand.Execute(someNextDarkTile);

            //King makes move one tile down to base position
            king = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var someNextTile = mainWindowModel.BoardViewModel.BoardTiles[basePosition];

            //Act
            king.ClickCommand.Execute(king);
            someNextTile.ClickCommand.Execute(someNextTile);

            //Assert
            Assert.AreEqual(kingFigure.TileIndex, basePosition);
            Assert.AreEqual(someNextTile.Figure, kingFigure);
            Assert.AreEqual(king.Figure, null);
        }
    }
}
