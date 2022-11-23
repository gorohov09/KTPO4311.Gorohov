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
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName("short.ext");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_NameUnsupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName("short.exe");

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;
            fakeManager.WillThrow = new Exception();
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName("short.exe");

            Assert.IsFalse(result);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.SetWebService(mockWebService);

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            string toShortFileName = "abc.ext";

            logAnalyzer.Analyze(toShortFileName);

            StringAssert.Contains("Слишком короткое имя файла: abc.ext", mockWebService.LastError);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService stubWebService = new FakeWebService();
            WebServiceFactory.SetWebService(stubWebService);    
            stubWebService.WillThrow = new Exception("это подделка");

            FakeEmailService mockEmail = new FakeEmailService();
            EmailServiceFactory.SetEmailService(mockEmail);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            string toShortFileName = "abc.txt";

            logAnalyzer.Analyze(toShortFileName);

            StringAssert.Contains("andrej.gorokhov2017@yandex.ru", mockEmail.To);
            StringAssert.Contains("Невозможно вызвать веб-сервис", mockEmail.Subject);
            StringAssert.Contains("это подделка", mockEmail.Body);
        }

        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.SetWebService(null);
            EmailServiceFactory.SetEmailService(null);
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

    /// <summary>
    /// Поддельная веб-служба
    /// </summary>
    public class FakeWebService : IWebService
    {
        /// <summary>
        /// Поле запоминает состояние после вызова LogError()
        /// </summary>
        public string LastError;

        public Exception WillThrow = null;

        public void LogError(string message)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }

            LastError = message;
        }
    }

    public class FakeEmailService : IEmailService
    {
        public string To;

        public string Subject;

        public string Body;

        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
