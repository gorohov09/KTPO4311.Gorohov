using KTPO4311.Gorohov.Lib.src.LogAn;
using NUnit.Framework;
using System;

namespace KTPO4311.Gorohov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.IsFalse(result);
        }

        [TestCase("filewithbadextension.slf")]
        [TestCase("filewithbadextension.SLF")]
        public void IsValidLogFileName_ValidExtension_ReturnTrue(string fileName)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(fileName);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("Имя файла должно быть задано", ex.Message);
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.SLF", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFilenameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            analyzer.IsValidLogFileName(file);

            Assert.AreEqual(analyzer.WasLastFileNameIsValid, expected);
        }
    }
}
