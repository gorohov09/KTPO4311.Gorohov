using KTPO4311.Gorohov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;

namespace KTPO4311.Gorohov.UnitTest.src.Sample
{
    [TestFixture]
    public class SampleNSubstituteTests
    {
        [Test]
        public void Returns_ParticularArg_Works()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            fakeExtensionManager.IsValid("validfile.ext").Returns(true);

            bool result = fakeExtensionManager.IsValid("validfile.ext");

            Assert.IsTrue(result);
        }

        [Test]
        public void Returns_ArgAny_Works()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            bool result = fakeExtensionManager.IsValid("anyfile.ext");

            Assert.IsTrue(result);
        }

        [Test]
        public void Returns_ArgAny_Throws()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
                .Do(context => { throw new Exception("Fake exception"); });

            Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("anyfile.ext"));
        }

        [Test]
        public void Received_ParticularArg_Saves()
        {
            IWebService mockWebService = Substitute.For<IWebService>();

            mockWebService.LogError("Поддельное сообщение");

            mockWebService.Received().LogError("Поддельное сообщение");
        }
    }
}
