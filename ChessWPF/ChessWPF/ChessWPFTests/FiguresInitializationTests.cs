using ChessWPF;
using ChessWPF.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessWPFTests
{
    [TestClass]
    public class FiguresInitializationTests
    {
        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesFigures()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var actualCount = mainWindowModel.BoardViewModel.BoardFigures.Count;
            var expectedCount = 32;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesDarkPawns()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.Dark);
            var actualCount = resultList.Count;
            var expectedCount = 8;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesWhitePawns()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Pawn && tile.Figure.Color == FigureColor.White);
            var actualCount = resultList.Count;
            var expectedCount = 8;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesDarkRooks()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Rook && tile.Figure.Color == FigureColor.Dark);
            var actualCount = resultList.Count;
            var expectedCount = 2;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesWhiteRooks()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Rook && tile.Figure.Color == FigureColor.White);
            var actualCount = resultList.Count;
            var expectedCount = 2;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesDarkKnights()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Knight && tile.Figure.Color == FigureColor.Dark);
            var actualCount = resultList.Count;
            var expectedCount = 2;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesWhiteKnights()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Knight && tile.Figure.Color == FigureColor.White);
            var actualCount = resultList.Count;
            var expectedCount = 2;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesDarkBishops()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Bishop && tile.Figure.Color == FigureColor.Dark);
            var actualCount = resultList.Count;
            var expectedCount = 2;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesWhiteBishops()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Bishop && tile.Figure.Color == FigureColor.White);
            var actualCount = resultList.Count;
            var expectedCount = 2;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesDarkQueen()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Queen && tile.Figure.Color == FigureColor.Dark);
            var actualCount = resultList.Count;
            var expectedCount = 1;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesWhiteQueen()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.Queen && tile.Figure.Color == FigureColor.White);
            var actualCount = resultList.Count;
            var expectedCount = 1;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesDarkKing()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.King && tile.Figure.Color == FigureColor.Dark);
            var actualCount = resultList.Count;
            var expectedCount = 1;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MainWindowModel_Initialization_CreatesWhiteKing()
        {
            //Arrange
            MainWindowModel mainWindowModel = new MainWindowModel();
            var resultList = mainWindowModel.BoardViewModel.BoardTiles
                .FindAll(tile => tile.Figure != null && tile.Figure.Type == FigureType.King&& tile.Figure.Color == FigureColor.White);
            var actualCount = resultList.Count;
            var expectedCount = 1;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

    }
}
