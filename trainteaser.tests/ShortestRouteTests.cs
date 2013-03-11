using NUnit.Framework;
using trainteaser.Route;

namespace trainteaser.tests
{
    [TestFixture]
    public class ShortestRouteTests
    {
        [Test]
        public void WhatIsThe_ShortestRoute_FromAtoC()
        {
            //arrange
            var graph = new Graph("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

            //act
            var routeResponse = new ShortestRouteFinder(graph).FindRoute('A', 'C');

            //asset
            Assert.That(routeResponse.GetResponse(), Is.EqualTo(9.ToString()));
        }
         
    }
}