using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Events.Product;

namespace OpenCqrsCli.Tests.Handlers.Events.Product.CreatedEventHandlers
{
    public class NotifyUsersTests
    {

        private Mock<ILogger> _mockLogger;
        private Mock<ILoggerFactory> _mockLoggerFactory;
        private OpenCqrsCli.Handlers.Events.Product.CreatedEventHandlers.NotifyUsers _sut;

        [TestInitialize]
        public void Init()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLoggerFactory = new Mock<ILoggerFactory>();
            _mockLoggerFactory.Setup(x => x.GetLogger(It.IsAny<string>())).Returns(_mockLogger.Object);
            _sut = new OpenCqrsCli.Handlers.Events.Product.CreatedEventHandlers.NotifyUsers(
                _mockLoggerFactory.Object);
        }

        public void Test()
        {
            var event1 = new CreatedEvent();
            _sut.HandleAsync(event1).RunSynchronously();

            // assert any post invokations made

        }
    }
}
