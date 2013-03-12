using NUnit.Framework;
using trainteaser.Trip;

namespace trainteaser.tests
{
    [TestFixture]
    public class TripTests
    {
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 2)]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7, CB1", 3)]
        [Test]
        public void WhatAreTheNumberOfTrips_StartingAtCAndEndingAtC_WithAMaximumOfThreeHops(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var tripResponse = new MaxStopTripFinder(graph).FindTrip('C', 'C');

            //assert
            Assert.That(tripResponse.GetResponse(), Is.EqualTo(expectation.ToString()));
        }

        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 3)]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7, CB1", 4)]
        [Test]
        public void WhatAreTheNumberOfTrips_StartingAtAAndEndingAtC_WithExactlyFourStops(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var tripResponse = new ExactStopTripFinder(graph).FindTrip('A', 'C');

            //assert
            Assert.That(tripResponse.GetResponse(), Is.EqualTo(expectation.ToString()));
        }
         
    }
}