using KTPO4311.Gorohov.Lib.src.LogAn;
using NUnit.Framework;
using System;

namespace KTPO4311.Gorohov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeManager);

            bool result = logAnalyzer.IsValidLogFileName("short.ext");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_NameUnsupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeManager);

            bool result = logAnalyzer.IsValidLogFileName("short.exe");

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;
            fakeManager.WillThrow = new Exception();

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeManager);

            bool result = logAnalyzer.IsValidLogFileName("short.exe");

            Assert.IsFalse(result);
        }
    }
    
    /// <summary>
    /// Поддельный менеджер расширений
    /// </summary>
    public class FakeExtensionManager : IExtensionManager
    {
        /// <summary>
        /// Поле, которое позволяет настроить поддельный результат
        /// </summary>
        public bool WillBeValid = false;

        /// <summary>
        /// Поле, которое позволяет настроить поддельное исключение
        /// </summary>
        public Exception WillThrow = null;

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                return false;
            }

            return WillBeValid;
        }
    }
}
