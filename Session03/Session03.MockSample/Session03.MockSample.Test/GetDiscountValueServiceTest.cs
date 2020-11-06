using System;
using Xunit;
using Moq;
using Moq.Protected;
namespace Session03.MockSample.Test
{
    public class GetDiscountValueServiceTest
    {
        [Fact]
        public void When_CustomerIsUsual_Get1000()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(c => c.Get(It.IsAny<int>())).Returns(new Customer
            {
                CustomerType = CustomerType.Usual
            });

            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);

            var result = service.Execute(3);

            Assert.Equal(1000, result);
        }
        [Fact]
        public void When_CustomerIsUsual_Get1000Strict()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>(MockBehavior.Strict);
            //mockCustomerRepository.Setup(c => c.Get(It.IsAny<int>())).Returns(new Customer
            //{
            //    CustomerType = CustomerType.Usual
            //});

            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);

            var result = service.Execute(3);

            Assert.Equal(1000, result);
        }

        [Fact]
        public void TestOutputParameters()
        {

            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>(MockBehavior.Strict);
            bool result = true;
            mockCustomerRepository.Setup(c => c.IsValidCustomer(out result));
            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);
            service.IsValidCustomer(1);
            Assert.True(result);
        }
        [Fact]
        public void TestProperties()
        {
            //Mock<IPropertyHolder> mockPropertyHolder = new Mock<IPropertyHolder>();
            //mockPropertyHolder.Setup(c => c.CustomerId).Returns(1);

            //Mock<IPropertyProxy> mockProxy = new Mock<IPropertyProxy>();
            //mockProxy.Setup(c => c.IPropertyHolder).Returns(mockPropertyHolder.Object);


            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>(MockBehavior.Strict);

            mockCustomerRepository.Setup(c => c.IPropertyProxy.IPropertyHolder.CustomerId).Returns(1);


            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);

        }
        [Fact]
        public void CheckStateManagement()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.SetupProperty(c => c.UsedCount);
            //mockCustomerRepository.SetupAllProperties();
            mockCustomerRepository.Setup(c => c.Get(It.IsAny<int>())).Returns(new Customer
            {
                CustomerType = CustomerType.Usual
            });

            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);

            var result = service.Execute(3);

            Assert.Equal(1000, result);
            Assert.Equal(1, mockCustomerRepository.Object.UsedCount);
        }
        [Fact]

        public void CheckDatabaseEngine()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);

            var result = service.GetCustomer(1, DbEngine.Mongo);

            mockCustomerRepository.Verify(c => c.GetFromMongoDb(It.IsAny<int>()), "My Message");
            mockCustomerRepository.Verify(c => c.GetFromSqlServer(It.IsAny<int>()), Times.Never);
            //mockCustomerRepository.VerifySet(c => c.IPropertyProxy.IPropertyHolder.CustomerId = 1);
        }

        [Fact]
        public void CheckException()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(c => c.Get(12345678)).Throws<Exception>();
            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);
        }
        [Fact]
        public void CheckSeq()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.SetupSequence(c => c.IsValidCustomer(1)).Returns(true).Returns(false);
            GetDiscountValueService service = new GetDiscountValueService(mockCustomerRepository.Object);
        }
        [Fact]
        public void CheckProtected()
        {
            Mock<TestProtected> mock = new Mock<TestProtected>();

            mock.Protected().Setup("GetInt");
        }
    }
}
