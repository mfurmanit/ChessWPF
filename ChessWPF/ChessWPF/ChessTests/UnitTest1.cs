using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessWPF.ViewModel;
using ChessWPF;

namespace ChessTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainWindowModel n = new MainWindowModel();
            Assert.AreEqual(32, n.BoardViewModel.BoardFigures);
        }
    }
}
