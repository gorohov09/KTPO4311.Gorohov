using KTPO4311.Gorohov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;

namespace KTPO4311.Gorohov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerNSubstituteTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("short.gdr").Returns(true);

            //Кофнигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();
            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.gdr");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
        {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("short.gdr").Returns(true);

            //Конфигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("long.gdr");

            //Проверка ожидаемого результата
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnFalse()
        {
            //Подготовка теста
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.When(x => x.IsValid(Arg.Any<string>()))
               .Do(context => { throw new Exception("fake exception"); });

            //Конфигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);
            LogAnalyzer log = new LogAnalyzer();
            bool result = log.IsValidLogFileName("anything");

            ////Проверка ожидаемого результата
            Assert.IsFalse(result);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            //Подготовка теста
            IWebService mockWebService = Substitute.For<IWebService>();
            WebServiceFactory.SetWebService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.gdr";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка, что поддельный объект сохранил параметры вызова
            mockWebService.Received().LogError("Слишком короткое имя файла: abc.gdr");
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            //Подготовка теста
            IWebService mockWebService = Substitute.For<IWebService>();
            WebServiceFactory.SetWebService(mockWebService);
            mockWebService.When(x => x.LogError(Arg.Any<string>()))
                .Do(context => { throw new Exception("Это подделка"); });

            IEmailService mockEmail = Substitute.For<IEmailService>();
            EmailServiceFactory.SetEmailService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.gdr";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого реультата
            //...Здесь тест будет ложным, если неверно хотя бы одно утверждение
            //...Поэтому здесь допустимо несколько утверждений
            mockEmail.Received().SendEmail("andrej.gorokhov2017@yandex.ru", "Невозможно вызвать веб-сервис", "Это подделка");

        }
    }
}
