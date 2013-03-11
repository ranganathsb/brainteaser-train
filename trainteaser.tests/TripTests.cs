using NUnit.Framework;

namespace trainteaser.tests
{
    [TestFixture]
    public class TripTests
    {
        [Test]
        public void WhatAreTheNumberOfTrips_StartingAtCAndEndingAtC_WithAMaximumOfThreeHops()
        {
            //arrange
            var graph = new Graph("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

            //act
            var tripResponse = new TripFinder(graph).FindTrip('C', 'C');

            //assert
            Assert.That(tripResponse.NumberOfTrips, Is.EqualTo(2));
        }
         
    }
}