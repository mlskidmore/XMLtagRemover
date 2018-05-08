using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XMLtagRemover.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HTMfileCountTest()
        {
            // Arrange
            string arg0 = "C:\\path\\to\\files";
            int expectedHTMfileCount = 1000;

            // Act
            XMLtagRemover xtr = new XMLtagRemover(arg0);
            int actualHTMfileCount = xtr.HTMfiles.Count;

            //Assert
            Assert.AreEqual(expectedHTMfileCount, actualHTMfileCount);
        }

        [TestMethod]
        public void HTMLfileCountTest()
        {
            // Arrange
            string arg0 = "C:\\path\\to\\files";
            int expectedHTMLfileCount = 100;

            // Act
            XMLtagRemover xtr = new XMLtagRemover(arg0);
            int actualHTMLfileCount = xtr.HTMfiles.Count;

            //Assert
            Assert.AreEqual(expectedHTMLfileCount, actualHTMLfileCount);
        }
    }
}
