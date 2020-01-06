using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessWPF.Utils;
using ChessWPF;
using ChessWPF.Model.Constants;

namespace ChessWPFTests
{
    /// <summary>
    /// Summary description for FiguresAdvancedMovesTests
    /// </summary>
    [TestClass]
    public class FiguresAdvancedMovesTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Mediator.ResetMediator();
        }

        [TestMethod]
        public void Test_WhitePawn_MoveAndCapture_PassesWholeBoardAndCapturesDarkPawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var darkPawnsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.Dark);

            var basePosition = 48;
            var newPosition = 32;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 24;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var secondNextPosition = 16;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkPawnPosition = 9;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            var darkPawnsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.Dark);

            Assert.AreEqual(8, darkPawnsBefore.Count);
            Assert.AreEqual(7, darkPawnsAfter.Count);
            Assert.AreEqual(pawnFigure.TileIndex, darkPawnPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, null);
        }

        [TestMethod]
        public void Test_WhitePawn_MoveAndCapture_PassesWholeBoardAndCantCaptureNotDiagonalDarkPawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var darkPawnsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.Dark);

            var basePosition = 48;
            var newPosition = 32;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 24;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var secondNextPosition = 16;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkPawnPosition = 8;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            var darkPawnTile = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            pawn.ClickCommand.Execute(pawn);
            darkPawnTile.ClickCommand.Execute(darkPawnTile);

            var darkPawnsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.Dark);

            Assert.AreEqual(8, darkPawnsBefore.Count);
            Assert.AreEqual(8, darkPawnsAfter.Count);
            Assert.AreEqual(pawnFigure.TileIndex, secondNextPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, pawnFigure);
        }

        [TestMethod]
        public void Test_WhiteRook_MoveAndCapture_PassesWholeBoardAndCapturesDarkPawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var darkPawnsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.Dark);

            //White pawn makes first move
            var baseWhitePosition = 48;
            var newWhitePosition = 32;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Rook makes next moves
            var basePosition = 56;
            var newPosition = 40;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 47;
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkPawnPosition = 15;
            rook = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            var darkPawnsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.Dark);

            Assert.AreEqual(8, darkPawnsBefore.Count);
            Assert.AreEqual(7, darkPawnsAfter.Count);
            Assert.AreEqual(rookFigure.TileIndex, darkPawnPosition);
            Assert.AreEqual(someTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteRook_Move_CantJumpWhitePawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var basePosition = 56;
            var newPosition = 40;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            Assert.AreEqual(rookFigure.TileIndex, basePosition);
            Assert.AreEqual(someTile.Figure, null);
            Assert.AreEqual(rook.Figure, rookFigure);
        }

        [TestMethod]
        public void Test_WhiteKnight_MoveAndCapture_PassesWholeBoardAndCapturesDarkBishop()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var darkBishopsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Bishop && tile.Figure.Color == FigureColor.Dark);

            var basePosition = 57;
            var newPosition = 42;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 36;
            knight = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var secondNextPosition = 19;
            knight = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkBishopPosition = 2;
            knight = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[darkBishopPosition];
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            var darkBishopsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Bishop && tile.Figure.Color == FigureColor.Dark);

            Assert.AreEqual(2, darkBishopsBefore.Count);
            Assert.AreEqual(1, darkBishopsAfter.Count);
            Assert.AreEqual(knightFigure.TileIndex, darkBishopPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteBishop_MoveAndCapture_PassesWholeBoardAndCapturesDarkKnight()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var darkKnightsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Knight && tile.Figure.Color == FigureColor.Dark);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 43;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Bishop makes next moves
            var basePosition = 58;
            var newPosition = 44;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkPawnPosition = 8;
            bishop = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkKnightPosition = 1;
            bishop = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[darkKnightPosition];
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            var darkKnightsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Knight && tile.Figure.Color == FigureColor.Dark);

            Assert.AreEqual(2, darkKnightsBefore.Count);
            Assert.AreEqual(1, darkKnightsAfter.Count);
            Assert.AreEqual(bishopFigure.TileIndex, darkKnightPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_WhiteBishop_Move_CantJumpWhitePawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var basePosition = 58;
            var newPosition = 44;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            Assert.AreEqual(bishopFigure.TileIndex, basePosition);
            Assert.AreEqual(someTile.Figure, null);
            Assert.AreEqual(bishop.Figure, bishopFigure);
        }

        [TestMethod]
        public void Test_WhiteQueen_MoveAndCapture_PassesWholeBoardAndCapturesDarkRook()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var darkRooksBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Rook && tile.Figure.Color == FigureColor.Dark);

            //White pawn makes first move
            var baseWhitePosition = 51;
            var newWhitePosition = 35;
            var whitePawn = mainWindowModel.BoardViewModel.BoardTiles[baseWhitePosition];
            var someWhiteTile = mainWindowModel.BoardViewModel.BoardTiles[newWhitePosition];
            var whitePawnFigure = whitePawn.Figure;
            whitePawn.ClickCommand.Execute(whitePawn);
            someWhiteTile.ClickCommand.Execute(someWhiteTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Queen makes next moves
            var basePosition = 59;
            var newPosition = 43;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 46;
            queen = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkPawnPosition = 14;
            queen = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkRookPosition = 7;
            queen = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[darkRookPosition];
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            var darkRooksAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Rook && tile.Figure.Color == FigureColor.Dark);

            Assert.AreEqual(2, darkRooksBefore.Count);
            Assert.AreEqual(1, darkRooksAfter.Count);
            Assert.AreEqual(queenFigure.TileIndex, darkRookPosition);
            Assert.AreEqual(someTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }


        /////
        ///



        [TestMethod]
        public void Test_DarkPawn_MoveAndCapture_PassesWholeBoardAndCapturesWhitePawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var whitePawnsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.White);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var basePosition = 8;
            var newPosition = 24;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 32;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var secondNextPosition = 40;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var whitePawnPosition = 49;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[whitePawnPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            var whitePawnsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.White);

            Assert.AreEqual(8, whitePawnsBefore.Count);
            Assert.AreEqual(7, whitePawnsAfter.Count);
            Assert.AreEqual(pawnFigure.TileIndex, whitePawnPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, null);
        }

        [TestMethod]
        public void Test_DarkPawn_MoveAndCapture_PassesWholeBoardAndCantCaptureNotDiagonalWhitePawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var whitePawnsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.White);

            var basePosition = 48;
            var newPosition = 32;
            var pawn = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var pawnFigure = pawn.Figure;
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 24;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var secondNextPosition = 16;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            pawn.ClickCommand.Execute(pawn);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var darkPawnPosition = 8;
            pawn = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            var darkPawnTile = mainWindowModel.BoardViewModel.BoardTiles[darkPawnPosition];
            pawn.ClickCommand.Execute(pawn);
            darkPawnTile.ClickCommand.Execute(darkPawnTile);

            var whitePawnsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.White);

            Assert.AreEqual(8, whitePawnsBefore.Count);
            Assert.AreEqual(8, whitePawnsAfter.Count);
            Assert.AreEqual(pawnFigure.TileIndex, secondNextPosition);
            Assert.AreEqual(someTile.Figure, pawnFigure);
            Assert.AreEqual(pawn.Figure, pawnFigure);
        }

        [TestMethod]
        public void Test_DarkRook_MoveAndCapture_PassesWholeBoardAndCapturesWhitePawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var whitePawnsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.White);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Dark pawn makes first move
            var baseDarkPosition = 8;
            var newDarkPosition = 24;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Rook makes next moves
            var basePosition = 0;
            var newPosition = 16;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 23;
            rook = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var whitePawnPosition = 55;
            rook = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[whitePawnPosition];
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            var whitePawnsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.White);

            Assert.AreEqual(8, whitePawnsBefore.Count);
            Assert.AreEqual(7, whitePawnsAfter.Count);
            Assert.AreEqual(rookFigure.TileIndex, whitePawnPosition);
            Assert.AreEqual(someTile.Figure, rookFigure);
            Assert.AreEqual(rook.Figure, null);
        }

        [TestMethod]
        public void Test_DarkRook_Move_CantJumpDarkPawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var basePosition = 0;
            var newPosition = 16;
            var rook = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var rookFigure = rook.Figure;
            rook.ClickCommand.Execute(rook);
            someTile.ClickCommand.Execute(someTile);

            Assert.AreEqual(rookFigure.TileIndex, basePosition);
            Assert.AreEqual(someTile.Figure, null);
            Assert.AreEqual(rook.Figure, rookFigure);
        }

        [TestMethod]
        public void Test_DarkKnight_MoveAndCapture_PassesWholeBoardAndCapturesWhiteBishop()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var whiteBishopsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Bishop && tile.Figure.Color == FigureColor.White);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var basePosition = 1;
            var newPosition = 18;
            var knight = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var knightFigure = knight.Figure;
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 24;
            knight = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var secondNextPosition = 41;
            knight = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var whiteBishopPosition = 58;
            knight = mainWindowModel.BoardViewModel.BoardTiles[secondNextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[whiteBishopPosition];
            knight.ClickCommand.Execute(knight);
            someTile.ClickCommand.Execute(someTile);

            var whiteBishopsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Bishop && tile.Figure.Color == FigureColor.White);

            Assert.AreEqual(2, whiteBishopsBefore.Count);
            Assert.AreEqual(1, whiteBishopsAfter.Count);
            Assert.AreEqual(knightFigure.TileIndex, whiteBishopPosition);
            Assert.AreEqual(someTile.Figure, knightFigure);
            Assert.AreEqual(knight.Figure, null);
        }

        [TestMethod]
        public void Test_DarkBishop_MoveAndCapture_PassesWholeBoardAndCapturesWhiteKnight()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var whiteKnightsBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Knight && tile.Figure.Color == FigureColor.White);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Dark pawn makes first move
            var baseDarkPosition = 11;
            var newDarkPosition = 19;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Bishop makes next moves
            var basePosition = 2;
            var newPosition = 20;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var whitePawnPosition = 48;
            bishop = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[whitePawnPosition];
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var whiteKnightPosition = 57;
            bishop = mainWindowModel.BoardViewModel.BoardTiles[whitePawnPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[whiteKnightPosition];
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            var whiteKnightsAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Knight && tile.Figure.Color == FigureColor.White);

            Assert.AreEqual(2, whiteKnightsBefore.Count);
            Assert.AreEqual(1, whiteKnightsAfter.Count);
            Assert.AreEqual(bishopFigure.TileIndex, whiteKnightPosition);
            Assert.AreEqual(someTile.Figure, bishopFigure);
            Assert.AreEqual(bishop.Figure, null);
        }

        [TestMethod]
        public void Test_DarkBishop_Move_CantJumpDarkPawn()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var basePosition = 2;
            var newPosition = 20;
            var bishop = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var bishopFigure = bishop.Figure;
            bishop.ClickCommand.Execute(bishop);
            someTile.ClickCommand.Execute(someTile);

            Assert.AreEqual(bishopFigure.TileIndex, basePosition);
            Assert.AreEqual(someTile.Figure, null);
            Assert.AreEqual(bishop.Figure, bishopFigure);
        }

        [TestMethod]
        public void Test_DarkQueen_MoveAndCapture_PassesWholeBoardAndCapturesWhiteRook()
        {
            //Arrange and Act
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindowModel.StartViewModel.ClickCommand.Execute(mainWindowModel.StartViewModel);

            var whiteRooksBefore = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Rook && tile.Figure.Color == FigureColor.White);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Dark pawn makes first move
            var baseDarkPosition = 11;
            var newDarkPosition = 27;
            var darkPawn = mainWindowModel.BoardViewModel.BoardTiles[baseDarkPosition];
            var someDarkTile = mainWindowModel.BoardViewModel.BoardTiles[newDarkPosition];
            var darkPawnFigure = darkPawn.Figure;
            darkPawn.ClickCommand.Execute(darkPawn);
            someDarkTile.ClickCommand.Execute(someDarkTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            //Queen makes next moves
            var basePosition = 3;
            var newPosition = 19;
            var queen = mainWindowModel.BoardViewModel.BoardTiles[basePosition];
            var someTile = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            var queenFigure = queen.Figure;
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var nextPosition = 17;
            queen = mainWindowModel.BoardViewModel.BoardTiles[newPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var whitePawnPosition = 49;
            queen = mainWindowModel.BoardViewModel.BoardTiles[nextPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[whitePawnPosition];
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            Mediator.NotifyColleagues("ChangePlayer", null);

            var whiteRookPosition = 56;
            queen = mainWindowModel.BoardViewModel.BoardTiles[whitePawnPosition];
            someTile = mainWindowModel.BoardViewModel.BoardTiles[whiteRookPosition];
            queen.ClickCommand.Execute(queen);
            someTile.ClickCommand.Execute(someTile);

            var whiteRooksAfter = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Rook && tile.Figure.Color == FigureColor.White);

            Assert.AreEqual(2, whiteRooksBefore.Count);
            Assert.AreEqual(1, whiteRooksAfter.Count);
            Assert.AreEqual(queenFigure.TileIndex, whiteRookPosition);
            Assert.AreEqual(someTile.Figure, queenFigure);
            Assert.AreEqual(queen.Figure, null);
        }
    }
}
