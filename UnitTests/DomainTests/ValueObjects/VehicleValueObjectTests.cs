using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DomainTests.ValueObjects
{
    [TestFixture]
    public class VehicleValueObjectTests
    {

        [Test]
        public void Should_Throw_Exception_When_Brand_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new VehicleValueObject("", "Fluence", 2012);
            }, $"{nameof(VehicleValueObject.Brand)} cannot be null or empty");
        }

        [Test]
        public void Should_Throw_Exception_When_Model_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new VehicleValueObject("Renualt", "", 2012);
            }, $"{nameof(VehicleValueObject.Model)} cannot be null or empty");
        }

        [Test]
        public void Should_Throw_Exception_When_ModelYear_LowerThan_1900_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new VehicleValueObject("Renualt", "Fluence", 1899);
            }, $"{nameof(VehicleValueObject.ModelYear)} cannot be lower than 1900 or greater than next year");
        }

        [Test]
        public void Should_Throw_Exception_When_ModelYear_LowerThan_NextYear_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new VehicleValueObject("Renualt", "Fluence", DateTime.Today.Year + 2);
            }, $"{nameof(VehicleValueObject.ModelYear)} cannot be lower than 1900 or greater than next year");
        }

        [TestCase("Renualt", "Fluence", 2012)]
        [TestCase("Ford", "First", 1900)]
        [TestCase("Ford", "First", 2000)]
        public void Should_Create_Success(string brand, string model, int year)
        {

            var vo1 = new VehicleValueObject(brand, model, year);
            var vo2 = new VehicleValueObject(brand, model, year);

            vo1.Brand.Should().Be(brand);
            vo1.Model.Should().Be(model);
            vo1.ModelYear.Should().Be(year);

            (vo1 == vo2).Should().BeTrue();
        }
    }
}
