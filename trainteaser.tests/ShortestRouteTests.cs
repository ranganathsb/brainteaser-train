using NUnit.Framework;
using trainteaser.Route;

namespace trainteaser.tests
{
    [TestFixture]
    public class ShortestRouteTests
    {
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 9)]
        [TestCase("Graph: AB1, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 5)]
        [TestCase("Graph: AB1, BC4, CD8, DC1, DE6, AD1, CE2, EB3, AE7", 2)]
        [Test]
        public void WhatIsThe_ShortestRoute_FromAtoC(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var routeResponse = new ShortestRouteFinder(graph).FindRoute('A', 'C');

            //asset
            Assert.That(routeResponse.GetResponse(), Is.EqualTo(expectation.ToString()));
        }
         
    }
}