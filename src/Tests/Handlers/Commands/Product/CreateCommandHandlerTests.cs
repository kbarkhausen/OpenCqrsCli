using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenCqrs;
using OpenCqrsCli.CrossConcerns.Commands;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Handlers.Commands.Product;
using OpenCqrsCli.Repositories;
using System;
using System.Collections.Generic;

namespace OpenCqrsCli.Tests.Handlers.Commands.Product
{
    [TestClass]
    public class CreateCommandHandlerTests
    {
        private Mock<ILogger> _mockLogger;
        private Mock<ILoggerFactory> _mockLoggerFactory;
        private Mock<IDispatcher> _mockDispatcher;
        private Mock<IRepository<Models.Product>> _mockProductRepository;
        private CreateCommandHandler _sut;

        [TestInitialize]
        public void Init()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLoggerFactory = new Mock<ILoggerFactory>();
            _mockLoggerFactory.Setup(x => x.GetLogger(It.IsAny<object>())).Returns(_mockLogger.Object);

            _mockDispatcher = new Mock<IDispatcher>();
            _mockProductRepository = new Mock<IRepository<Models.Product>>();

            _sut = new CreateCommandHandler(
                _mockLoggerFactory.Object,
                _mockDispatcher.Object,
                _mockProductRepository.Object);
        }

        [TestMethod]
        public void HandleAsync_ValidCommand_Ok()
        {
            _mockDispatcher.Setup(x => x.Publish(It.IsAny<OpenCqrsCli.Events.Product.CreatingEvent>()));
            var data = new List<Models.Product>();
            _mockProductRepository.Setup(x => x.GetAll()).Returns(data);

            // Mapper initialize???

            var command = new OpenCqrsCli.Commands.Product.CreateCommand { };
            var result = _sut.HandleAsync(command).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(System.Threading.Tasks.Task<IEnumerable<OpenCqrs.Events.IEvent>>), result.GetType());

            _mockDispatcher.VerifyAll();
            _mockProductRepository.VerifyAll();
        }
    }
}
