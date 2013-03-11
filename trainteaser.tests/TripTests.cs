using NUnit.Framework;

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
            var tripResponse = new TripFinder(graph).FindTrip('C', 'C');

            //assert
            Assert.That(tripResponse.NumberOfTrips, Is.EqualTo(expectation));
        }

        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 3)]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7, CB1", 4)]
        [Test]
        public void WhatAreTheNumberOfTrips_StartingAtAAndEndingAtC_WithExactlyFourStops(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var tripResponse = new TripFinder(graph).FindTripWithExactlySetNumberOfStops('A', 'C', 4);

            //assert
            Assert.That(tripResponse.NumberOfTrips, Is.EqualTo(expectation));
        }
         
    }
}