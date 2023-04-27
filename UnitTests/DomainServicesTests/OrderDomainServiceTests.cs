using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.DomainServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTests.ApplicationTests.Common;

namespace UnitTests.DomainServicesTests
{
    public class OrderDomainServiceTests
    {
        [Test]
        public async Task Success_Test()
        {
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var customerRepositoryMock = new Mock<ICurrentCustomer>();

            var customer = Helpers.CreateCustomer();
            customerRepositoryMock.Setup(x => x.GetAsync()).Returns(Task.FromResult(customer));

            var order = new Order(Helpers.CreateListing(), customer, Helpers.CreateCustomer(), 1000);
            orderRepositoryMock.Setup(x => x.GetByIdAsync(order.Id)).Returns(
                Task.FromResult(order));

            var domainService = new OrderDomainServiceImpl(orderRepositoryMock.Object, customerRepositoryMock.Object);


            var orderResult = await domainService.GetByIdForCurrentCustomerAsync(order.Id);

            orderResult.Id.Should().Be(order.Id);

            orderRepositoryMock.Verify(x => x.GetByIdAsync(order.Id), Times.Once);

            customerRepositoryMock.Verify(x => x.GetAsync(), Times.Once);
        }

        [Test]
        public void Shoul_Throw_Exception_When_Order_Not_Found()
        {
            var id = Guid.NewGuid();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var customerRepositoryMock = new Mock<ICurrentCustomer>();

            var customer = Helpers.CreateCustomer();
            customerRepositoryMock.Setup(x => x.GetAsync()).Returns(Task.FromResult(customer));


            orderRepositoryMock.Setup(x => x.GetByIdAsync(id)).Returns(Task.FromResult<Order>(null));

            var domainService = new OrderDomainServiceImpl(orderRepositoryMock.Object, customerRepositoryMock.Object);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var orderResult = await domainService.GetByIdForCurrentCustomerAsync(id);
            }, $"Order not found by following id: {id}");


            orderRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
            orderRepositoryMock.VerifyNoOtherCalls();

            customerRepositoryMock.Verify(x => x.GetAsync(), Times.Never);
        }


        /*
         *
         * Test Other Cases 
         *
         */
    }
}
