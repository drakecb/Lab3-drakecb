using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
	    private readonly DateTime dateThatFlightLeaves = DateTime.Today;
        private readonly DateTime dateThatFlightReturns = DateTime.Today.AddDays(5);
        private readonly int milage = 1000;
        
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dateThatFlightLeaves, dateThatFlightReturns, milage);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestFlightHasCorrectBasePriceForZeroDayOneThousandMileTrip()
        {
            Assert.AreEqual(200, new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(0), milage).getBasePrice());
        }

        [Test()]
        public void TestFlightHasCorrectBasePriceForOneDayOneThousandMileTrip()
        {
            Assert.AreEqual(220, new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(1), milage).getBasePrice());
        }

        [Test()]
        public void TestFlightHasCorrectBasePriceForElevenDayOneThousandMileTrip()
        {
            Assert.AreEqual(420, new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(11), milage).getBasePrice());
        }

        [Test()]
        public void TestFlightObjectIsSuccessfullyCreatedWithZeroMilage()
        {
            Assert.IsNotNull(new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(11), 0));
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFlightThrowsOnBadDates()
        {
            new Flight(dateThatFlightLeaves.AddDays(5), dateThatFlightLeaves, milage);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFlightThrowsOnBadMilage()
        {
            new Flight(dateThatFlightLeaves, dateThatFlightReturns, -5);
        }
	}
}
