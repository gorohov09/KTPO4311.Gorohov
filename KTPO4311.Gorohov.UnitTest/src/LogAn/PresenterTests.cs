using KTPO4311.Gorohov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Gorohov.UnitTest.src.LogAn
{
    [TestFixture]
    public class PresenterTests
    {
        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender()
        {
            FakeLogAnalyzer mockLog = new FakeLogAnalyzer();
            IView view = Substitute.For<IView>();
            Presenter presenter = new Presenter(mockLog, view);

            mockLog.CallRaiseAnalyzedEvent();
            view.Received().Render("Обработка завершена");
        }

        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
        {
            ILogAnalyzer stubLog = Substitute.For<ILogAnalyzer>();
            IView view = Substitute.For<IView>();
            Presenter presenter = new Presenter(stubLog, view);

            stubLog.Analyzed += Raise.Event<LogAnalyzerAction>();
            view.Received().Render("Обработка завершена");
        }
    }

    public class FakeLogAnalyzer : LogAnalyzer
    {
        public void CallRaiseAnalyzedEvent()
        {
            base.RaiseAnalyzedEvent();
        }
    }
}
