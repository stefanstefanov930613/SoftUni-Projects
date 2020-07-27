namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestIfNonExistingSpotThrowsException()
        {
            SoftPark softPark = new SoftPark();

            Assert.Throws<ArgumentException>(
                () => softPark.ParkCar("G1", null));
        }

        [Test]
        public void TestIfParkingSpotIsTaken()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Honda", "1234");

            softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(
                () => softPark.ParkCar("A1", car));
        }

        [Test]
        public void TestIfCarIsAlreadyParked()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("VW", "1234");
            softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(
                () => softPark.ParkCar("A2", car));

        }

        [Test]
        public void Test3()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("vw", "1234");
            string expected = $"Car:{car.RegistrationNumber} parked successfully!";
            string actual = softPark.ParkCar("A1", car);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            SoftPark softPark = new SoftPark();

            Assert.Throws<ArgumentException>(
                () => softPark.RemoveCar("G1", new Car("vw", "1234")));
        }

        [Test]
        public void Test5()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("vw", "1234");

            softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(
                () => softPark.RemoveCar("A1", new Car(null, null)));
        }

        [Test]
        public void Test6()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("vw", "1234");
            softPark.ParkCar("A1", car);
            string expected = $"Remove car:{car.RegistrationNumber} successfully!";
            string actual = softPark.RemoveCar("A1", car);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestCollectionCount()
        {
            SoftPark softPark = new SoftPark();
            int parkingCount = softPark.Parking.Count;
            int count = 12;

            Assert.AreEqual(count, parkingCount);

        }

    }
}