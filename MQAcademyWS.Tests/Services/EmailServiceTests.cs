namespace MQAcademyWS.Tests.Services
{
    using MQAcademyWS.Services;
    using System;
    using NUnit.Framework;
    using MQAcademyWS.Model;
    using System.Threading.Tasks;

    [TestFixture]
    public class EmailServiceTests
    {
        private EmailService _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new EmailService();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new EmailService();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallSendEmail()
        {
            var emailMessage = new EmailMessage { To = "TestValue1046166175", From = "TestValue572101069", Subject = "TestValue1630600897", Body = "TestValue1941449925", IsHtml = true };
            await _testClass.SendEmail(emailMessage);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallSendEmailWithNullEmailMessage()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.SendEmail(default(EmailMessage)));
        }
    }
}