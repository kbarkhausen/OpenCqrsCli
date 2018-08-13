using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Events.Product;
using OpenCqrsCli.Repositories;
using System;

namespace OpenCqrsCli.Tests.Handlers.Events.Product.CreatingEventHandlers
{
    [TestClass]
    public class ValidateCategoryTests
    {

        private Mock<ILogger> _mockLogger;
        private Mock<ILoggerFactory> _mockLoggerFactory;
        private Mock<IRepository<Models.ProductCategory>> _mockRepository;
        private OpenCqrsCli.Handlers.Events.Product.CreatingEventHandlers.ValidateCategory _sut;

        [TestInitialize]
        public void Init()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLoggerFactory = new Mock<ILoggerFactory>();
            _mockLoggerFactory.Setup(x => x.GetLogger(It.IsAny<object>())).Returns(_mockLogger.Object);
            _mockRepository = new Mock<IRepository<Models.ProductCategory>>();
            _sut = new OpenCqrsCli.Handlers.Events.Product.CreatingEventHandlers.ValidateCategory(
                _mockLoggerFactory.Object,
                _mockRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Handle_BlankCategory_ThrowsException()
        {
            var event1 = new CreatingEvent();
            _sut.Handle(event1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Handle_CategoryIdDoesNotExistsInRepository_Ok()
        {
            _mockRepository.Setup(x => x.Get(4)).Returns(new Models.ProductCategory { });

            _sut.Handle(new CreatingEvent { ProductCategoryId = 3 });
        }

        [TestMethod]
        public void Handle_CategoryIdExistsInRepository_Ok()
        {
            _mockRepository.Setup(x => x.Get(3)).Returns(new Models.ProductCategory { });

            _sut.Handle(new CreatingEvent { ProductCategoryId = 3 });
        }

    }
}
